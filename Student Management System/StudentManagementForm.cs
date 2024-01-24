using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentLibrary.Repository;
using StudentLibrary.Object;
using System.Xml.Serialization;

namespace Student_Management_System
{
    public partial class StudentManagementForm : Form
    {
        IStudentRepository studentRepository = new StudentRepository();
        BindingSource source;
        bool isLoggedIn;

        public StudentManagementForm()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
            if (isLoggedIn == true)
            {
                btnAdd.Enabled = true;
            }
        }

        private void StudentManagementForm_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            //dgvStudentList.CellDoubleClick += DgvStudentList_CellDoubleClick;
        }

        private void DgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentDetail studentDetail = new StudentDetail
            {
                Text = "Update Student",
                InsertOrUpdate = true,
                StudentInfo = GetStudentObject(),
                StudentRepository = studentRepository,
            };
            if (studentDetail.ShowDialog() == DialogResult.OK)
            {
                LoadStudentList();
                source.Position = source.Count - 1;
            }
        }

        private void ClearAll()
        {
            txtStudentID.Text = string.Empty;
            txtStudentName.Text = string.Empty;
            cbGender.Text = string.Empty;
            dtpDOB.Text = string.Empty;
            cbMajor.Text = string.Empty;
        }

        private Student GetStudentObject()
        {
            Student student = null;
            try
            {
                student = new Student
                {
                    StudentID = int.Parse(txtStudentID.Text),
                    StudentName = txtStudentName.Text,
                    Gender = cbGender.Text,
                    DOB = dtpDOB.Value,
                    Major = cbMajor.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Student");
            }
            return student;
        }

        private Student GetStudentSearch()
        {
            Student student = null;
            try
            {
                int temp;
                if (txtStudentID.Text.Equals(string.Empty))
                {
                    temp = 0;
                }
                else
                {
                    temp = int.Parse(txtStudentID.Text);
                }
                student = new Student
                {
                    StudentID = temp,
                    StudentName = txtStudentName.Text,
                    Gender = cbGender.Text,
                    DOB = dtpDOB.Value,
                    Major = cbMajor.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Student");
            }
            return student;
        }

        public void LoadStudentList()
        {
            var students = studentRepository.GetStudents();
            try
            {
                source = new BindingSource();
                source.DataSource = students;

                txtStudentID.DataBindings.Clear();
                txtStudentName.DataBindings.Clear();
                cbGender.DataBindings.Clear();
                dtpDOB.DataBindings.Clear();
                cbMajor.DataBindings.Clear();

                txtStudentID.DataBindings.Add("Text", source, "StudentID");
                txtStudentName.DataBindings.Add("Text", source, "StudentName");
                cbGender.DataBindings.Add("Text", source, "Gender");
                dtpDOB.DataBindings.Add("Value", source, "DOB");
                cbMajor.DataBindings.Add("Text", source, "Major");

                dgvStudentList.DataSource = null;
                dgvStudentList.DataSource = source;
                /*if (students.Count() == 0)
                {
                    ClearAll();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Student List");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadStudentList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentDetail studentDetail = new StudentDetail
            {
                Text = "Add Student",
                InsertOrUpdate = false,
                StudentRepository = studentRepository
            };
            if (studentDetail.ShowDialog() == DialogResult.OK)
            {
                LoadStudentList();
                source.Position = source.Count - 1;
            }
            //---------------------------//try to intergrate into 1 form
            /*Student student = new Student
            {
                StudentID = int.Parse(txtStudentID.Text),
                StudentName = txtStudentName.Text,
                Gender = cbGender.Text,
                DOB = dtpDOB.Value,
                Major = cbMajor.Text
            };
            studentRepository.InsertStudent(student);
            LoadStudentList();
            */
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var student = GetStudentObject();
                studentRepository.DeleteStudent(student.StudentID);
                LoadStudentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete student");
            }
        }

        private bool isStudentNull()
        {
            if (txtStudentID.Text.Equals(string.Empty) && txtStudentName.Text.Equals(string.Empty) && cbNullDate.Checked && cbGender.Text.Equals(string.Empty) && cbMajor.Text.Equals(string.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (isStudentNull())
                {
                    LoadStudentList();
                }
                else
                {
                    var student = GetStudentSearch();
                    var students = studentRepository.SearchStudent(student, cbNullDate.Checked);
                    source = new BindingSource();
                    source.DataSource = students;

                    txtStudentID.DataBindings.Clear();
                    txtStudentName.DataBindings.Clear();
                    cbGender.DataBindings.Clear();
                    dtpDOB.DataBindings.Clear();
                    cbMajor.DataBindings.Clear();

                    txtStudentID.DataBindings.Add("Text", source, "StudentID");
                    txtStudentName.DataBindings.Add("Text", source, "StudentName");
                    cbGender.DataBindings.Add("Text", source, "Gender");
                    dtpDOB.DataBindings.Add("Value", source, "DOB");
                    cbMajor.DataBindings.Add("Text", source, "Major");

                    dgvStudentList.DataSource = null;
                    dgvStudentList.DataSource = students;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search student");
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (isStudentNull())
                {
                    LoadStudentList();
                }
                else
                {
                    var student = GetStudentSearch();
                    var students = studentRepository.FilterStudent(student, cbNullDate.Checked);

                    source = new BindingSource();
                    source.DataSource = students;

                    txtStudentID.DataBindings.Clear();
                    txtStudentName.DataBindings.Clear();
                    cbGender.DataBindings.Clear();
                    dtpDOB.DataBindings.Clear();
                    cbMajor.DataBindings.Clear();

                    txtStudentID.DataBindings.Add("Text", source, "StudentID");
                    txtStudentName.DataBindings.Add("Text", source, "StudentName");
                    cbGender.DataBindings.Add("Text", source, "Gender");
                    dtpDOB.DataBindings.Add("Value", source, "DOB");
                    cbMajor.DataBindings.Add("Text", source, "Major");

                    dgvStudentList.DataSource = null;
                    dgvStudentList.DataSource = students;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter student");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();


        //structure: get input from login form, getLogin in same form, send back bolean, islogin = bolean
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login
                {
                    Text = "Login",
                };
                /*if (login.ShowDialog() == DialogResult.OK)
                {
                    isLoggedIn = login.LoginResult;
                    if (isLoggedIn == true)
                    {
                        btnAdd.Enabled = true;//bug
                    }
                }*/
                login.evtFrm += new ShowFrm(login_evtFrm);
                if (login.ShowDialog() == DialogResult.OK)
                {
                    if (login.LoginResult == true)
                    {
                        login.evtFrm += new ShowFrm(login_evtFrm);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login");
            }
        }

        void login_evtFrm()
        {
            var students = studentRepository.GetStudents();
            if (students.Count() == 0)
            {
                ClearAll();
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
            btnAdd.Enabled = true;
            dgvStudentList.CellDoubleClick += DgvStudentList_CellDoubleClick;
            btnLogin.Text = "Logged In";
            btnLogin.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            dgvStudentList.DataSource = null;
            txtStudentID.DataBindings.Clear();
            txtStudentName.DataBindings.Clear();
            cbGender.DataBindings.Clear();
            dtpDOB.DataBindings.Clear();
            cbMajor.DataBindings.Clear();
        }
    }
}
