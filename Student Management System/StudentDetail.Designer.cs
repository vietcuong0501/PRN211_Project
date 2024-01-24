namespace Student_Management_System
{
    partial class StudentDetail
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
            lbStudentID = new Label();
            lbStudentName = new Label();
            lbGender = new Label();
            lbDOB = new Label();
            lbMajor = new Label();
            txtStudentID = new TextBox();
            txtStudentName = new TextBox();
            dtpDOB = new DateTimePicker();
            cbMajor = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            cbGender = new ComboBox();
            SuspendLayout();
            // 
            // lbStudentID
            // 
            lbStudentID.AutoSize = true;
            lbStudentID.Location = new Point(85, 50);
            lbStudentID.Name = "lbStudentID";
            lbStudentID.Size = new Size(79, 20);
            lbStudentID.TabIndex = 0;
            lbStudentID.Text = "Student ID";
            // 
            // lbStudentName
            // 
            lbStudentName.AutoSize = true;
            lbStudentName.Location = new Point(85, 106);
            lbStudentName.Name = "lbStudentName";
            lbStudentName.Size = new Size(104, 20);
            lbStudentName.TabIndex = 1;
            lbStudentName.Text = "Student Name";
            // 
            // lbGender
            // 
            lbGender.AutoSize = true;
            lbGender.Location = new Point(85, 166);
            lbGender.Name = "lbGender";
            lbGender.Size = new Size(57, 20);
            lbGender.TabIndex = 2;
            lbGender.Text = "Gender";
            // 
            // lbDOB
            // 
            lbDOB.AutoSize = true;
            lbDOB.Location = new Point(85, 223);
            lbDOB.Name = "lbDOB";
            lbDOB.Size = new Size(40, 20);
            lbDOB.TabIndex = 3;
            lbDOB.Text = "DOB";
            // 
            // lbMajor
            // 
            lbMajor.AutoSize = true;
            lbMajor.Location = new Point(85, 277);
            lbMajor.Name = "lbMajor";
            lbMajor.Size = new Size(48, 20);
            lbMajor.TabIndex = 4;
            lbMajor.Text = "Major";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(226, 47);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(201, 27);
            txtStudentID.TabIndex = 5;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(226, 103);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(201, 27);
            txtStudentName.TabIndex = 6;
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "dd/MM/yyyy";
            dtpDOB.Location = new Point(226, 218);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(201, 27);
            dtpDOB.TabIndex = 9;
            dtpDOB.Value = new DateTime(2023, 11, 11, 0, 0, 0, 0);
            // 
            // cbMajor
            // 
            cbMajor.FormattingEnabled = true;
            cbMajor.Items.AddRange(new object[] { "Information Technology", "Business Administration", "English Studies", "Japanese Studies", "Korean Studies" });
            cbMajor.Location = new Point(226, 274);
            cbMajor.Name = "cbMajor";
            cbMajor.Size = new Size(201, 28);
            cbMajor.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(115, 354);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(324, 354);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(226, 163);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(199, 28);
            cbGender.TabIndex = 13;
            // 
            // StudentDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 450);
            Controls.Add(cbGender);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbMajor);
            Controls.Add(dtpDOB);
            Controls.Add(txtStudentName);
            Controls.Add(txtStudentID);
            Controls.Add(lbMajor);
            Controls.Add(lbDOB);
            Controls.Add(lbGender);
            Controls.Add(lbStudentName);
            Controls.Add(lbStudentID);
            Name = "StudentDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentDetail";
            Load += StudentDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbStudentID;
        private Label lbStudentName;
        private Label lbGender;
        private Label lbDOB;
        private Label lbMajor;
        private TextBox txtStudentID;
        private TextBox txtStudentName;
        private DateTimePicker dtpDOB;
        private ComboBox cbMajor;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox cbGender;
    }
}