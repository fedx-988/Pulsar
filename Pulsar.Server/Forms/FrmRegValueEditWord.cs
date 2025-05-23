﻿using Microsoft.Win32;
using Pulsar.Common.Models;
using Pulsar.Common.Utilities;
using Pulsar.Server.Enums;
using Pulsar.Server.Forms.DarkMode;
using System;
using System.Windows.Forms;

namespace Pulsar.Server.Forms
{
    public partial class FrmRegValueEditWord : Form
    {
        private readonly RegValueData _value;

        private const string DWORD_WARNING = "The decimal value entered is greater than the maximum value of a DWORD (32-bit number). Should the value be truncated in order to continue?";
        private const string QWORD_WARNING = "The decimal value entered is greater than the maximum value of a QWORD (64-bit number). Should the value be truncated in order to continue?";

        public FrmRegValueEditWord(RegValueData value)
        {
            _value = value;

            InitializeComponent();

            DarkModeManager.ApplyDarkMode(this);
			ScreenCaptureHider.ScreenCaptureHider.Apply(this.Handle);

            this.valueNameTxtBox.Text = value.Name;

            if (value.Kind == RegistryValueKind.DWord)
            {
                this.Text = "Edit DWORD (32-bit) Value";
                this.valueDataTxtBox.Type = WordType.DWORD;
                this.valueDataTxtBox.Text = ByteConverter.ToUInt32(value.Data).ToString("x");
            }
            else
            {
                this.Text = "Edit QWORD (64-bit) Value";
                this.valueDataTxtBox.Type = WordType.QWORD;
                this.valueDataTxtBox.Text = ByteConverter.ToUInt64(value.Data).ToString("x");
            }
        }

        private void radioHex_CheckboxChanged(object sender, EventArgs e)
        {
            if (valueDataTxtBox.IsHexNumber == radioHexa.Checked)
                return;

            if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
                valueDataTxtBox.IsHexNumber = radioHexa.Checked;
            else
                radioDecimal.Checked = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (valueDataTxtBox.IsConversionValid() || IsOverridePossible())
            {
                _value.Data = _value.Kind == RegistryValueKind.DWord
                    ? ByteConverter.GetBytes(valueDataTxtBox.UIntValue)
                    : ByteConverter.GetBytes(valueDataTxtBox.ULongValue);
                this.Tag = _value;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }

            this.Close();
        }

        private DialogResult ShowWarning(string msg, string caption)
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        private bool IsOverridePossible()
        {
            string message = _value.Kind == RegistryValueKind.DWord ? DWORD_WARNING : QWORD_WARNING;

            return ShowWarning(message, "Overflow") == DialogResult.Yes;
        }
    }
}
