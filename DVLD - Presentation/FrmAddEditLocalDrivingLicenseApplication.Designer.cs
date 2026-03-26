namespace DVLD
{
    partial class FrmAddEditLocalDrivingLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPersonInfo = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new DVLD.Person.ctrlPersonCardWithFilter();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbLoginInfo = new System.Windows.Forms.TabPage();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.cbLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tbPersonInfo.SuspendLayout();
            this.tbLoginInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPersonInfo);
            this.tabControl1.Controls.Add(this.tbLoginInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(678, 659);
            this.tabControl1.TabIndex = 1;
            // 
            // tbPersonInfo
            // 
            this.tbPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tbPersonInfo.Controls.Add(this.btnNext);
            this.tbPersonInfo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPersonInfo.Location = new System.Drawing.Point(4, 26);
            this.tbPersonInfo.Name = "tbPersonInfo";
            this.tbPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonInfo.Size = new System.Drawing.Size(670, 629);
            this.tbPersonInfo.TabIndex = 0;
            this.tbPersonInfo.Text = "Person Info";
            this.tbPersonInfo.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(3, 7);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(660, 560);
            this.ctrlPersonCardWithFilter1.TabIndex = 6;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::DVLD.Properties.Resources.icons8_next_24;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(564, 574);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(98, 43);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // tbLoginInfo
            // 
            this.tbLoginInfo.Controls.Add(this.btnBack);
            this.tbLoginInfo.Controls.Add(this.btnClose);
            this.tbLoginInfo.Controls.Add(this.btnSaveRecord);
            this.tbLoginInfo.Controls.Add(this.panel1);
            this.tbLoginInfo.Location = new System.Drawing.Point(4, 26);
            this.tbLoginInfo.Name = "tbLoginInfo";
            this.tbLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbLoginInfo.Size = new System.Drawing.Size(670, 629);
            this.tbLoginInfo.TabIndex = 1;
            this.tbLoginInfo.Text = "Login Info";
            this.tbLoginInfo.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::DVLD.Properties.Resources.icons8_Back_24;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.Location = new System.Drawing.Point(59, 571);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(98, 43);
            this.btnBack.TabIndex = 40;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.icons8_close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(289, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 43);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRecord.Image = global::DVLD.Properties.Resources.id__2_;
            this.btnSaveRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveRecord.Location = new System.Drawing.Point(411, 571);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(208, 43);
            this.btnSaveRecord.TabIndex = 41;
            this.btnSaveRecord.Text = "Save Application";
            this.btnSaveRecord.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveRecord.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCreatedBy);
            this.panel1.Controls.Add(this.lblApplicationFees);
            this.panel1.Controls.Add(this.cbLicenseClass);
            this.panel1.Controls.Add(this.lblApplicationDate);
            this.panel1.Controls.Add(this.lblApplicationID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblConfirmPassword);
            this.panel1.Controls.Add(this.lblPassword);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(59, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 440);
            this.panel1.TabIndex = 40;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(238, 332);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(70, 20);
            this.lblCreatedBy.TabIndex = 43;
            this.lblCreatedBy.Text = "Unknown";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(238, 290);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(70, 20);
            this.lblApplicationFees.TabIndex = 42;
            this.lblApplicationFees.Text = "Unknown";
            // 
            // cbLicenseClass
            // 
            this.cbLicenseClass.FormattingEnabled = true;
            this.cbLicenseClass.Location = new System.Drawing.Point(238, 246);
            this.cbLicenseClass.Name = "cbLicenseClass";
            this.cbLicenseClass.Size = new System.Drawing.Size(315, 25);
            this.cbLicenseClass.TabIndex = 41;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(238, 207);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(70, 20);
            this.lblApplicationDate.TabIndex = 40;
            this.lblApplicationDate.Text = "Unknown";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.Location = new System.Drawing.Point(238, 164);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(70, 20);
            this.lblApplicationID.TabIndex = 38;
            this.lblApplicationID.Text = "Unknown";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::DVLD.Properties.Resources.icons8_id_24;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(24, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "D.L Application ID";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Image = global::DVLD.Properties.Resources.user1;
            this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStatus.Location = new System.Drawing.Point(24, 330);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(186, 25);
            this.lblStatus.TabIndex = 36;
            this.lblStatus.Text = "Created By";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Image = global::DVLD.Properties.Resources.icons8_fees_24;
            this.lblConfirmPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblConfirmPassword.Location = new System.Drawing.Point(24, 288);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(186, 25);
            this.lblConfirmPassword.TabIndex = 35;
            this.lblConfirmPassword.Text = "Application Fees";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Image = global::DVLD.Properties.Resources.id__12_;
            this.lblPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPassword.Location = new System.Drawing.Point(24, 246);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(186, 25);
            this.lblPassword.TabIndex = 33;
            this.lblPassword.Text = "License Class";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(24, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 24);
            this.label10.TabIndex = 32;
            this.label10.Text = "Application Date";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.id__11_;
            this.pictureBox1.Location = new System.Drawing.Point(232, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAddEditLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 659);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditLocalDrivingLicenseApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditLocalDrivingLicenseApplication";
            this.tabControl1.ResumeLayout(false);
            this.tbPersonInfo.ResumeLayout(false);
            this.tbLoginInfo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbPersonInfo;
        private Person.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tbLoginInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveRecord;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.ComboBox cbLicenseClass;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
    }
}