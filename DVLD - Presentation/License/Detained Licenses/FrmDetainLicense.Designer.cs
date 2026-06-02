namespace DVLD.License.Detained_Licenses
{
    partial class FrmDetainLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetainLicense));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFineFees = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetainId = new System.Windows.Forms.Label();
            this.lblLicenseId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlLicenseFilter1 = new DVLD.License.ctrlLicenseFilter();
            this.lnklblLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnklblLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFineFees);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblDetainDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDetainId);
            this.groupBox1.Controls.Add(this.lblLicenseId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(13, 412);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(895, 153);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // tbFineFees
            // 
            this.tbFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFineFees.Location = new System.Drawing.Point(219, 109);
            this.tbFineFees.Name = "tbFineFees";
            this.tbFineFees.Size = new System.Drawing.Size(228, 27);
            this.tbFineFees.TabIndex = 31;
            this.tbFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFineFees_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Image = global::DVLD.Properties.Resources.icons8_fees_24;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(25, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 31);
            this.label11.TabIndex = 30;
            this.label11.Text = "Fine Fees";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(667, 73);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(30, 20);
            this.lblCreatedBy.TabIndex = 25;
            this.lblCreatedBy.Text = "???";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Image = global::DVLD.Properties.Resources.user1;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Location = new System.Drawing.Point(473, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 24);
            this.label12.TabIndex = 24;
            this.label12.Text = "Created By";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(219, 73);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(30, 20);
            this.lblDetainDate.TabIndex = 23;
            this.lblDetainDate.Text = "???";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(25, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 30);
            this.label6.TabIndex = 22;
            this.label6.Text = "Detain Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDetainId
            // 
            this.lblDetainId.AutoSize = true;
            this.lblDetainId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainId.Location = new System.Drawing.Point(219, 34);
            this.lblDetainId.Name = "lblDetainId";
            this.lblDetainId.Size = new System.Drawing.Size(30, 20);
            this.lblDetainId.TabIndex = 17;
            this.lblDetainId.Text = "???";
            // 
            // lblLicenseId
            // 
            this.lblLicenseId.AutoSize = true;
            this.lblLicenseId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseId.Location = new System.Drawing.Point(667, 34);
            this.lblLicenseId.Name = "lblLicenseId";
            this.lblLicenseId.Size = new System.Drawing.Size(30, 20);
            this.lblLicenseId.TabIndex = 17;
            this.lblLicenseId.Text = "???";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DVLD.Properties.Resources.icons8_id_24;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Detain ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DVLD.Properties.Resources.icons8_id_24;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(473, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 30);
            this.label5.TabIndex = 16;
            this.label5.Text = "License ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctrlLicenseFilter1
            // 
            this.ctrlLicenseFilter1.Location = new System.Drawing.Point(7, 12);
            this.ctrlLicenseFilter1.Name = "ctrlLicenseFilter1";
            this.ctrlLicenseFilter1.Size = new System.Drawing.Size(913, 394);
            this.ctrlLicenseFilter1.TabIndex = 0;
            this.ctrlLicenseFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseFilter1_OnLicenseSelected);
            // 
            // lnklblLicenseInfo
            // 
            this.lnklblLicenseInfo.AutoSize = true;
            this.lnklblLicenseInfo.Enabled = false;
            this.lnklblLicenseInfo.Location = new System.Drawing.Point(159, 571);
            this.lnklblLicenseInfo.Name = "lnklblLicenseInfo";
            this.lnklblLicenseInfo.Size = new System.Drawing.Size(172, 16);
            this.lnklblLicenseInfo.TabIndex = 55;
            this.lnklblLicenseInfo.TabStop = true;
            this.lnklblLicenseInfo.Text = "Show Detained License Info";
            this.lnklblLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicenseInfo_LinkClicked);
            // 
            // lnklblLicensesHistory
            // 
            this.lnklblLicensesHistory.AutoSize = true;
            this.lnklblLicensesHistory.Enabled = false;
            this.lnklblLicensesHistory.Location = new System.Drawing.Point(13, 571);
            this.lnklblLicensesHistory.Name = "lnklblLicensesHistory";
            this.lnklblLicensesHistory.Size = new System.Drawing.Size(142, 16);
            this.lnklblLicensesHistory.TabIndex = 54;
            this.lnklblLicensesHistory.TabStop = true;
            this.lnklblLicensesHistory.Text = "Show Licenses History";
            this.lnklblLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.icons8_close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(612, 571);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 43);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Enabled = false;
            this.btnDetainLicense.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetainLicense.Image = ((System.Drawing.Image)(resources.GetObject("btnDetainLicense.Image")));
            this.btnDetainLicense.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetainLicense.Location = new System.Drawing.Point(728, 571);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(180, 43);
            this.btnDetainLicense.TabIndex = 52;
            this.btnDetainLicense.Text = "Detain License";
            this.btnDetainLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetainLicense.UseVisualStyleBackColor = false;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FrmDetainLicense
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(932, 625);
            this.Controls.Add(this.lnklblLicenseInfo);
            this.Controls.Add(this.lnklblLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlLicenseFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetainLicense";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain License";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLicenseFilter ctrlLicenseFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDetainId;
        private System.Windows.Forms.Label lblLicenseId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFineFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.LinkLabel lnklblLicenseInfo;
        private System.Windows.Forms.LinkLabel lnklblLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}