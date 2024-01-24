namespace Student_Management_System
{
    partial class StudentManagementForm
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
            lbStudentName = new Label();
            lbDOB = new Label();
            lbGender = new Label();
            lbMajor = new Label();
            txtStudentName = new TextBox();
            dtpDOB = new DateTimePicker();
            cbMajor = new ComboBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            dgvStudentList = new DataGridView();
            lbStudentID = new Label();
            txtStudentID = new TextBox();
            btnLoad = new Button();
            btnClose = new Button();
            btnLogin = new Button();
            btnFilter = new Button();
            cbGender = new ComboBox();
            cbNullDate = new CheckBox();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).BeginInit();
            SuspendLayout();
            // 
            // lbStudentName
            // 
            lbStudentName.AutoSize = true;
            lbStudentName.Location = new Point(52, 143);
            lbStudentName.Name = "lbStudentName";
            lbStudentName.Size = new Size(104, 20);
            lbStudentName.TabIndex = 0;
            lbStudentName.Text = "Student Name";
            // 
            // lbDOB
            // 
            lbDOB.AutoSize = true;
            lbDOB.Location = new Point(52, 211);
            lbDOB.Name = "lbDOB";
            lbDOB.Size = new Size(40, 20);
            lbDOB.TabIndex = 1;
            lbDOB.Text = "DOB";
            // 
            // lbGender
            // 
            lbGender.AutoSize = true;
            lbGender.Location = new Point(447, 76);
            lbGender.Name = "lbGender";
            lbGender.Size = new Size(57, 20);
            lbGender.TabIndex = 2;
            lbGender.Text = "Gender";
            // 
            // lbMajor
            // 
            lbMajor.AutoSize = true;
            lbMajor.Location = new Point(447, 142);
            lbMajor.Name = "lbMajor";
            lbMajor.Size = new Size(48, 20);
            lbMajor.TabIndex = 3;
            lbMajor.Text = "Major";
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(171, 140);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(214, 27);
            txtStudentName.TabIndex = 4;
            // 
            // dtpDOB
            // 
            dtpDOB.CustomFormat = "dd/MM/yyyyy";
            dtpDOB.Location = new Point(171, 204);
            dtpDOB.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dtpDOB.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(244, 27);
            dtpDOB.TabIndex = 5;
            dtpDOB.Value = new DateTime(2023, 11, 9, 0, 0, 0, 0);
            // 
            // cbMajor
            // 
            cbMajor.FormattingEnabled = true;
            cbMajor.Items.AddRange(new object[] { "Information Technology", "Business Administration", "English Studies", "Japanese Studies", "Korean Studies" });
            cbMajor.Location = new Point(535, 139);
            cbMajor.Name = "cbMajor";
            cbMajor.Size = new Size(208, 28);
            cbMajor.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(219, 266);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(355, 266);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(504, 268);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 13;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvStudentList
            // 
            dgvStudentList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentList.Location = new Point(52, 331);
            dgvStudentList.Name = "dgvStudentList";
            dgvStudentList.ReadOnly = true;
            dgvStudentList.RowHeadersWidth = 51;
            dgvStudentList.RowTemplate.Height = 29;
            dgvStudentList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudentList.Size = new Size(706, 217);
            dgvStudentList.TabIndex = 14;
            // 
            // lbStudentID
            // 
            lbStudentID.AutoSize = true;
            lbStudentID.Location = new Point(52, 76);
            lbStudentID.Name = "lbStudentID";
            lbStudentID.Size = new Size(79, 20);
            lbStudentID.TabIndex = 15;
            lbStudentID.Text = "Student ID";
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(171, 73);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(214, 27);
            txtStudentID.TabIndex = 16;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(62, 268);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 18;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(355, 582);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 19;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(52, 12);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 20;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnFilter
            // 
            btnFilter.Enabled = false;
            btnFilter.Location = new Point(632, 266);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 21;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Items.AddRange(new object[] { "Male", "Female" });
            cbGender.Location = new Point(535, 73);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(151, 28);
            cbGender.TabIndex = 22;
            // 
            // cbNullDate
            // 
            cbNullDate.AutoSize = true;
            cbNullDate.Location = new Point(434, 207);
            cbNullDate.Name = "cbNullDate";
            cbNullDate.Size = new Size(94, 24);
            cbNullDate.TabIndex = 23;
            cbNullDate.Text = "Null Date";
            cbNullDate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(664, 12);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 24;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // StudentManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 636);
            Controls.Add(btnClear);
            Controls.Add(cbNullDate);
            Controls.Add(cbGender);
            Controls.Add(btnFilter);
            Controls.Add(btnLogin);
            Controls.Add(btnClose);
            Controls.Add(btnLoad);
            Controls.Add(txtStudentID);
            Controls.Add(lbStudentID);
            Controls.Add(dgvStudentList);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(cbMajor);
            Controls.Add(dtpDOB);
            Controls.Add(txtStudentName);
            Controls.Add(btnSearch);
            Controls.Add(lbMajor);
            Controls.Add(lbGender);
            Controls.Add(lbDOB);
            Controls.Add(lbStudentName);
            Name = "StudentManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Management Form";
            Load += StudentManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudentList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbStudentName;
        private Label lbDOB;
        private Label lbGender;
        private Label lbMajor;
        private TextBox txtStudentName;
        private DateTimePicker dtpDOB;
        private ComboBox cbMajor;
        public Button btnAdd;
        private Button btnDelete;
        private Button btnSearch;
        private DataGridView dgvStudentList;
        private Label lbStudentID;
        private TextBox txtStudentID;
        private Button btnLoad;
        private Button btnClose;
        private Button btnLogin;
        private Button btnFilter;
        private ComboBox cbGender;
        private CheckBox cbNullDate;
        private Button btnClear;
    }
}