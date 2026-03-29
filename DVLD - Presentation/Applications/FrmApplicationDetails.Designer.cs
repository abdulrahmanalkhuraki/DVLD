namespace DVLD.Applications
{
    partial class FrmApplicationDetails
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
            DVLD___Business.clsLocalDrivingLicenseApplication clsLocalDrivingLicenseApplication1 = new DVLD___Business.clsLocalDrivingLicenseApplication();
            this.ctrlApplicationCard1 = new DVLD.Applications.ctrlApplicationCard();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlApplicationCard1
            // 
            clsLocalDrivingLicenseApplication1.ApplicationDate = new System.DateTime(2026, 3, 29, 18, 43, 42, 137);
            clsLocalDrivingLicenseApplication1.ApplicationStatus = DVLD___Business.enApplicationStatus.New;
            clsLocalDrivingLicenseApplication1.ApplicationTypeID = 1;
            clsLocalDrivingLicenseApplication1.CreatedByUserID = -1;
            clsLocalDrivingLicenseApplication1.LastStatusDate = new System.DateTime(2026, 3, 29, 18, 43, 42, 137);
            clsLocalDrivingLicenseApplication1.LicenseClassID = -1;
            clsLocalDrivingLicenseApplication1.PaidFees = new decimal(new int[] {
            15,
            0,
            0,
            0});
            clsLocalDrivingLicenseApplication1.PersonID = -1;
            this.ctrlApplicationCard1.application = clsLocalDrivingLicenseApplication1;
            this.ctrlApplicationCard1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlApplicationCard1.Location = new System.Drawing.Point(12, 77);
            this.ctrlApplicationCard1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlApplicationCard1.Name = "ctrlApplicationCard1";
            this.ctrlApplicationCard1.Size = new System.Drawing.Size(716, 506);
            this.ctrlApplicationCard1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.icons8_close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(614, 590);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 37);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 53);
            this.label1.TabIndex = 14;
            this.label1.Text = "Application Details";
            // 
            // FrmApplicationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 634);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlApplicationCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmApplicationDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Details";
            this.Load += new System.EventHandler(this.FrmApplicationDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlApplicationCard ctrlApplicationCard1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}