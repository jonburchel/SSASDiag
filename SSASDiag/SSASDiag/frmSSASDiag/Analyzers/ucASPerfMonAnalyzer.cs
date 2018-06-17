﻿using Microsoft.Win32;
using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Management;
using System.ServiceProcess;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;
using System.IO;
using SimpleMDXParser;
using FastColoredTextBoxNS;
using Ionic.Zip;

namespace SSASDiag
{
    public partial class ucASPerfMonAnalyzer : UserControl
    {
        frmStatusFloater StatusFloater = null;
        string LogPath, AnalysisPath, PerfMonAnalysisId;
        SqlConnection connDB;
        List<PerfMonLog> LogFiles = new List<PerfMonLog>();

        private class PerfMonLog
        {
            public PerfMonLog Clone()
            {
                return (PerfMonLog)MemberwiseClone();
            }

            public string LogPath { get; set; }
            public string LogName
            {
                get { return LogPath.Substring(LogPath.LastIndexOf("\\") + 1); }
            }
            public bool Analyzed { get; set; }
        }

        public ucASPerfMonAnalyzer(string logPath, SqlConnection conndb, frmStatusFloater statusFloater)
        {
            InitializeComponent();
            StatusFloater = statusFloater;
            LogPath = logPath;
            connDB = new SqlConnection(conndb.ConnectionString);
            connDB.Open();
            HandleDestroyed += UcASPerfMonAnalyzer_HandleDestroyed;
            

            if (Directory.Exists(logPath))
            {
                List<string> logfiles = new List<string>();
                logfiles.AddRange(Directory.GetFiles(logPath, "*.blg", SearchOption.TopDirectoryOnly));
                foreach (string dir in Directory.EnumerateDirectories(logPath))
                    if (!dir.Contains("\\$RECYCLE.BIN") && !dir.Contains("\\System Volume Information"))
                    {
                        try { logfiles.AddRange(Directory.GetFiles(dir, "*.blg", SearchOption.AllDirectories)); }
                        catch (Exception ex) { Trace.WriteLine(Program.CurrentFormattedLocalDateTime() + ": Exception enumerating logs from subdirectories: " + ex.Message); }
                    }
                foreach (string f in logfiles)
                    LogFiles.Add(new PerfMonLog() { LogPath = f, Analyzed = false });
                AnalysisPath = LogPath + "\\Analysis";
            }
            else 
            {
                AnalysisPath = LogPath.Substring(0, LogPath.LastIndexOf("\\") + 1) + "Analysis";
                LogFiles.Add(new PerfMonLog() { LogPath = logPath, Analyzed = false });
            }

            if (!Directory.Exists(AnalysisPath))
                Directory.CreateDirectory(AnalysisPath);

            string[] PerfMonAnalyses = Directory.GetFiles(AnalysisPath, "SSASDiag_PerfMon_Analysis_*.mdf");
            if (PerfMonAnalyses.Count() > 0)
                PerfMonAnalysisId = PerfMonAnalyses[0].Replace(AnalysisPath, "").Replace("SSASDiag_PerfMon_Analysis_", "").Replace(".mdf", "").Replace("\\", "");
            else
                PerfMonAnalysisId = Guid.NewGuid().ToString();

            string sSvcUser = "";
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController s in services.OrderBy(ob => ob.DisplayName))
                if (s.DisplayName.Contains("SQL Server (" + (connDB.DataSource.Contains("\\") ? connDB.DataSource.Substring(connDB.DataSource.IndexOf("\\") + 1) : "MSSQLSERVER")))
                {
                    SelectQuery sQuery = new SelectQuery("select name, startname, pathname from Win32_Service where name = \"" + s.ServiceName + "\"");
                    ManagementObjectSearcher mgmtSearcher = new ManagementObjectSearcher(sQuery);

                    foreach (ManagementObject svc in mgmtSearcher.Get())
                        sSvcUser = svc["startname"] as string;
                    if (sSvcUser.Contains(".")) sSvcUser = sSvcUser.Replace(".", Environment.UserDomainName);
                    if (sSvcUser == "LocalSystem") sSvcUser = "NT AUTHORITY\\SYSTEM";
                }

            DirectoryInfo dirInfo = new DirectoryInfo(AnalysisPath);
            DirectorySecurity dirSec = dirInfo.GetAccessControl();
            dirSec.AddAccessRule(new FileSystemAccessRule(sSvcUser, FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.None, AccessControlType.Allow));
            dirInfo.SetAccessControl(dirSec);

            SqlCommand cmd;
            if (File.Exists(MDFPath()))
            {
                cmd = new SqlCommand("IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + DBName() + "') CREATE DATABASE [" + DBName() + "] ON (FILENAME = N'" + MDFPath().Replace("'", "''") + "'),"
                                            + "(FILENAME = N'" + LDFPath().Replace("'", "''") + "') "
                                            + "FOR ATTACH", connDB);
            }
            else
            {
                cmd = new SqlCommand(Properties.Resources.CreateDBSQLScript.
                                    Replace("<mdfpath/>", MDFPath().Replace("'", "''")).
                                    Replace("<ldfpath/>", LDFPath().Replace("'", "''")).
                                    Replace("<dbname/>", DBName())
                                    , connDB);
            }
            int ret = cmd.ExecuteNonQuery();
            cmd.CommandText = "USE [" + DBName() + "]";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "if not exists(select* from sysobjects where name= 'PerfMonLogs' and xtype = 'U') CREATE TABLE[dbo].[PerfMonLogs]"
                                + " ([LogPath] [nvarchar] (max) NOT NULL) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";
            cmd.ExecuteNonQuery();

            
            cmd.CommandText = "select * from PerfMonLogs";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PerfMonLog l = LogFiles.Find(df => df.LogPath == dr["LogPath"] as string);
                if (l != null)
                {
                    l.Analyzed = true;
                }
                else
                {
                    l = new PerfMonLog();
                    LogFiles.Add(l);
                }
            }
            dr.Close();

            try
            {
                dr = new SqlCommand("select distinct MachineName from CounterDetails", connDB).ExecuteReader();
                cmbServers.Items.Clear();
                while (dr.Read())
                    cmbServers.Items.Add(dr["MachineName"]);
                dr.Close();
                if (cmbServers.Items.Count > 0)
                {
                    cmbServers.SelectedIndex = 0;
                    cmbServers.Visible = true;
                }
            }
            catch { }

            dgdLogList.DataSource = LogFiles;
            dgdLogList.DataBindingComplete += DgdLogList_DataBindingComplete;

            frmSSASDiag.LogFeatureUse("PerfMon Analysis", "PerfMon analysis initalized for " + LogFiles.Count + " logs, " + LogFiles.Where(d => !d.Analyzed).Count() + " of which still require import for analysis.");
        }

        int DataBindingCompletions = 0;
        private void DgdLogList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataBindingCompletions++;
            if (DataBindingCompletions > 3)  // Skip the first three binding messages when we are initializing...
            {
                dgdLogList.Columns[0].Visible = false;
                dgdLogList.Columns[2].Visible = false;

                foreach (DataGridViewRow r in dgdLogList.Rows)
                {
                    try
                    {
                        PerfMonLog l = r.DataBoundItem as PerfMonLog;
                        if (l.Analyzed == false)
                        {
                            r.DefaultCellStyle.ForeColor = SystemColors.GrayText;
                            r.Cells[1].ToolTipText = "This log has not been imported yet.  Select, then click Import Selection.";
                        }
                        else
                            r.DefaultCellStyle.BackColor = SystemColors.ControlDark;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
                dgdLogList.ClearSelection();
                dgdLogList.SelectionChanged += dgdLogList_SelectionChanged;
                rtLogDetails.Text = "Performance logs found: " + LogFiles.Count + "\r\nLog(s) already imported: " + LogFiles.Where(l => l.Analyzed).Count();
            }
        }

        private void UcASPerfMonAnalyzer_HandleDestroyed(object sender, EventArgs e)
        {
            try
            {
                frmSSASDiag.LogFeatureUse("PerfMon Analysis", "Detatching from perfmon analysis database on exit.");
                connDB.ChangeDatabase("master");
                SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + DBName() + "') ALTER DATABASE [" + DBName() + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", connDB);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + DBName() + "') EXEC master.dbo.sp_detach_db @dbname = N'" + DBName() + "'", connDB);
                cmd.ExecuteNonQuery();
                connDB.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(Program.CurrentFormattedLocalDateTime() + ": Exception detaching PerfMon analysis database on exit: " + ex.Message);
                // Closing connection could fail if the database is otherwise in use or something.  Just ignore - we're closing, don't notify user...
            }
            try
            {
                string AnalysisZipFile = Directory.GetParent(Directory.GetParent(AnalysisPath).FullName).FullName + "\\" + Directory.GetParent(AnalysisPath).Name + ".zip";
                if (File.Exists(AnalysisZipFile))
                {
                    ZipFile z = new ZipFile(AnalysisZipFile);
                    z.UseZip64WhenSaving = Ionic.Zip.Zip64Option.Always;
                    z.ParallelDeflateThreshold = -1;
                    z.AddFiles(new string[] { MDFPath(), LDFPath() }, Directory.GetParent(AnalysisPath).Name + "/Analysis");
                    z.Save();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(Program.CurrentFormattedLocalDateTime() + ": Exception adding PerfMon analysis to zip folder: " + ex.Message);
            }
        }
        private string DBName()
        {
            return "SSASDiag_PerfMon_Analysis_" + PerfMonAnalysisId;
        }
        private string MDFPath()
        {
            return AnalysisPath + "\\" + DBName() + ".mdf";
        }
        private string LDFPath()
        {
            return AnalysisPath + "\\" + DBName() + ".ldf";
        }
        public bool bCancel = false;
        int LogCountAnalyzedInCurrentRun = 0;
        Process p;
        
        private void btnAnalyzeLogs_Click(object sender, EventArgs e)
        {
            if (btnAnalyzeLogs.Text == "Import Selection")
            {
                LogCountAnalyzedInCurrentRun = 0;
                bCancel = false;
                btnAnalyzeLogs.BackColor = Color.Pink;
                btnAnalyzeLogs.FlatAppearance.MouseDownBackColor = Color.IndianRed;
                btnAnalyzeLogs.FlatAppearance.MouseOverBackColor = Color.LightCoral;
                btnAnalyzeLogs.Text = "Cancel Import In-Progress...";

                new Thread(new ThreadStart(() =>
                {
                    int TotalSelectedLogsCount = 0;
                    foreach (DataGridViewRow r in dgdLogList.Rows)
                        if (!(r.DataBoundItem as PerfMonLog).Analyzed && r.Cells[1].Selected) TotalSelectedLogsCount++;
                    if (TotalSelectedLogsCount > 0)
                    {
                        rtLogDetails.Invoke(new System.Action(() => rtLogDetails.Text = "Importing " + TotalSelectedLogsCount + " log" + (TotalSelectedLogsCount == 1 ? "" : "s") + "."));
                        List<DataGridViewRow> LogsToProcess = new List<DataGridViewRow>();
                        foreach (DataGridViewRow r in dgdLogList.Rows)
                            if (r.Cells[1].Selected)
                                LogsToProcess.Add(r);
                        int LogsRequiringAnalysis = LogsToProcess.Where(drow => !(drow.DataBoundItem as PerfMonLog).Analyzed).Count();
                        frmSSASDiag.LogFeatureUse("PerfMon Analysis", "Importing " + LogsRequiringAnalysis + " log" + (LogsRequiringAnalysis > 1 ? "s." : "."));

                        // Create SQL DSN for relog
                        Registry.LocalMachine.CreateSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources").SetValue("SSASDiagPerfMonDSN", "SQL Server");
                        RegistryKey dsnKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\ODBC\\ODBC.INI\\SSASDiagPerfMonDSN");
                        dsnKey.SetValue("Database", "SSASDiagPerfMonDSN");
                        dsnKey.SetValue("Description", "SSASDiag PerfMon Relog DSN");
                        dsnKey.SetValue("Driver", Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\sqlsrv32.dll");
                        dsnKey.SetValue("Server", connDB.ConnectionString.Split(';').ToList().Where(s=>s.ToLower().StartsWith("server") || s.ToLower().StartsWith("data source")).First().Split('=')[1]);
                        dsnKey.SetValue("Database", DBName());
                        dsnKey.SetValue("Trusted_Connection", "Yes");

                        foreach (DataGridViewRow r in LogsToProcess)
                        {
                            if (!bCancel)
                            {
                                PerfMonLog l = r.DataBoundItem as PerfMonLog;
                                DataGridViewCell c = r.Cells[1];
                                if (!l.Analyzed)
                                {
                                    rtLogDetails.Invoke(new System.Action(() =>
                                    {
                                        splitAnalysis.Panel2Collapsed = false;
                                        rtLogDetails.Text = "Importing log " + (LogCountAnalyzedInCurrentRun + 1) + " of " + TotalSelectedLogsCount + ":\r\n" + l.LogPath;
                                    }));

                                    p = new Process();
                                    p.StartInfo.UseShellExecute = false;
                                    p.StartInfo.CreateNoWindow = true;
                                    p.StartInfo.FileName = "relog.exe";
                                    p.StartInfo.Arguments = "\"" + l.LogPath + "\" -f SQL -o SQL:SSASDiagPerfMonDSN!logfile -y";
                                    p.Start();

                                    int iSleepCount = 0;
                                    while (!bCancel && !p.HasExited)
                                    {
                                        Thread.Sleep(500);
                                        iSleepCount++;
                                        if (iSleepCount % 4 == 0) rtLogDetails.Invoke(new System.Action(() => rtLogDetails.AppendText(".")));
                                    }
                                    // Clean up the old process and reinitialize.
                                    if (bCancel)
                                    {
                                        p.CancelOutputRead();
                                        p.CancelErrorRead();
                                        if (!p.HasExited)
                                            p.Kill();
                                    }
                                    else
                                    {
                                        SqlCommand cmd = new SqlCommand("insert into PerfMonLogs values ('" + l.LogPath + "')", connDB);
                                        cmd.ExecuteNonQuery();
                                        l.Analyzed = true;
                                        dgdLogList.Invoke(new System.Action(() =>
                                        {
                                            c.Style.ForeColor = SystemColors.ControlText;
                                            c.ToolTipText = "";
                                        }));

                                        LogCountAnalyzedInCurrentRun++;
                                    }
                                    p.Close();

                                }
                            }
                        }

                        Registry.LocalMachine.CreateSubKey("SOFTWARE\\ODBC\\ODBC.INI").DeleteSubKey("SSASDiagPerfMonDSN");
                        Registry.LocalMachine.CreateSubKey("SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources").DeleteValue("SSASDiagPerfMonDSN");

                        if (!bCancel)
                        {
                            Invoke(new System.Action(() =>
                            {
                                SuspendLayout();
                                rtLogDetails.Text = "Imported " + TotalSelectedLogsCount + " log file" + (TotalSelectedLogsCount != 1 ? "s." : ".");
                                btnAnalyzeLogs.Text = "";
                                btnAnalyzeLogs.BackColor = SystemColors.Control;
                                btnAnalyzeLogs.Enabled = false;
                                dgdLogList_SelectionChanged(null, null);
                                splitAnalysis.Panel2Collapsed = false;
                                ResumeLayout();
                                frmSSASDiag.LogFeatureUse("PerfMon Analysis", "Completed import of " + LogsRequiringAnalysis + " log" + (LogsRequiringAnalysis > 1 ? "s." : "."));
                            }));
                        }

                        try
                        {
                            SqlDataReader dr = new SqlCommand("select distinct MachineName from CounterDetails", connDB).ExecuteReader();
                            cmbServers.Items.Clear();
                            while (dr.Read())
                                cmbServers.Items.Add(dr["MachineName"]);
                            dr.Close();
                        }
                        catch { }
                    }
                })).Start();
            }
            else
            {
                bCancel = true;
                btnAnalyzeLogs.Text = "Import Selection";
                btnAnalyzeLogs.BackColor = Color.DarkSeaGreen;
                btnAnalyzeLogs.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
                btnAnalyzeLogs.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 255, 192);
                rtLogDetails.Text = "Imported " + LogCountAnalyzedInCurrentRun + " log" + (LogCountAnalyzedInCurrentRun != 1 ? "s" : "") + " before user cancelled.";
                frmSSASDiag.LogFeatureUse("PerfMon Analysis", "Dump analysis cancelled after " + LogCountAnalyzedInCurrentRun + " log" + (LogCountAnalyzedInCurrentRun != 1 ? "s" : "") + " were imported successfully.");
            }
        }

        public event EventHandler Shown;
        bool wasShown = false;
        private void ucASPerfMonAnalyzer_Paint(object sender, PaintEventArgs e)
        {
            if (!wasShown)
            {
                wasShown = true;
                if (Shown != null)
                    Shown(this, EventArgs.Empty);
            }
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgdLogList.RowCount; i++)
            {
                dgdLogList[0, i].Value = ((CheckBox)dgdLogList.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            dgdLogList.EndEdit();
        }

        private void cmbServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvCounters.Nodes.Clear();
            SqlDataReader dr = new SqlCommand("select distinct ObjectName from CounterDetails where MachineName = '" + cmbServers.SelectedItem + "' order by ObjectName", connDB).ExecuteReader();
            while (dr.Read())
                tvCounters.Nodes.Add(dr["ObjectName"] as string, dr["ObjectName"] as string);
            dr.Close();
            dr = new SqlCommand("select distinct ObjectName, CounterName from CounterDetails where MachineName = '" + cmbServers.SelectedItem + "' order by CounterName", connDB).ExecuteReader();
            while (dr.Read())
                tvCounters.Nodes[dr["ObjectName"] as string].Nodes.Add(dr["CounterName"] as string, dr["CounterName"] as string);
            dr.Close();
            dr = new SqlCommand("select distinct ObjectName, CounterName, ParentName from CounterDetails where ParentName is not null and  MachineName = '" + cmbServers.SelectedItem + "' order by ParentName", connDB).ExecuteReader();
            while (dr.Read())
                tvCounters.Nodes[dr["ObjectName"] as string].Nodes[dr["CounterName"] as string].Nodes.Add(dr["ParentName"] as string, dr["ParentName"] as string);
            dr.Close();
        }

        private void dgdLogList_SelectionChanged(object sender, EventArgs e)
        {
            dgdLogList.SuspendLayout();
            PerfMonLog lComp = null;
            int AnalyzedCount = 0;
            int selCount = (dgdLogList.AreAllCellsSelected(true) ? dgdLogList.RowCount : dgdLogList.SelectedCells.Count);
            foreach (DataGridViewCell c in dgdLogList.SelectedCells)
            {
                if (c.Visible)
                {
                    PerfMonLog d = c.OwningRow.DataBoundItem as PerfMonLog;
                    if (d.Analyzed)
                    {
                        AnalyzedCount++;

                        if (lComp == null)
                            lComp = d.Clone();
                    }
                }
            }
            if (selCount > 0)
            {
                if (lComp == null)
                {
                    rtLogDetails.Text = "Selection requires initial import.";
                }
                else
                {
                    
                    string pluralize = (selCount > 1 ? "s: " : ": ");
                    rtLogDetails.Text = "Log file" + pluralize + (dgdLogList.SelectedCells.Count > 1 ? "<multiple>" : lComp.LogPath) + "\r\n" +
                        (AnalyzedCount < selCount ?
                            AnalyzedCount + " of " + selCount + " logs already imported for analysis.\r\n" :
                            (selCount == 1 ? "This log has been imported already." : selCount + " logs already imported for analysis.\r\n"));
                }
            }

            if (btnAnalyzeLogs.Text == "Import Selection" || btnAnalyzeLogs.Text == "")
            {
                btnAnalyzeLogs.Enabled = (AnalyzedCount < selCount);
                btnAnalyzeLogs.BackColor = (AnalyzedCount < selCount) ? Color.DarkSeaGreen : SystemColors.Control;
                btnAnalyzeLogs.Text = (AnalyzedCount < selCount) ? "Import Selection" : "";
            }
            dgdLogList.ResumeLayout();
        }

        private void dgdLogList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Applications\windbg.exe\shell\open\command");
                string WinDbgPath = "";
                if (key != null)
                {
                    WinDbgPath = key.GetValue("") as string;
                    WinDbgPath = WinDbgPath.Substring(0, WinDbgPath.IndexOf(".exe") + ".exe".Length).Replace("\"", "");
                }
                if (WinDbgPath != "")
                {
                    PerfMonLog l = (dgdLogList.Rows[e.RowIndex].DataBoundItem as PerfMonLog);
                    cm.MenuItems.Add(new MenuItem("Open " + l.LogName + " in WinDbg for further analysis...",
                        new EventHandler((object o, EventArgs ea) =>
                            Process.Start(WinDbgPath, "-z \"" + l.LogPath + "\""))
                        ));
                    cm.Show(ParentForm, new Point(MousePosition.X - ParentForm.Left - 10, MousePosition.Y - ParentForm.Top - 26));
                }
            }
        }
    }
}
