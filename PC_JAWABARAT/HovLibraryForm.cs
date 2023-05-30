using PC_JAWABARAT.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace PC_JAWABARAT
{
    public partial class HovLibraryForm : Form
    {
        public HovLibraryForm()
        {
            InitializeComponent();
        }

        private void HovLibraryForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void navigate(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeSession.employee = null;
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();

        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigate(new MemberForm());
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigate(new MasterBookForm());

        }

        private void borrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void allBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            navigate(new BorrowingForm());

        }
    }
}
