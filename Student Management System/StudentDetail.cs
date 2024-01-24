using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLibrary.Object;
using StudentLibrary.Repository;

namespace Student_Management_System
{
    public partial class StudentDetail : Form
    {
        public StudentDetail()
        {
            InitializeComponent();
        }

        public IStudentRepository StudentRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Student StudentInfo { get; set; }

        private void StudentDetail_Load(object sender, EventArgs e)
        {
            cbMajor.SelectedIndex = 0;
            txtStudentID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)//Update
            {
                txtStudentID.Text = StudentInfo.StudentID.ToString();
                txtStudentName.Text = StudentInfo.StudentName;
                cbGender.Text = StudentInfo.Gender.Trim();
                dtpDOB.Value = StudentInfo.DOB;
                cbMajor.Text = StudentInfo.Major.Trim();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student
                {
                    StudentID = int.Parse(txtStudentID.Text),
                    StudentName = txtStudentName.Text,
                    Gender = cbGender.Text,
                    DOB = dtpDOB.Value,
                    Major = cbMajor.Text
                };
                if (InsertOrUpdate == false)
                {
                    StudentRepository.InsertStudent(student);
                }
                else
                {
                    StudentRepository.UpdateStudent(student);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Added a student" : "Update a student");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
