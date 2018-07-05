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
using System.Windows.Forms.DataVisualization.Charting;

namespace SSASDiag
{
    public partial class frmAddPerfMonRule : Form
    {
        TreeView tvCounters;
        ucASPerfMonAnalyzer HostControl = ((Program.MainForm.tcCollectionAnalysisTabs.TabPages[1].Controls["tcAnalysis"] as TabControl).TabPages["Performance Logs"].Controls[0] as ucASPerfMonAnalyzer);
        Color WarnColor, ErrorColor, PassColor = Color.Empty;
        public frmAddPerfMonRule()
        {
            InitializeComponent();

            // 
            // tvCounters
            // 
            tvCounters = new TreeView();
            tvCounters.CheckBoxes = false;
            tvCounters.Dock = System.Windows.Forms.DockStyle.Fill;
            tvCounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tvCounters.Name = "tvCounters";
            tvCounters.TabIndex = 0;
            tvCounters.Margin = new Padding(0);
            tvCounters.ShowNodeToolTips = true;
            tvCounters.AllowDrop = true;
            tvCounters.ItemDrag += TvCounters_ItemDrag;
            tvCounters.DragEnter += TvCounters_DragEnter;
            tvCounters.DragDrop += TvCounters_DragDrop;
            splitCounters.Panel1.Controls.Add(tvCounters);
            foreach (TreeNode node in HostControl.tvCounters.Nodes)
                tvCounters.Nodes.Add(node.Clone() as TreeNode);
            tt.SetToolTip(tvCounters, "Tip: To select counters by alternate groupings, exit this dialog, reorder headers above the counter treeview in the main browser, then reopen this dialog.");

            dgdExpressions.Columns[0].CellTemplate = new DataGridViewTextBoxColumnWithExpandedEditArea();
            dgdExpressions.Columns[1].CellTemplate = new DataGridViewTextBoxColumnWithExpandedEditArea();
            dgdExpressions.Rows.Clear();
            WarnColor = Color.FromArgb(255, Color.Khaki);
            ErrorColor = Color.FromArgb(255, Color.Pink);
            PassColor = Color.FromArgb(255, Color.LightGreen);
            cmbCheckAboveOrBelow.SelectedIndex = 0;
        }

        private void splitExpressions_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            splitCounters.SplitterDistance = e.SplitX;
        }

        private void splitCounters_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
            splitExpressions.SplitterDistance = e.SplitX;
        }

        /* Drag & Drop */
        #region
        private Rectangle dragBoxFromMouseDown;
        private object valueFromMouseDown;

        private void dgdSelectedCounters_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TvCounters_DragDrop(object sender, DragEventArgs e)
        {
            DataGridViewRow r = (DataGridViewRow)e.Data.GetData("System.Windows.Forms.DataGridViewRow");
            AddCountersBackToTreeViewFromGrid(r);
            dgdSelectedCounters.Rows.Remove(r);
            UpdateExpressionsAndCountersCombo();
        }

        private void AddCountersBackToTreeViewFromGrid(DataGridViewRow r)
        {
            TreeNode node = r.Tag as TreeNode;
            string[] parts = (r.Cells[0].Value as string).Split('\\');
            TreeNode newNode = tvCounters.Nodes[parts[0]];
            for (int i = 1; i < parts.Count() - 2; i++)
                if (parts[i] != "*")
                    newNode = newNode.Nodes[parts[i]];
            if (newNode == null)
            {
                for (int i = 0; i < tvCounters.Nodes.Count; i++)
                {
                    if (tvCounters.Nodes[i].Name.CompareTo(node.Name) == 1)
                    {
                        tvCounters.Nodes.Insert(i, node);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < newNode.Nodes.Count; i++)
                {
                    if (newNode.Nodes[i].Name.CompareTo(node.Name) == 1)
                    {
                        newNode.Nodes.Insert(i, node);
                        break;
                    }
                }
            }
        }

        private void TvCounters_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TvCounters_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void dgdSelectedCounters_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                string CounterPath = node.FullPath;
                string[] parts = CounterPath.Split('\\');
                if (node.Nodes.Count > 0)
                {
                    CounterPath += "\\*";
                    if (node.Nodes[0].Nodes.Count > 0)
                        CounterPath += "\\*";
                }
                TreeNode newNode = tvCounters.Nodes[parts[0]];
                for (int i = 1; i < parts.Count(); i++)
                    newNode = newNode.Nodes[parts[i]];
                dgdSelectedCounters.Rows.Add();
                DataGridViewRow r = dgdSelectedCounters.Rows[dgdSelectedCounters.Rows.Count - 1];
                if (!CounterPath.Contains("*"))
                    r.Cells[3].ReadOnly = true;
                r.Cells[1].Value = true;
                r.Tag = newNode;
                if (newNode.Parent == null)
                    tvCounters.Nodes.Remove(newNode);
                else
                    newNode.Parent.Nodes.Remove(newNode);
                r.Cells[0].Value = CounterPath;
                UpdateExpressionsAndCountersCombo();
            }
        }

        private void UpdateExpressionsAndCountersCombo()
        {
            cmbValueToCheck.Items.Clear();
            cmbWarnExpr.Items.Clear();
            cmbValLow.Items.Clear();
            cmbValHigh.Items.Clear();
            btnSaveRule.Enabled = false;
            foreach (DataGridViewRow r in dgdSelectedCounters.Rows)
                if (r.Cells[0].Value != null)
                    cmbValueToCheck.Items.Add(r.Cells[0].Value as string);
            foreach (DataGridViewRow r in dgdExpressions.Rows)
                if (r.Cells[0].Value != null && r.Cells[0].ErrorText == "" && r.Cells[1].ErrorText == "")
                {
                    cmbValueToCheck.Items.Add(r.Cells[0].Value as string);
                    cmbValLow.Items.Add(r.Cells[0].Value as string);
                    cmbValHigh.Items.Add(r.Cells[0].Value as string);
                    cmbWarnExpr.Items.Add(r.Cells[0].Value as string);
                }

            cmbValueToCheck.Text = "";

            if (cmbValueToCheck.Items.Count == 0)
                cmbValueToCheck.Enabled = false;
            else
                cmbValueToCheck.Enabled = true;

            if (cmbValHigh.Items.Count == 0)
                cmbValLow.Enabled = cmbValHigh.Enabled = cmbWarnExpr.Enabled = false;
            else
                cmbValLow.Enabled = cmbValHigh.Enabled = cmbWarnExpr.Enabled = true;
            cmbSeriesFunction.Visible = lblSeriesFunction.Visible = lblPctMatchCheck.Visible = udPctMatchCheck.Visible = false;
            ValidateChildren();
        }

        private void dgdSelectedCounters_MouseDown(object sender, MouseEventArgs e)
        {
            var hittestInfo = dgdSelectedCounters.HitTest(e.X, e.Y);

            if (hittestInfo.RowIndex != -1 && hittestInfo.ColumnIndex != -1)
            {
                valueFromMouseDown = dgdSelectedCounters.Rows[hittestInfo.RowIndex];
                if (valueFromMouseDown != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
                }
            }
            else
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dgdSelectedCounters_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = dgdSelectedCounters.DoDragDrop(valueFromMouseDown, DragDropEffects.Move);
                }
            }
        }

        private void dgdExpressions_DragDrop(object sender, DragEventArgs e)
        {
            DataGridViewRow r = (DataGridViewRow)e.Data.GetData("System.Windows.Forms.DataGridViewRow");
            if (r != null)
            {
                if (dgdExpressions.CurrentRow == null)
                {
                    if (dgdExpressions.Rows.Count == 0)
                        dgdExpressions.Rows.Add();
                    dgdExpressions.CurrentCell = dgdExpressions.Rows[dgdExpressions.Rows.Count - 1].Cells[1];
                }
                string existingVal = (dgdExpressions.CurrentRow.Cells[1].Value as string);
                if (existingVal != null)
                    existingVal = existingVal.Trim();
                else
                    existingVal = "";

                if (dgdExpressions.CurrentRow.Cells[0].Value == null)
                    dgdExpressions.CurrentRow.Cells[0].Value = "Expr" + dgdExpressions.CurrentRow.Index;
                dgdExpressions.CurrentRow.Cells[1].Value = existingVal + (existingVal == "" ? "" : " ") + "[" + r.Cells[0].Value + "]";
                dgdExpressions.CurrentCell = dgdExpressions.CurrentRow.Cells[1];
                dgdExpressions.BeginEdit(false);
                SendKeys.Send(" {BS}");
            }
        }

        private void dgdExpressions_DragEnter(object sender, DragEventArgs e)
        {
            DataGridViewRow r = (DataGridViewRow)e.Data.GetData("System.Windows.Forms.DataGridViewRow");
            if (r != null)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        #endregion

        private bool IsRuleComplete()
        {
            if (txtName.Text == "" || txtDescription.Text == "" ||
                dgdSelectedCounters.Rows.Count == 0 || dgdExpressions.Rows.Count == 0 ||
                cmbValueToCheck.SelectedIndex == -1 ||
                (cmbSeriesFunction.Visible && cmbSeriesFunction.SelectedIndex == -1) ||
                (cmbCheckAboveOrBelow.SelectedIndex == 1 && (cmbValHigh.SelectedIndex == -1 || txtHighRegion.Text == "" || txtHighResult.Text == "")) ||
                (cmbCheckAboveOrBelow.SelectedIndex == 0 && (cmbValLow.SelectedIndex == -1 || txtLowRegion.Text == "" || txtLowResult.Text == "")) ||
                (cmbWarnExpr.SelectedIndex >= 0 && (txtWarnRegion.Text == "" || txtWarnResult.Text == "")))
                return false;
            foreach (DataGridViewRow r in dgdExpressions.Rows)
                if (r.Cells[0].ErrorText != "" || r.Cells[1].ErrorText != "")
                    return false;
            return true;
        }

        List<TreeNode> ListNodes(TreeView tv)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode subnode in tv.Nodes)
                nodes.AddRange(ListNodes(subnode));
            return nodes;
        }
        List<TreeNode> ListNodes(TreeNode node)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode subnode in node.Nodes)
                nodes.AddRange(ListNodes(subnode));
            return nodes;
        }

        private bool IsValidExpressionToken(string token)
        {
            if (token.Trim() == "")
                return true;
            token = token.TrimStart().TrimEnd().ToLower();
            double testNum = double.NaN;
            if (double.TryParse(token, out testNum))
                return true;
            string originalToken = token;
            token = token.Replace(" ", "");
            if (
                (dgdExpressions.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value == null ? false : r.Cells[0].Value.ToString().ToLower().Equals(token) && r.Index < dgdExpressions.CurrentCell.RowIndex).Count() == 0 &&
                    !token.StartsWith("[") && !token.Contains("]")
                ) &&
                (!token.StartsWith("[") ||
                !(
                    token.EndsWith("]") ||
                    token.EndsWith("].first") || token.EndsWith("].first()") ||
                    token.EndsWith("].last") || token.EndsWith("].last()") ||
                    token.EndsWith("].min") || token.EndsWith("].min()") ||
                    token.EndsWith("].max") || token.EndsWith("].max()") ||
                    token.EndsWith("].avg") || token.EndsWith("].avg()") ||
                    token.EndsWith("].avg(true)") || token.EndsWith("].avg(false)") ||
                    token.EndsWith("].avg(true,true)") || token.EndsWith("].avg(true,false)") ||
                    token.EndsWith("].avg(false,true)") || token.EndsWith("].avg(false,false)")
                  )))
                return false;
            else
            {
                token = originalToken;
                if (token.Contains("]"))
                {
                    token = token.Substring(0, token.IndexOf(']'));
                    token = token.TrimStart('[');
                }
                if (dgdSelectedCounters.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value.ToString().ToLower().Equals(token)).Count() > 0 ||
                    dgdExpressions.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value == null ? false : r.Cells[0].Value.ToString().ToLower().Equals(token) && r.Index < dgdExpressions.CurrentCell.RowIndex).Count() > 0)
                    return true;
                else
                    return false;
            }
        }

        private void dgdExpressions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dgdExpressions.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCell;
            cell.ErrorText = "";
            if (e.ColumnIndex == 1 && cell.Value as string != null)
            {
                if (dgdExpressions.Rows[e.RowIndex].Cells[0].Value == null)
                    dgdExpressions.Rows[e.RowIndex].Cells[0].Value = "Expr" + e.RowIndex;
                bool bValidExpression = true, bInCounterName = false, bPriorSeriesFound = false, bOperatorProcessed = true;
                string currentToken = "";
                string priorToken = "";
                int iCurPos = 0, iOpenParens = 0;
                foreach (char c in (cell.Value as string).ToLower().TrimStart().TrimEnd())
                {
                    if (c == '\"')
                    {
                        bValidExpression = false;
                        break;
                    }
                    if (c == '[' || c == '(')
                    {
                        if (!bOperatorProcessed)
                        {
                            bValidExpression = false;
                            break;
                        }
                        if (c == '[')
                            bOperatorProcessed = false;
                        else
                            iOpenParens++;
                        if (priorToken != "")
                            bPriorSeriesFound = true;
                        bInCounterName = true;
                        if (currentToken.Trim() != "" && bPriorSeriesFound != currentToken.Trim().EndsWith("]"))
                        {
                            // We were trying to compare a series with a scalar...
                            bValidExpression = false;
                            break;
                        }
                        bPriorSeriesFound = currentToken.Trim().EndsWith("]");
                        if (!IsValidExpressionToken(priorToken))
                        {
                            bValidExpression = false;
                            break;
                        }
                    }
                    if (c == ']')
                    {
                        bInCounterName = false;
                    }
                    if (c == ')')
                    {
                        iOpenParens--;
                        bOperatorProcessed = false;
                        if (iOpenParens < 0)
                        {
                            bValidExpression = false;
                            break;
                        }
                    }
                    if (!bInCounterName && (c == '+' || c == '-' || c == '/' || c == '*' || c == '\\'))
                    {
                        bOperatorProcessed = true;
                        if (bPriorSeriesFound && currentToken.Trim().EndsWith("]") && currentToken.Contains("*"))
                        {
                            string root = currentToken.Replace("\\*", "");
                            if (root.Contains("\\"))
                                root = root.Substring(0, root.IndexOf("\\"));
                            string oldRoot = priorToken.Replace("\\*", "");
                            if (oldRoot.Contains("\\"))
                                oldRoot = root.Substring(0, root.IndexOf("\\"));
                            if (root != oldRoot)
                            {
                                cell.ErrorText = "Wildcard counters can only be used in conjunction with counters under the same path.";
                                return;
                            }
                        }
                        if (!IsValidExpressionToken(currentToken) && currentToken.Trim().EndsWith("]") == bPriorSeriesFound)
                        {
                            bValidExpression = false;
                            break;
                        }
                        if (currentToken.Trim() != "")
                        {
                            priorToken = currentToken;
                            bPriorSeriesFound = priorToken.Trim().EndsWith("]");
                            currentToken = "";
                        }
                    }
                    else if ((c != ' ' && c != ')' && c != '(') || bInCounterName)
                        currentToken += c;
                    iCurPos++;
                }
                if (bValidExpression)
                {
                    cell.ErrorText = "";
                    if (priorToken.EndsWith("]"))
                        bPriorSeriesFound = true;
                    if (!IsValidExpressionToken(currentToken) || (currentToken.Trim() == "" ||
                        ((currentToken.Trim().EndsWith("]") != bPriorSeriesFound) && priorToken.Trim() != "")))
                    {
                        if (currentToken.Trim().EndsWith("]") != bPriorSeriesFound && priorToken != "")
                            cell.ErrorText = "Counter series and scalar expressions cannot be used together.  Use First, Last, Max, Min, or Avg instead.";
                        else
                            cell.ErrorText = "Unrecognized token: " + currentToken;
                        if (dgdExpressions.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[0].Value == null ? false : r.Cells[0].Value.ToString().ToLower().Equals(currentToken) && r.Index >= dgdExpressions.CurrentCell.RowIndex).Count() > 0)
                            cell.ErrorText += "\nExpressions must use only _prior_ expressions from the list.";
                        bValidExpression = false;
                    }
                    if (bValidExpression && bPriorSeriesFound && currentToken.Trim().EndsWith("]") && currentToken.Contains("*") && priorToken.Trim() != "")
                    {
                        string root = currentToken.Replace("\\*", "");
                        if (root.Contains("\\"))
                            root = root.Substring(0, root.IndexOf("\\"));
                        string oldRoot = priorToken.Replace("\\*", "");
                        if (oldRoot.Contains("\\"))
                            oldRoot = root.Substring(0, root.IndexOf("\\"));
                        if (root != oldRoot)
                        {
                            cell.ErrorText = "Wildcard counters can only be used in conjunction with counters under the same path.";
                            return;
                        }
                    }
                }
                else
                {
                    if (currentToken.Trim().EndsWith("]") != bPriorSeriesFound)
                        cell.ErrorText = "Counter series and scalar expressions cannot be used together.  Use First, Last, Max, Min, or Avg instead.";
                    else
                        cell.ErrorText = "Invalid token at: " + (cell.Value as string).Substring(0, iCurPos);
                }                   
            }
            else if (e.ColumnIndex == 0 && cell.Value as string != null)
            {
                string val = cell.Value as string;
                val = val.TrimStart().TrimEnd();
                if (!char.IsLetter(val[0]))
                    cell.ErrorText = "Expression names must start with an alphabetic character.";
                foreach (char c in val)
                    if (!char.IsLetterOrDigit(c))
                        cell.ErrorText = "Expression names can only contain alphabeticnumeric characters.";
            }
            if (e.ColumnIndex < 2 && (cell.Value == null || (cell.Value as string).Trim() == ""))
            {
                string OtherCellVal = (dgdExpressions.Rows[e.RowIndex].Cells[Convert.ToInt32((!Convert.ToBoolean(e.ColumnIndex)))].Value) as string;
                if (!(OtherCellVal == null || OtherCellVal.Trim() == ""))
                    cell.ErrorText = "Please enter a value for the " + dgdExpressions.Columns[e.ColumnIndex].Name + ".";
            }
            dgdExpressions.EndEdit();
            UpdateExpressionsAndCountersCombo();
        }

        private void dgdExpressions_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgdExpressions.HitTest(e.X, e.Y).Type == DataGridViewHitTestType.RowHeader)
            {
                dgdExpressions.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
                dgdExpressions.EndEdit();
            }
            else
                dgdExpressions.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void dgdExpressions_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            foreach (DataGridViewRow r in dgdExpressions.Rows)
                dgdExpressions_CellEndEdit(sender, new DataGridViewCellEventArgs(1, r.Index));
            UpdateExpressionsAndCountersCombo();
        }

        private void cmbCheckAboveOrBelow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCheckAboveOrBelow.SelectedIndex == 0)
            {
                pnlHigh.BackColor = PassColor;
                pnlMed.BackColor = WarnColor;
                pnlLow.BackColor = ErrorColor;
                lblHighRegion.Visible = lblHighResultText.Visible = lblHighVal.Visible = txtHighRegion.Visible = txtHighResult.Visible = cmbValHigh.Visible = false;
                lblLowRegion.Visible = lblLowResultText.Visible = lblLowVal.Visible = txtLowRegion.Visible = txtLowResult.Visible = cmbValLow.Visible = true;
                lblWarnVal.Text = "Warn below value";
            }
            else
            {
                pnlHigh.BackColor = ErrorColor;
                pnlMed.BackColor = WarnColor;
                pnlLow.BackColor = PassColor;
                lblHighRegion.Visible = lblHighResultText.Visible = lblHighVal.Visible = txtHighRegion.Visible = txtHighResult.Visible = cmbValHigh.Visible = true;
                lblLowRegion.Visible = lblLowResultText.Visible = lblLowVal.Visible = txtLowRegion.Visible = txtLowResult.Visible = cmbValLow.Visible = false;
                lblWarnVal.Text = "Warn above value";
            }
            btnSaveRule.Enabled = IsRuleComplete();
        }

        private void frmAddPerfMonRule_SizeChanged(object sender, EventArgs e)
        {
            pnlHigh.Width = pnlLow.Width = pnlMed.Width = Width - pnlHigh.Left;
            txtLowRegion.Width = txtLowResult.Width = txtWarnRegion.Width = txtWarnResult.Width = txtHighRegion.Width = txtHighResult.Width = pnlHigh.Width - txtHighResult.Left - 38;
            btnCancel.Left = Width - btnCancel.Width - 20;
            btnSaveRule.Left = btnCancel.Left - btnSaveRule.Width - 6;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar!= '_' && e.KeyChar != ' ') ||
                (txtName.Text == "" && char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
                tt.Show("Rules must start with a letter and use only letter, number, space, dash, or underscore.", txtName, 0, 0, 2000);
            }
            btnSaveRule.Enabled = IsRuleComplete();
        }

        private void dgdSelectedCounters_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            AddCountersBackToTreeViewFromGrid(e.Row);
            foreach (DataGridViewRow r in dgdExpressions.Rows)
                dgdExpressions_CellEndEdit(dgdExpressions, new DataGridViewCellEventArgs(1, r.Index));
            UpdateExpressionsAndCountersCombo();
        }

        private void cmbErrorWarnVals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbWarnExpr)
                ValidateChildren();
            btnSaveRule.Enabled = IsRuleComplete();
        }

        private void txtErrorWarnRegions_TextChanged(object sender, EventArgs e)
        {
            if (sender == txtWarnRegion || sender == txtWarnResult)
                ValidateChildren();
            btnSaveRule.Enabled = IsRuleComplete();
        }

        private void RequireRuleElements_Validating(object sender, CancelEventArgs e)
        {
            if (sender is ComboBox)
            {
                ComboBox cb = sender as ComboBox;
                if (cb == cmbWarnExpr && txtWarnRegion.Text.Trim() == "" && txtWarnResult.Text.Trim() == "")
                    errorProvider1.SetError(cb, "");
                else
                {
                    if (cb.SelectedIndex == -1)
                    {
                        if (cb == cmbWarnExpr)
                            errorProvider1.SetError(cb, "Warning value required when a warning region label and result text are set.");
                        else
                            errorProvider1.SetError(cb, "Selection is required for a valid rule.");
                    }
                    else
                        errorProvider1.SetError(cb, "");
                }
            }
            else if (sender is TextBox)
            {
                TextBox tb = sender as TextBox;
                if ((tb == txtWarnResult || tb == txtWarnRegion) && cmbWarnExpr.SelectedIndex == -1  && txtWarnResult.Text.Trim() == "" && txtWarnRegion.Text.Trim() == "")
                    errorProvider1.SetError(tb, "");
                else
                {
                    if (tb.Text.Trim() == "")
                    {
                        if (tb == txtWarnRegion || tb == txtWarnResult)
                            errorProvider1.SetError(tb, "Warning region label and result text are required when a warning value is set.");
                        else
                            errorProvider1.SetError(tb, "This item is required for a valid rule.");
                    }
                    else
                        errorProvider1.SetError(tb, "");
                }
            }
        }

        private void frmAddPerfMonRule_Shown(object sender, EventArgs e)
        {
            ValidateChildren();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSaveRule_Click(object sender, EventArgs e)
        {
            RegistryKey rules = Registry.LocalMachine.CreateSubKey("SOFTWARE\\SSASDiag\\PerfMonRules", RegistryKeyPermissionCheck.ReadWriteSubTree);
            foreach (string ruleName in rules.GetSubKeyNames())
                if (ruleName.ToLower() == txtName.Text.ToLower().Trim())
                {
                    errorProvider1.SetError(txtName, "A rule with this name already exists!");
                    return;
                }
            RegistryKey rule = rules.CreateSubKey(txtName.Text.Trim(), RegistryKeyPermissionCheck.ReadWriteSubTree);
            rule.DeleteSubKeyTree("Counters", false);
            RegistryKey counters = rule.CreateSubKey("Counters", RegistryKeyPermissionCheck.ReadWriteSubTree);
            foreach (DataGridViewRow r in dgdSelectedCounters.Rows)
            {
                RegistryKey counter = counters.CreateSubKey(r.Cells[0].Value as string, RegistryKeyPermissionCheck.ReadWriteSubTree);
                counter.SetValue("Display", (bool)r.Cells[1].Value);
                counter.SetValue("Highlight", (bool)r.Cells[2].Value);
                counter.SetValue("WildcardIncludes_Total", (bool)r.Cells[3].Value);
                counter.Close();
            }
            counters.Close();
            rule.DeleteSubKeyTree("Expressions", false);
            RegistryKey expressions = rules.CreateSubKey("Expressions", RegistryKeyPermissionCheck.ReadWriteSubTree);
            foreach (DataGridViewRow r in dgdExpressions.Rows)
            {
                RegistryKey expr = expressions.CreateSubKey(r.Cells[0].Value as string, RegistryKeyPermissionCheck.ReadWriteSubTree);
                expr.SetValue("Display", (bool)r.Cells[2].Value);
                expr.SetValue("Highlight", (bool)r.Cells[3].Value);
                expr.SetValue("Expression", r.Cells[1].Value as string);
                expr.Close();
            }
            expressions.Close();
            rule.SetValue("ValueOrSeriesToCheck", cmbValueToCheck.SelectedItem as string);
            rule.SetValue("SeriesFunction", cmbSeriesFunction.SelectedItem as string);
            rule.SetValue("PctRequiredToMatchWarnError", cmbSeriesFunction.SelectedItem as string);
            rule.SetValue("CheckValueAboveOrBelowWarnError", cmbCheckAboveOrBelow.SelectedIndex);
            if (cmbCheckAboveOrBelow.SelectedIndex == 0)
            {
                rule.SetValue("ErrorExpr", cmbValHigh.SelectedItem as string);
                rule.SetValue("ErrorRegionLabel", txtHighRegion.Text.Trim());
                rule.SetValue("ErrorText", txtHighResult.Text.Trim());
            }
            else
            {
                rule.SetValue("ErrorExpr", cmbValLow.SelectedItem as string);
                rule.SetValue("ErrorRegionLabel", txtLowRegion.Text.Trim());
                rule.SetValue("ErrorText", txtLowResult.Text.Trim());
            }
            
            if (cmbWarnExpr.SelectedIndex > -1)
            {
                rule.SetValue("WarnExpr", cmbWarnExpr.SelectedItem as string);
                rule.SetValue("WarnRegionLabel", txtWarnRegion.Text.Trim());
                rule.SetValue("WarningText", txtWarnResult.Text.Trim());
            }
            rule.Close();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbValueToCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bSeries = false;
            foreach (DataGridViewRow r in dgdSelectedCounters.Rows)
                if (r.Cells[0].Value as string == cmbValueToCheck.SelectedItem as string)
                    bSeries = true;
            cmbSeriesFunction.SelectedIndex = -1;
            lblPctMatchCheck.Visible = udPctMatchCheck.Visible = false;
            if (bSeries)
                cmbSeriesFunction.Visible = lblSeriesFunction.Visible = true;
            else
                cmbSeriesFunction.Visible = lblSeriesFunction.Visible = false;
            btnSaveRule.Enabled = IsRuleComplete();
        }

        private void cmbSeriesFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPctMatchCheck.Visible = udPctMatchCheck.Visible = cmbSeriesFunction.SelectedItem as string == "X% of values to warn/error";
            btnSaveRule.Enabled = IsRuleComplete();
        }
    }

    public class DataGridViewTextBoxColumnWithExpandedEditArea : DataGridViewTextBoxCell
    {
        public override void PositionEditingControl(bool setLocation, bool setSize,
            Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle,
            bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded,
            bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            cellClip.Height = cellClip.Height; // ← Or any other suitable height
            cellBounds.Height = cellBounds.Height;
            var r = base.PositionEditingPanel(cellBounds, cellClip, cellStyle,
                singleVerticalBorderAdded, singleHorizontalBorderAdded,
                isFirstDisplayedColumn, isFirstDisplayedRow);
            this.DataGridView.EditingControl.Location = r.Location;
            this.DataGridView.EditingControl.Size = r.Size;
        }
        public override void InitializeEditingControl(int rowIndex,
            object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            ((TextBox)this.DataGridView.EditingControl).Multiline = true;
            ((TextBox)this.DataGridView.EditingControl).BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
