﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SSASDiag
{
    public partial class frmStatusFloater : ShadowedForm
    {
        public frmStatusFloater()
        {
            InitializeComponent();
            tt = new System.Threading.Timer(new System.Threading.TimerCallback(Tt_Elapsed), (object)this, Timeout.Infinite, Timeout.Infinite);
            CreateHandle();
        }

        private bool escapePressed = false;
        private System.Threading.Timer tt = null;

        public bool EscapePressed
        {
            get
            {
                return escapePressed;
            }
            set
            {
                if (value)
                    tt.Change(Timeout.Infinite, Timeout.Infinite);
                escapePressed = value;
            }
        }
        private bool autoUpdateDuration = false;
        private DateTime StartTime = DateTime.MinValue;
        public bool AutoUpdateDuration
        {
            get { return autoUpdateDuration; } 
            set
            {
                if (value)
                {
                    string[] timeParts = lblTime.Text.Split(':');
                    if (timeParts.Length == 2)
                    {
                        int iMinutes = 0, iSeconds = 0;
                        Int32.TryParse(timeParts[0], out iMinutes);
                        Int32.TryParse(timeParts[1], out iSeconds);
                        StartTime = DateTime.Now - TimeSpan.FromMinutes(iMinutes) - TimeSpan.FromSeconds(iSeconds);
                    }
                    else
                        StartTime = DateTime.Now;
                    tt.Change(0, 1000);
                    lblTime.Visible = true;
                }
                else
                    tt.Change(Timeout.Infinite, Timeout.Infinite);
                autoUpdateDuration = value;
            }
        }

        private static void Tt_Elapsed(object sender)
        {
            frmStatusFloater f = sender as frmStatusFloater;
            if (sender != null && f.lblTime.Text != "")
            {
                string curTime = f.lblTime.Text;
                string[] timeparts = f.lblTime.Text.Split(':');
                TimeSpan newTime = (TimeSpan.FromMinutes(Convert.ToInt32(timeparts[0])) + TimeSpan.FromSeconds(Convert.ToInt32(timeparts[1])).Add(TimeSpan.FromSeconds(1)));
                f.lblTime.Invoke(new Action(() => f.lblTime.Text = newTime.ToString("mm\\:ss")));
            }
        }

        private void FrmStatusFloater_VisibleChanged(object sender, System.EventArgs e)
        {
            if (!Visible && tt != null)
                tt.Change(Timeout.Infinite, Timeout.Infinite);
        }

        private void frmStatusFloater_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                EscapePressed = true;
        }
    }


    public class ShadowedForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    }
}
