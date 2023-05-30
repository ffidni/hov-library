using PC_JAWABARAT.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_JAWABARAT
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private bool validateEmpty(TextBox textbox, ErrorProvider errorProvider)
        {
            if (textbox.Text == "")
            {
                errorProvider.SetError(textbox, "Required!");
                return true;
            } else
            {
                errorProvider.Clear();
                return false;
            }

        }

        private bool validateEmail()
        {
            bool isEmpty = validateEmpty(emailText, emailError);
            if (isEmpty) return true;
            return false;
        }

        private bool validatePassword()
        {
            bool isEmpty = validateEmpty(passwordText, passwordError);
            if (isEmpty) return true;
            return false;
        }

        private String hashPass(String pass)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hashed = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pass));
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hashed.Length; i++)
                {
                    result.Append(hashed[i].ToString("x2"));
                }
                return result.ToString();
            }
        }

        private void login()
        {
            using (var _context = new HovLibraryEntities())
            {
                String hashedPassword = hashPass(passwordText.Text);
                //Employee employee = _context.Employees.Where(e => e.email == emailText.Text && e.password == hashedPassword).FirstOrDefault();
            var employee = _context.Employees.SqlQuery("SELECT * FROM Employee WHERE email = @email and password = @password", new SqlParameter("@email", emailText.Text), new SqlParameter("@password", hashedPassword)).FirstOrDefault();
                if (employee != null)
                {
                    EmployeeSession.employee = employee;
                    this.Hide();
                    HovLibraryForm main = new HovLibraryForm();
                    main.Show();
                } else
                {
                    MessageBox.Show("Email or password is incorrect!", "Hov Library", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            bool emailValidate = validateEmail();
            bool passwordValidate = validatePassword();
            if (!emailValidate && !passwordValidate)
            {
                login();
            }
        }
    }
}
