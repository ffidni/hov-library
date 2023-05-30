using PC_JAWABARAT.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_JAWABARAT
{
    public partial class BorrowingForm : Form
    {

        private Borrowing borrow = null;
        public BorrowingForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BorrowingForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            loadBorrows();
            using (var _context = new HovLibraryEntities())
            {
                List<BorrowStatus> statuses = new List<BorrowStatus>()
                {
                    new BorrowStatus(){ text = "On Going"},
                    new BorrowStatus(){ text = "Late"},
                    new BorrowStatus(){ text = "Returned"},
                };

                comboBox1.DataSource = statuses;
                comboBox1.DisplayMember = "text";

            }

        }

        private void loadBorrows()
        {

                using (var _context = new HovLibraryEntities())
                {
                    dataGridView1.DataSource = _context.Borrowings.Where(b => b.deleted_at == null).Include("Members").Include("Publishers").Select(i => new { id = i.id, member_name = i.Member.name, book_title = i.BookDetail.Book.title, borrow_date = i.borrow_date, return_date = i.return_date, fine = i.fine}).ToList();

                }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void borrowText_TextChanged(object sender, EventArgs e)
        {

        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows[0].Selected)
                {

                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                    using (var _context = new HovLibraryEntities())
                    {
                        Borrowing editBorrow = _context.Borrowings.Find(id);
                        editBorrow.return_date = DateTime.Now;
                        _context.SaveChanges();
                        MessageBox.Show("Successfuly Returned", "Hov Library", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadBorrows();
                    }



                }
            }
            catch
            {

            }
        }
    }
}
