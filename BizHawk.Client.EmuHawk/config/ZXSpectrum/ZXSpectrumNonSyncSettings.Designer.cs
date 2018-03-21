﻿namespace BizHawk.Client.EmuHawk
{
    partial class ZXSpectrumNonSyncSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZXSpectrumNonSyncSettings));
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.autoLoadcheckBox1 = new System.Windows.Forms.CheckBox();
            this.lblAutoLoadText = new System.Windows.Forms.Label();
            this.lblOSDVerbinfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.osdMessageVerbositycomboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(247, 145);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(60, 23);
            this.OkBtn.TabIndex = 3;
            this.OkBtn.Text = "&OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(313, 145);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(60, 23);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "&Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "ZX Spectrum Misc Non-Sync Settings";
            // 
            // autoLoadcheckBox1
            // 
            this.autoLoadcheckBox1.AutoSize = true;
            this.autoLoadcheckBox1.Location = new System.Drawing.Point(15, 52);
            this.autoLoadcheckBox1.Name = "autoLoadcheckBox1";
            this.autoLoadcheckBox1.Size = new System.Drawing.Size(103, 17);
            this.autoLoadcheckBox1.TabIndex = 21;
            this.autoLoadcheckBox1.Text = "Auto-Load Tape";
            this.autoLoadcheckBox1.UseVisualStyleBackColor = true;
            // 
            // lblAutoLoadText
            // 
            this.lblAutoLoadText.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoLoadText.Location = new System.Drawing.Point(175, 46);
            this.lblAutoLoadText.Name = "lblAutoLoadText";
            this.lblAutoLoadText.Size = new System.Drawing.Size(196, 30);
            this.lblAutoLoadText.TabIndex = 25;
            this.lblAutoLoadText.Text = "When enabled ZXHawk will attempt to control the tape device automatically when th" +
    "e correct traps are detected";
            this.lblAutoLoadText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOSDVerbinfo
            // 
            this.lblOSDVerbinfo.Font = new System.Drawing.Font("Lucida Console", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOSDVerbinfo.Location = new System.Drawing.Point(175, 107);
            this.lblOSDVerbinfo.Name = "lblOSDVerbinfo";
            this.lblOSDVerbinfo.Size = new System.Drawing.Size(196, 21);
            this.lblOSDVerbinfo.TabIndex = 28;
            this.lblOSDVerbinfo.Text = "null";
            this.lblOSDVerbinfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "OSD Message Verbosity:";
            // 
            // osdMessageVerbositycomboBox1
            // 
            this.osdMessageVerbositycomboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osdMessageVerbositycomboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.osdMessageVerbositycomboBox1.FormattingEnabled = true;
            this.osdMessageVerbositycomboBox1.Location = new System.Drawing.Point(12, 107);
            this.osdMessageVerbositycomboBox1.Name = "osdMessageVerbositycomboBox1";
            this.osdMessageVerbositycomboBox1.Size = new System.Drawing.Size(157, 21);
            this.osdMessageVerbositycomboBox1.TabIndex = 26;
            this.osdMessageVerbositycomboBox1.SelectionChangeCommitted += new System.EventHandler(this.OSDComboBox_SelectionChangeCommitted);
            // 
            // ZXSpectrumNonSyncSettings
            // 
            this.AcceptButton = this.OkBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(385, 180);
            this.Controls.Add(this.lblOSDVerbinfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.osdMessageVerbositycomboBox1);
            this.Controls.Add(this.lblAutoLoadText);
            this.Controls.Add(this.autoLoadcheckBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZXSpectrumNonSyncSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Other Non-Sync Settings";
            this.Load += new System.EventHandler(this.IntvControllerSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoLoadcheckBox1;
        private System.Windows.Forms.Label lblAutoLoadText;
        private System.Windows.Forms.Label lblOSDVerbinfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox osdMessageVerbositycomboBox1;
    }
}