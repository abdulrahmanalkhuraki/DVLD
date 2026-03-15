namespace DVLD.Person
{
    partial class FrmAddEditPerson
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNationalNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbThirdname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSecondname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPersonPhoto = new System.Windows.Forms.PictureBox();
            this.lblPersonId = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ofdPersonPhoto = new System.Windows.Forms.OpenFileDialog();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPhoto)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbNationalNumber);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbLastname);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbThirdname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbSecondname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbFirstname);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 231);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 182);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Identification";
            // 
            // cbCountry
            // 
            this.cbCountry.Font = new System.Drawing.Font("Myanmar Text", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Items.AddRange(new object[] {
            "Person ID",
            "National Number",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gender",
            "Phone",
            "Email",
            "Nationality Country"});
            this.cbCountry.Location = new System.Drawing.Point(572, 129);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(157, 35);
            this.cbCountry.TabIndex = 8;
            this.cbCountry.Enter += new System.EventHandler(this.tbFirstname_Enter);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Image = global::DVLD.Properties.Resources.icons8_country_24;
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(460, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 24);
            this.label15.TabIndex = 27;
            this.label15.Text = "Country";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbFemale);
            this.groupBox3.Controls.Add(this.rbMale);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(171, 119);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(281, 54);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // rbFemale
            // 
            this.rbFemale.Image = global::DVLD.Properties.Resources.icons8_female_24;
            this.rbFemale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbFemale.Location = new System.Drawing.Point(147, 17);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(123, 31);
            this.rbFemale.TabIndex = 7;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.Checked = true;
            this.rbMale.Image = global::DVLD.Properties.Resources.icons8_male_24;
            this.rbMale.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbMale.Location = new System.Drawing.Point(30, 15);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(111, 33);
            this.rbMale.TabIndex = 6;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.CheckedChanged += new System.EventHandler(this.rbMale_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(89, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Gender";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbNationalNumber
            // 
            this.tbNationalNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNumber.Location = new System.Drawing.Point(171, 79);
            this.tbNationalNumber.MaxLength = 20;
            this.tbNationalNumber.Name = "tbNationalNumber";
            this.tbNationalNumber.Size = new System.Drawing.Size(558, 27);
            this.tbNationalNumber.TabIndex = 4;
            this.tbNationalNumber.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbNationalNumber.Validating += new System.ComponentModel.CancelEventHandler(this.tbNationalNumber_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(647, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Last";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbLastname
            // 
            this.tbLastname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastname.Location = new System.Drawing.Point(600, 46);
            this.tbLastname.MaxLength = 20;
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(127, 27);
            this.tbLastname.TabIndex = 3;
            this.tbLastname.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbLastname.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(500, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Third";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbThirdname
            // 
            this.tbThirdname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThirdname.Location = new System.Drawing.Point(457, 46);
            this.tbThirdname.MaxLength = 20;
            this.tbThirdname.Name = "tbThirdname";
            this.tbThirdname.Size = new System.Drawing.Size(127, 27);
            this.tbThirdname.TabIndex = 2;
            this.tbThirdname.Enter += new System.EventHandler(this.tbFirstname_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(351, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Second";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSecondname
            // 
            this.tbSecondname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSecondname.Location = new System.Drawing.Point(314, 46);
            this.tbSecondname.MaxLength = 20;
            this.tbSecondname.Name = "tbSecondname";
            this.tbSecondname.Size = new System.Drawing.Size(127, 27);
            this.tbSecondname.TabIndex = 1;
            this.tbSecondname.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbSecondname.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(217, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "First";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbFirstname
            // 
            this.tbFirstname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstname.Location = new System.Drawing.Point(171, 46);
            this.tbFirstname.MaxLength = 20;
            this.tbFirstname.Name = "tbFirstname";
            this.tbFirstname.Size = new System.Drawing.Size(127, 27);
            this.tbFirstname.TabIndex = 0;
            this.tbFirstname.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbFirstname.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Image = global::DVLD.Properties.Resources.icons8_national_24;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(6, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "National No.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = global::DVLD.Properties.Resources.icons8_name_24;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(8, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnClearImage);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.pbPersonPhoto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(760, 170);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person Photo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(181, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Supported: JPG, PNG (max 2MB)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnClearImage
            // 
            this.btnClearImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearImage.Image = global::DVLD.Properties.Resources.person_boy__2_;
            this.btnClearImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearImage.Location = new System.Drawing.Point(296, 77);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(156, 32);
            this.btnClearImage.TabIndex = 14;
            this.btnClearImage.Text = "Remove Photo";
            this.btnClearImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Visible = false;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Image = global::DVLD.Properties.Resources.icons8_browse_24;
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBrowse.Location = new System.Drawing.Point(185, 77);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(105, 32);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(181, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Upload a photo for the person";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbPersonPhoto
            // 
            this.pbPersonPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbPersonPhoto.Image = global::DVLD.Properties.Resources.icons8_person_100__1_;
            this.pbPersonPhoto.Location = new System.Drawing.Point(31, 42);
            this.pbPersonPhoto.Name = "pbPersonPhoto";
            this.pbPersonPhoto.Size = new System.Drawing.Size(120, 120);
            this.pbPersonPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonPhoto.TabIndex = 11;
            this.pbPersonPhoto.TabStop = false;
            // 
            // lblPersonId
            // 
            this.lblPersonId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonId.Location = new System.Drawing.Point(426, 28);
            this.lblPersonId.Name = "lblPersonId";
            this.lblPersonId.Size = new System.Drawing.Size(78, 24);
            this.lblPersonId.TabIndex = 14;
            this.lblPersonId.Text = "N/A";
            this.lblPersonId.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbAddress);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.dtpDateOfBirth);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.tbPhone);
            this.groupBox4.Controls.Add(this.tbEmail);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 419);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(760, 230);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Contact and Birth";
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(171, 151);
            this.tbAddress.MaxLength = 500;
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(558, 67);
            this.tbAddress.TabIndex = 4;
            this.tbAddress.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbAddress.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Image = global::DVLD.Properties.Resources.icons8_address_24;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Location = new System.Drawing.Point(8, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(141, 24);
            this.label19.TabIndex = 32;
            this.label19.Text = "Address";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "yyyy-MM-dd";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(171, 114);
            this.dtpDateOfBirth.MaxDate = new System.DateTime(2100, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(558, 31);
            this.dtpDateOfBirth.TabIndex = 3;
            this.dtpDateOfBirth.Enter += new System.EventHandler(this.tbFirstname_Enter);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Image = global::DVLD.Properties.Resources.icons8_date_24;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.Location = new System.Drawing.Point(8, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(141, 24);
            this.label17.TabIndex = 30;
            this.label17.Text = "Date Of Birth";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Image = global::DVLD.Properties.Resources.icons8_phone_24;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label13.Location = new System.Drawing.Point(6, 80);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 24);
            this.label13.TabIndex = 29;
            this.label13.Text = "Phone";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.Location = new System.Drawing.Point(171, 79);
            this.tbPhone.MaxLength = 20;
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(558, 27);
            this.tbPhone.TabIndex = 2;
            this.tbPhone.Enter += new System.EventHandler(this.tbFirstname_Enter);
            this.tbPhone.Validating += new System.ComponentModel.CancelEventHandler(this.tbFirstname_Validating);
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(171, 42);
            this.tbEmail.MaxLength = 50;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(558, 27);
            this.tbEmail.TabIndex = 1;
            this.tbEmail.Enter += new System.EventHandler(this.tbFirstname_Enter);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Image = global::DVLD.Properties.Resources.icons8_email_24;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(8, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 24);
            this.label10.TabIndex = 12;
            this.label10.Text = "Email";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ofdPersonPhoto
            // 
            this.ofdPersonPhoto.FileName = "openFileDialog1";
            this.ofdPersonPhoto.Filter = "Image Files|*.png;*.jpg;";
            this.ofdPersonPhoto.Title = "Choose Person Photo";
            // 
            // btnClearForm
            // 
            this.btnClearForm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearForm.Image = global::DVLD.Properties.Resources.icons8_clear_24;
            this.btnClearForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearForm.Location = new System.Drawing.Point(464, 655);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(98, 43);
            this.btnClearForm.TabIndex = 4;
            this.btnClearForm.Text = "Clear";
            this.btnClearForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(100)))));
            this.btnSaveRecord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveRecord.ForeColor = System.Drawing.Color.White;
            this.btnSaveRecord.Image = global::DVLD.Properties.Resources.icons8_save_24;
            this.btnSaveRecord.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveRecord.Location = new System.Drawing.Point(568, 655);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(208, 43);
            this.btnSaveRecord.TabIndex = 3;
            this.btnSaveRecord.Text = "Save Person Record";
            this.btnSaveRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveRecord.UseVisualStyleBackColor = false;
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DVLD.Properties.Resources.icons8_id_24;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(284, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Person ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Visible = false;
            // 
            // FrmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 710);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnSaveRecord);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblPersonId);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAddEditPerson";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAddEditPerson";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonPhoto)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbFirstname;
        private System.Windows.Forms.PictureBox pbPersonPhoto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbThirdname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSecondname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPersonId;
        private System.Windows.Forms.TextBox tbNationalNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSaveRecord;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.OpenFileDialog ofdPersonPhoto;
    }
}