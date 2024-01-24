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

namespace Student_Management_System
{
    public delegate void ShowFrm();
    public partial class Login : Form
    {
        private readonly StudentManagementForm studentManagementForm;
        public bool LoginResult
        {
            get; set;
        }
        IStudentRepository repository = new StudentRepository();
        public event ShowFrm evtFrm;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };
            LoginResult = repository.GetLogin(admin);
            if (evtFrm != null)
            {
                evtFrm();
            }
        }
    }
}
