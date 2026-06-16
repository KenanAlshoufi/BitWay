namespace Bank_System
{
    partial class frmEditPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstname = new Introduction_to_Custom_Controls.InputTextBox();
            this.txtlastname = new Introduction_to_Custom_Controls.InputTextBox();
            this.txtSecondname = new Introduction_to_Custom_Controls.InputTextBox();
            this.txtThirdname = new Introduction_to_Custom_Controls.InputTextBox();
            this.txtEmail = new Introduction_to_Custom_Controls.InputTextBox();
            this.txtPhone = new Introduction_to_Custom_Controls.InputTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbNationalty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lLDeleteImage = new System.Windows.Forms.LinkLabel();
            this.ofdSelectImage = new System.Windows.Forms.OpenFileDialog();
            this.llSetPhoto = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnEditInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(-8, -4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Edit your information";
            // 
            // txtFirstname
            // 
            this.txtFirstname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtFirstname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstname.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstname.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFirstname.Location = new System.Drawing.Point(249, 106);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.NameTextBox = "First name";
            this.txtFirstname.Size = new System.Drawing.Size(138, 27);
            this.txtFirstname.TabIndex = 6;
            this.txtFirstname.Text = "First name";
            this.txtFirstname.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextbox);
            // 
            // txtlastname
            // 
            this.txtlastname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtlastname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlastname.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlastname.ForeColor = System.Drawing.Color.DarkGray;
            this.txtlastname.Location = new System.Drawing.Point(570, 178);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.NameTextBox = "Last name";
            this.txtlastname.Size = new System.Drawing.Size(138, 27);
            this.txtlastname.TabIndex = 7;
            this.txtlastname.Text = "Last name";
            this.txtlastname.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextbox);
            // 
            // txtSecondname
            // 
            this.txtSecondname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtSecondname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondname.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondname.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSecondname.Location = new System.Drawing.Point(570, 106);
            this.txtSecondname.Name = "txtSecondname";
            this.txtSecondname.NameTextBox = "Second name";
            this.txtSecondname.Size = new System.Drawing.Size(138, 27);
            this.txtSecondname.TabIndex = 8;
            this.txtSecondname.Text = "Second name";
            this.txtSecondname.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextbox);
            // 
            // txtThirdname
            // 
            this.txtThirdname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtThirdname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThirdname.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThirdname.ForeColor = System.Drawing.Color.DarkGray;
            this.txtThirdname.Location = new System.Drawing.Point(249, 178);
            this.txtThirdname.Name = "txtThirdname";
            this.txtThirdname.NameTextBox = "Third name";
            this.txtThirdname.Size = new System.Drawing.Size(138, 27);
            this.txtThirdname.TabIndex = 9;
            this.txtThirdname.Text = "Third name";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.DarkGray;
            this.txtEmail.Location = new System.Drawing.Point(570, 260);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NameTextBox = "Email";
            this.txtEmail.Size = new System.Drawing.Size(138, 27);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.Text = "Email";
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPhone.Location = new System.Drawing.Point(249, 265);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.NameTextBox = "Phone number";
            this.txtPhone.Size = new System.Drawing.Size(138, 27);
            this.txtPhone.TabIndex = 12;
            this.txtPhone.Text = "Phone number";
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            this.txtPhone.Validating += new System.ComponentModel.CancelEventHandler(this.ValidateEmptyTextbox);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbNationalty
            // 
            this.cbNationalty.BackColor = System.Drawing.Color.White;
            this.cbNationalty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbNationalty.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNationalty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(38)))));
            this.cbNationalty.FormattingEnabled = true;
            this.cbNationalty.Location = new System.Drawing.Point(249, 354);
            this.cbNationalty.Name = "cbNationalty";
            this.cbNationalty.Size = new System.Drawing.Size(138, 27);
            this.cbNationalty.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(152, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "First name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(453, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(450, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Second Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(147, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "Thrid Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(127, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "Phone Number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(469, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(148, 356);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Nationalty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(-3, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(279, 21);
            this.label9.TabIndex = 21;
            this.label9.Text = "Update Your Personal Information :";
            // 
            // lLDeleteImage
            // 
            this.lLDeleteImage.AutoSize = true;
            this.lLDeleteImage.BackColor = System.Drawing.Color.Transparent;
            this.lLDeleteImage.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLDeleteImage.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(38)))));
            this.lLDeleteImage.Location = new System.Drawing.Point(25, 293);
            this.lLDeleteImage.Name = "lLDeleteImage";
            this.lLDeleteImage.Size = new System.Drawing.Size(78, 16);
            this.lLDeleteImage.TabIndex = 23;
            this.lLDeleteImage.TabStop = true;
            this.lLDeleteImage.Text = "Delete Photo";
            this.lLDeleteImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLDeleteImage_LinkClicked);
            // 
            // ofdSelectImage
            // 
            this.ofdSelectImage.FileName = "openFileDialog1";
            // 
            // llSetPhoto
            // 
            this.llSetPhoto.AutoSize = true;
            this.llSetPhoto.BackColor = System.Drawing.Color.Transparent;
            this.llSetPhoto.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetPhoto.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(172)))), ((int)(((byte)(38)))));
            this.llSetPhoto.Location = new System.Drawing.Point(33, 266);
            this.llSetPhoto.Name = "llSetPhoto";
            this.llSetPhoto.Size = new System.Drawing.Size(61, 16);
            this.llSetPhoto.TabIndex = 24;
            this.llSetPhoto.TabStop = true;
            this.llSetPhoto.Text = "Set Photo";
            this.llSetPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lLSetImage_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::Bank_System.Properties.Resources.bookmark;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(662, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 37);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.Transparent;
            this.pbImage.Image = global::Bank_System.Properties.Resources.user__1_;
            this.pbImage.Location = new System.Drawing.Point(3, 99);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(143, 159);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 22;
            this.pbImage.TabStop = false;
            // 
            // btnEditInfo
            // 
            this.btnEditInfo.BackgroundImage = global::Bank_System.Properties.Resources.edit__1_;
            this.btnEditInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEditInfo.FlatAppearance.BorderSize = 0;
            this.btnEditInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditInfo.Location = new System.Drawing.Point(332, 8);
            this.btnEditInfo.Name = "btnEditInfo";
            this.btnEditInfo.Size = new System.Drawing.Size(31, 24);
            this.btnEditInfo.TabIndex = 5;
            this.btnEditInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Bank_System.Properties.Resources.Close;
            this.pictureBox1.Location = new System.Drawing.Point(742, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.BackgroundImage = global::Bank_System.Properties.Resources.Bitway_Image_5;
            this.ClientSize = new System.Drawing.Size(782, 456);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.llSetPhoto);
            this.Controls.Add(this.lLDeleteImage);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNationalty);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtThirdname);
            this.Controls.Add(this.txtSecondname);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.btnEditInfo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEditPerson";
            this.Load += new System.EventHandler(this.frmEditPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditInfo;
        private Introduction_to_Custom_Controls.InputTextBox txtFirstname;
        private Introduction_to_Custom_Controls.InputTextBox txtlastname;
        private Introduction_to_Custom_Controls.InputTextBox txtSecondname;
        private Introduction_to_Custom_Controls.InputTextBox txtThirdname;
        private Introduction_to_Custom_Controls.InputTextBox txtEmail;
        private Introduction_to_Custom_Controls.InputTextBox txtPhone;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cbNationalty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.LinkLabel lLDeleteImage;
        private System.Windows.Forms.LinkLabel llSetPhoto;
        private System.Windows.Forms.OpenFileDialog ofdSelectImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}