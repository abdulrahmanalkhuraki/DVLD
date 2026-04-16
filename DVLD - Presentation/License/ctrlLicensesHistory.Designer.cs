namespace DVLD.License
{
    partial class ctrlLicensesHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbLocal = new System.Windows.Forms.TabPage();
            this.lblLocalRecordsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocal = new System.Windows.Forms.DataGridView();
            this.tbInternational = new System.Windows.Forms.TabPage();
            this.lblInternationalRecordsCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInternational = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).BeginInit();
            this.tbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 539);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licesnes";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbLocal);
            this.tabControl1.Controls.Add(this.tbInternational);
            this.tabControl1.Location = new System.Drawing.Point(17, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(618, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // tbLocal
            // 
            this.tbLocal.Controls.Add(this.lblLocalRecordsCount);
            this.tbLocal.Controls.Add(this.label3);
            this.tbLocal.Controls.Add(this.label2);
            this.tbLocal.Controls.Add(this.dgvLocal);
            this.tbLocal.Location = new System.Drawing.Point(4, 26);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocal.Size = new System.Drawing.Size(610, 476);
            this.tbLocal.TabIndex = 0;
            this.tbLocal.Text = "Local";
            this.tbLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalRecordsCount
            // 
            this.lblLocalRecordsCount.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblLocalRecordsCount.Location = new System.Drawing.Point(98, 439);
            this.lblLocalRecordsCount.Name = "lblLocalRecordsCount";
            this.lblLocalRecordsCount.Size = new System.Drawing.Size(78, 19);
            this.lblLocalRecordsCount.TabIndex = 12;
            this.lblLocalRecordsCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "# Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(220, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Local License History";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvLocal
            // 
            this.dgvLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocal.Location = new System.Drawing.Point(19, 47);
            this.dgvLocal.Name = "dgvLocal";
            this.dgvLocal.RowHeadersWidth = 51;
            this.dgvLocal.RowTemplate.Height = 24;
            this.dgvLocal.Size = new System.Drawing.Size(572, 387);
            this.dgvLocal.TabIndex = 0;
            // 
            // tbInternational
            // 
            this.tbInternational.Controls.Add(this.lblInternationalRecordsCount);
            this.tbInternational.Controls.Add(this.label4);
            this.tbInternational.Controls.Add(this.label5);
            this.tbInternational.Controls.Add(this.dgvInternational);
            this.tbInternational.Location = new System.Drawing.Point(4, 26);
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternational.Size = new System.Drawing.Size(610, 476);
            this.tbInternational.TabIndex = 1;
            this.tbInternational.Text = "International";
            this.tbInternational.UseVisualStyleBackColor = true;
            // 
            // lblInternationalRecordsCount
            // 
            this.lblInternationalRecordsCount.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblInternationalRecordsCount.Location = new System.Drawing.Point(98, 439);
            this.lblInternationalRecordsCount.Name = "lblInternationalRecordsCount";
            this.lblInternationalRecordsCount.Size = new System.Drawing.Size(78, 19);
            this.lblInternationalRecordsCount.TabIndex = 16;
            this.lblInternationalRecordsCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "# Records";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(191, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "International License History";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvInternational
            // 
            this.dgvInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternational.Location = new System.Drawing.Point(19, 47);
            this.dgvInternational.Name = "dgvInternational";
            this.dgvInternational.RowHeadersWidth = 51;
            this.dgvInternational.RowTemplate.Height = 24;
            this.dgvInternational.Size = new System.Drawing.Size(572, 387);
            this.dgvInternational.TabIndex = 13;
            // 
            // ctrlLicensesHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlLicensesHistory";
            this.Size = new System.Drawing.Size(656, 539);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbLocal.ResumeLayout(false);
            this.tbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocal)).EndInit();
            this.tbInternational.ResumeLayout(false);
            this.tbInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternational)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbLocal;
        private System.Windows.Forms.TabPage tbInternational;
        private System.Windows.Forms.DataGridView dgvLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLocalRecordsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalRecordsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvInternational;
    }
}
