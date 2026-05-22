namespace DVLD.Applications.Renew_Applications
{
    partial class FrmRenewLicenseApplication
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
            this.lnklblLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRenewLicense = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLicenseFees = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRenewedLicenseID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRenewLicenseApplicationID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ctrlLicenseFilter1 = new DVLD.License.ctrlLicenseFilter();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnklblLicenseInfo
            // 
            this.lnklblLicenseInfo.AutoSize = true;
            this.lnklblLicenseInfo.Enabled = false;
            this.lnklblLicenseInfo.Location = new System.Drawing.Point(151, 676);
            this.lnklblLicenseInfo.Name = "lnklblLicenseInfo";
            this.lnklblLicenseInfo.Size = new System.Drawing.Size(141, 17);
            this.lnklblLicenseInfo.TabIndex = 51;
            this.lnklblLicenseInfo.TabStop = true;
            this.lnklblLicenseInfo.Text = "Show New License Info";
            this.lnklblLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicenseInfo_LinkClicked_1);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(5, 676);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(136, 17);
            this.lnklblLicensesHistory.TabIndex = 50;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show Licenses History";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.icons8_close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(604, 676);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 43);
            this.btnClose.TabIndex = 49;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRenewLicense
            // 
            this.btnRenewLicense.Enabled = false;
            this.btnRenewLicense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenewLicense.Image = global::DVLD.Properties.Resources.id__2_;
            this.btnRenewLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenewLicense.Location = new System.Drawing.Point(720, 676);
            this.btnRenewLicense.Name = "btnRenewLicense";
            this.btnRenewLicense.Size = new System.Drawing.Size(180, 43);
            this.btnRenewLicense.TabIndex = 48;
            this.btnRenewLicense.Text = "Renew License";
            this.btnRenewLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenewLicense.UseVisualStyleBackColor = false;
            this.btnRenewLicense.Click += new System.EventHandler(this.btnRenewLicense_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNotes);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblTotalFees);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblLicenseFees);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblExpirationDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblIssueDate);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblOldLicenseID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblRenewedLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblRenewLicenseApplicationID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(4, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 272);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(270, 225);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(616, 41);
            this.tbNotes.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::DVLD.Properties.Resources.icons8_notes_24;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(23, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(195, 24);
            this.label11.TabIndex = 28;
            this.label11.Text = "Notes";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.Location = new System.Drawing.Point(639, 150);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(30, 20);
            this.lblTotalFees.TabIndex = 27;
            this.lblTotalFees.Text = "???";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Image = global::DVLD.Properties.Resources.icons8_fees_24;
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(392, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 24);
            this.label8.TabIndex = 26;
            this.label8.Text = "Total Fees";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLicenseFees
            // 
            this.lblLicenseFees.AutoSize = true;
            this.lblLicenseFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseFees.Location = new System.Drawing.Point(270, 186);
            this.lblLicenseFees.Name = "lblLicenseFees";
            this.lblLicenseFees.Size = new System.Drawing.Size(30, 20);
            this.lblLicenseFees.TabIndex = 25;
            this.lblLicenseFees.Text = "???";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DVLD.Properties.Resources.icons8_fees_24;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(23, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "License Fees";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(639, 186);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(30, 20);
            this.lblCreatedBy.TabIndex = 23;
            this.lblCreatedBy.Text = "???";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::DVLD.Properties.Resources.user1;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(392, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(195, 24);
            this.label12.TabIndex = 22;
            this.label12.Text = "Created By";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(270, 150);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(30, 20);
            this.lblApplicationFees.TabIndex = 21;
            this.lblApplicationFees.Text = "???";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Image = global::DVLD.Properties.Resources.icons8_fees_24;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(23, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(195, 24);
            this.label14.TabIndex = 20;
            this.label14.Text = "Application Fees";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirationDate.Location = new System.Drawing.Point(639, 114);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(30, 20);
            this.lblExpirationDate.TabIndex = 19;
            this.lblExpirationDate.Text = "???";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(392, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "Expiration Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(270, 114);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(30, 20);
            this.lblIssueDate.TabIndex = 17;
            this.lblIssueDate.Text = "???";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(23, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(195, 24);
            this.label10.TabIndex = 16;
            this.label10.Text = "IssueDate";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.Location = new System.Drawing.Point(639, 78);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(30, 20);
            this.lblOldLicenseID.TabIndex = 15;
            this.lblOldLicenseID.Text = "???";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Image = global::DVLD.Properties.Resources.id__8_2;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(392, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 24);
            this.label4.TabIndex = 14;
            this.label4.Text = "Old License ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRenewedLicenseID
            // 
            this.lblRenewedLicenseID.AutoSize = true;
            this.lblRenewedLicenseID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewedLicenseID.Location = new System.Drawing.Point(639, 42);
            this.lblRenewedLicenseID.Name = "lblRenewedLicenseID";
            this.lblRenewedLicenseID.Size = new System.Drawing.Size(30, 20);
            this.lblRenewedLicenseID.TabIndex = 13;
            this.lblRenewedLicenseID.Text = "???";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::DVLD.Properties.Resources.id__8_2;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(392, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Renewed License  ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(270, 78);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(30, 20);
            this.lblApplicationDate.TabIndex = 11;
            this.lblApplicationDate.Text = "???";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(23, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(195, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "Application Date";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRenewLicenseApplicationID
            // 
            this.lblRenewLicenseApplicationID.AutoSize = true;
            this.lblRenewLicenseApplicationID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenewLicenseApplicationID.Location = new System.Drawing.Point(270, 42);
            this.lblRenewLicenseApplicationID.Name = "lblRenewLicenseApplicationID";
            this.lblRenewLicenseApplicationID.Size = new System.Drawing.Size(30, 20);
            this.lblRenewLicenseApplicationID.TabIndex = 9;
            this.lblRenewLicenseApplicationID.Text = "???";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVLD.Properties.Resources.icons8_id_24;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(23, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(195, 24);
            this.label7.TabIndex = 8;
            this.label7.Text = "R.L Application  ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(906, 394);
            this.ctrlLicenseFilter1.TabIndex = 0;
            this.ctrlLicenseFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseFilter1_OnLicenseSelected);
            // 
            // FrmRenewLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 724);
            this.Controls.Add(this.lnklblLicenseInfo);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRenewLicense);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRenewLicenseApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew License Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License.ctrlLicenseFilter ctrlLicenseFilter1;
        private System.Windows.Forms.LinkLabel lnklblLicenseInfo;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRenewLicense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRenewedLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRenewLicenseApplicationID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblLicenseFees;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label11;
    }
}