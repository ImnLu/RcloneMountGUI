﻿namespace RcloneMountGUI
{
    partial class RcloneMount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RcloneMount));
            this.txtRLocation = new System.Windows.Forms.TextBox();
            this.lblRloneLocation = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.openFileDialogRclone = new System.Windows.Forms.OpenFileDialog();
            this.btnMount = new System.Windows.Forms.Button();
            this.lblMountOptions = new System.Windows.Forms.Label();
            this.comboBoxMount = new System.Windows.Forms.ComboBox();
            this.lblRemoteName = new System.Windows.Forms.Label();
            this.txtRemoteName = new System.Windows.Forms.TextBox();
            this.lblDriveLetter = new System.Windows.Forms.Label();
            this.txtDriveLetter = new System.Windows.Forms.TextBox();
            this.btnUnmount = new System.Windows.Forms.Button();
            this.linklblDocument = new System.Windows.Forms.LinkLabel();
            this.checkBoxRAAS = new System.Windows.Forms.CheckBox();
            this.notifyIconRclone = new System.Windows.Forms.NotifyIcon(this.components);
            this.backgroundWorkerRclone = new System.ComponentModel.BackgroundWorker();
            this.btnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRLocation
            // 
            this.txtRLocation.Location = new System.Drawing.Point(143, 16);
            this.txtRLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtRLocation.Name = "txtRLocation";
            this.txtRLocation.ReadOnly = true;
            this.txtRLocation.Size = new System.Drawing.Size(258, 26);
            this.txtRLocation.TabIndex = 0;
            this.txtRLocation.TabStop = false;
            // 
            // lblRloneLocation
            // 
            this.lblRloneLocation.AutoSize = true;
            this.lblRloneLocation.Location = new System.Drawing.Point(11, 19);
            this.lblRloneLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRloneLocation.Name = "lblRloneLocation";
            this.lblRloneLocation.Size = new System.Drawing.Size(128, 20);
            this.lblRloneLocation.TabIndex = 100;
            this.lblRloneLocation.Text = "Rclone Location:";
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSelect.Location = new System.Drawing.Point(405, 16);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(69, 26);
            this.btnSelect.TabIndex = 10;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // openFileDialogRclone
            // 
            this.openFileDialogRclone.FileName = "rclone";
            this.openFileDialogRclone.Filter = "Exe Files (.exe) |* .exe";
            // 
            // btnMount
            // 
            this.btnMount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMount.Location = new System.Drawing.Point(143, 155);
            this.btnMount.Margin = new System.Windows.Forms.Padding(2);
            this.btnMount.Name = "btnMount";
            this.btnMount.Size = new System.Drawing.Size(155, 35);
            this.btnMount.TabIndex = 11;
            this.btnMount.TabStop = false;
            this.btnMount.Text = "Mount";
            this.btnMount.UseVisualStyleBackColor = true;
            this.btnMount.Click += new System.EventHandler(this.btnMount_Click);
            // 
            // lblMountOptions
            // 
            this.lblMountOptions.AutoSize = true;
            this.lblMountOptions.Location = new System.Drawing.Point(21, 109);
            this.lblMountOptions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMountOptions.Name = "lblMountOptions";
            this.lblMountOptions.Size = new System.Drawing.Size(117, 20);
            this.lblMountOptions.TabIndex = 103;
            this.lblMountOptions.Text = "Mount Options:";
            // 
            // comboBoxMount
            // 
            this.comboBoxMount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMount.Items.AddRange(new object[] {
            "--vfs-cache-mode writes",
            "--vfs-cache-mode off",
            "--vfs-cache-mode minimal",
            "--vfs-cache-mode full"});
            this.comboBoxMount.Location = new System.Drawing.Point(143, 106);
            this.comboBoxMount.Name = "comboBoxMount";
            this.comboBoxMount.Size = new System.Drawing.Size(331, 28);
            this.comboBoxMount.TabIndex = 3;
            this.comboBoxMount.TabStop = false;
            // 
            // lblRemoteName
            // 
            this.lblRemoteName.AutoSize = true;
            this.lblRemoteName.Location = new System.Drawing.Point(23, 49);
            this.lblRemoteName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemoteName.Name = "lblRemoteName";
            this.lblRemoteName.Size = new System.Drawing.Size(116, 20);
            this.lblRemoteName.TabIndex = 101;
            this.lblRemoteName.Text = "Remote Name:";
            // 
            // txtRemoteName
            // 
            this.txtRemoteName.Location = new System.Drawing.Point(143, 46);
            this.txtRemoteName.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemoteName.Name = "txtRemoteName";
            this.txtRemoteName.Size = new System.Drawing.Size(331, 26);
            this.txtRemoteName.TabIndex = 1;
            this.txtRemoteName.TabStop = false;
            // 
            // lblDriveLetter
            // 
            this.lblDriveLetter.AutoSize = true;
            this.lblDriveLetter.Location = new System.Drawing.Point(43, 80);
            this.lblDriveLetter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDriveLetter.Name = "lblDriveLetter";
            this.lblDriveLetter.Size = new System.Drawing.Size(95, 20);
            this.lblDriveLetter.TabIndex = 102;
            this.lblDriveLetter.Text = "Drive Letter:";
            // 
            // txtDriveLetter
            // 
            this.txtDriveLetter.Location = new System.Drawing.Point(143, 76);
            this.txtDriveLetter.Margin = new System.Windows.Forms.Padding(2);
            this.txtDriveLetter.MaxLength = 1;
            this.txtDriveLetter.Name = "txtDriveLetter";
            this.txtDriveLetter.Size = new System.Drawing.Size(22, 26);
            this.txtDriveLetter.TabIndex = 2;
            this.txtDriveLetter.TabStop = false;
            this.txtDriveLetter.Text = "Z";
            // 
            // btnUnmount
            // 
            this.btnUnmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUnmount.Location = new System.Drawing.Point(319, 155);
            this.btnUnmount.Margin = new System.Windows.Forms.Padding(2);
            this.btnUnmount.Name = "btnUnmount";
            this.btnUnmount.Size = new System.Drawing.Size(155, 35);
            this.btnUnmount.TabIndex = 12;
            this.btnUnmount.TabStop = false;
            this.btnUnmount.Text = "Unmount";
            this.btnUnmount.UseVisualStyleBackColor = true;
            this.btnUnmount.Click += new System.EventHandler(this.btnUnmount_Click);
            // 
            // linklblDocument
            // 
            this.linklblDocument.AutoSize = true;
            this.linklblDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linklblDocument.Location = new System.Drawing.Point(395, 90);
            this.linklblDocument.Name = "linklblDocument";
            this.linklblDocument.Size = new System.Drawing.Size(79, 13);
            this.linklblDocument.TabIndex = 104;
            this.linklblDocument.TabStop = true;
            this.linklblDocument.Text = "Documentation";
            this.linklblDocument.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblDocument_LinkClicked);
            // 
            // checkBoxRAAS
            // 
            this.checkBoxRAAS.AutoSize = true;
            this.checkBoxRAAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxRAAS.Location = new System.Drawing.Point(15, 220);
            this.checkBoxRAAS.Name = "checkBoxRAAS";
            this.checkBoxRAAS.Size = new System.Drawing.Size(186, 24);
            this.checkBoxRAAS.TabIndex = 105;
            this.checkBoxRAAS.Text = "Auto Mount at Startup";
            this.checkBoxRAAS.UseVisualStyleBackColor = true;
            this.checkBoxRAAS.CheckedChanged += new System.EventHandler(this.checkBoxRAAS_CheckedChanged);
            // 
            // notifyIconRclone
            // 
            this.notifyIconRclone.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconRclone.BalloonTipText = "Mounted Succesfully";
            this.notifyIconRclone.BalloonTipTitle = "Rclone Mount";
            this.notifyIconRclone.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconRclone.Icon")));
            this.notifyIconRclone.Text = "Rclone Mount";
            this.notifyIconRclone.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconRclone_MouseDoubleClick);
            // 
            // backgroundWorkerRclone
            // 
            this.backgroundWorkerRclone.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRclone_DoWork);
            // 
            // btnConfig
            // 
            this.btnConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnConfig.Location = new System.Drawing.Point(15, 155);
            this.btnConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(108, 35);
            this.btnConfig.TabIndex = 106;
            this.btnConfig.TabStop = false;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // RcloneMount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 251);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.checkBoxRAAS);
            this.Controls.Add(this.linklblDocument);
            this.Controls.Add(this.btnUnmount);
            this.Controls.Add(this.txtDriveLetter);
            this.Controls.Add(this.lblDriveLetter);
            this.Controls.Add(this.txtRemoteName);
            this.Controls.Add(this.lblRemoteName);
            this.Controls.Add(this.comboBoxMount);
            this.Controls.Add(this.lblMountOptions);
            this.Controls.Add(this.btnMount);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblRloneLocation);
            this.Controls.Add(this.txtRLocation);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "RcloneMount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rclone Mount";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RcloneMount_FormClosed);
            this.Load += new System.EventHandler(this.RcloneMount_Load);
            this.Resize += new System.EventHandler(this.RcloneMount_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRLocation;
        private System.Windows.Forms.Label lblRloneLocation;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialogRclone;
        private System.Windows.Forms.Button btnMount;
        private System.Windows.Forms.Label lblMountOptions;
        private System.Windows.Forms.ComboBox comboBoxMount;
        private System.Windows.Forms.Label lblRemoteName;
        private System.Windows.Forms.TextBox txtRemoteName;
        private System.Windows.Forms.Label lblDriveLetter;
        private System.Windows.Forms.TextBox txtDriveLetter;
        private System.Windows.Forms.Button btnUnmount;
        private System.Windows.Forms.LinkLabel linklblDocument;
        private System.Windows.Forms.CheckBox checkBoxRAAS;
        private System.Windows.Forms.NotifyIcon notifyIconRclone;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRclone;
        private System.Windows.Forms.Button btnConfig;
    }
}

