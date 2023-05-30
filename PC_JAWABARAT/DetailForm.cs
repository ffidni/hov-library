using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_JAWABARAT
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();
        }


        private void DetailForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            loadBooks();
        }

        private void loadBooks()
        {
            using (var _context = new HovLibraryEntities())
            {
                bookList.DataSource = _context.BookDetails.Where(b => b.deleted_at == null).Include("Books").Include("Locations").Select(i => new { id = i.id,  code = i.code, location = i.Location.name}).ToList();

            }
        }

    }
}
