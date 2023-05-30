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
    public partial class MasterBookForm : Form
    {
        private Book book = null;
        public MasterBookForm()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void MasterBookForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            loadBooks();
            using (var _context = new HovLibraryEntities()) {
                List<Language> langs = _context.Languages.Where(l => l.deleted_at == null).ToList();
                List<Publisher> pubs = _context.Publishers.Where(l => l.deleted_at == null).ToList();

                pubBox.DataSource = pubs;
                pubBox.DisplayMember = "name";
                pubBox.ValueMember = "id";

                langBox.DataSource = langs;
                langBox.ValueMember = "id";
                langBox.DisplayMember = "long_text";

                langsBox.DataSource = langs;
                langsBox.ValueMember = "id";
                langsBox.DisplayMember = "long_text";

            }
        }

        private void loadBooks()
        {
            using (var _context = new HovLibraryEntities())
            {
                bookList.DataSource = _context.Books.Where(b => b.deleted_at == null).Include("Publishers").Include("Languages").Select(i => new { id = i.id, languange = i.Language.long_text, title = i.title, isbn = i.isbn, isbn13 = i.isbn13, authors = i.authors, publisher = i.Publisher.name, publish_date = i.publication_date, page_count = i.number_of_pages, ratings = i.ratings_count }).ToList();
                
            }
        }

        private bool validateEmpty(TextBox textbox, ErrorProvider errorProvider)
        {
            if (textbox.Text == "")
            {
                errorProvider.SetError(textbox, "Required!");
                return true;
            }
            else
            {
                errorProvider.Clear();
                return false;
            }

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookList.SelectedRows[0].Selected)
                {

                    int id = Convert.ToInt32(bookList.SelectedRows[0].Cells[0].Value.ToString());
                    using (var _context = new HovLibraryEntities())
                    {
                        book = _context.Books.Find(id);
                    }
                    String language = bookList.SelectedRows[0].Cells[1].Value.ToString();
                    String title = bookList.SelectedRows[0].Cells[2].Value.ToString();
                    String isbn = bookList.SelectedRows[0].Cells[3].Value.ToString();
                    String isbn13 = bookList.SelectedRows[0].Cells[4].Value.ToString();
                    String authors = bookList.SelectedRows[0].Cells[5].Value.ToString();
                    String publishers = bookList.SelectedRows[0].Cells[6].Value.ToString();
                    String publish_date = bookList.SelectedRows[0].Cells[7].Value.ToString();
                    String page_count = bookList.SelectedRows[0].Cells[8].Value.ToString();
                    String ratings = bookList.SelectedRows[0].Cells[9].Value.ToString();

                    langsBox.Text = language;
                    titleText.Text = title;
                    isbnText.Text = isbn;
                    isbn13Text.Text = isbn13;
                    authorsText.Text = authors;
                    pubBox.Text = publishers;
                    publishDate.Text = publish_date;
                    countText.Text = page_count;
                    ratingsText.Text = ratings;

                    saveBtn.Enabled = true;



                }
            } catch
            {

            }

        }

        private void bookList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool titleEmpty = validateEmpty(titleText, titleError);
            bool isbnEmpty = validateEmpty(isbnText, isbnError);
            bool isbn13Empty = validateEmpty(isbn13Text, isbn13Error);
            bool authorsEmpty = validateEmpty(authorsText, AuthorsError);
            bool countEmpty = validateEmpty(countText, countError);
            bool ratingsEmpty = validateEmpty(ratingsText, ratingsError);

            if (!titleEmpty && !isbnEmpty && !isbn13Empty && !authorsEmpty && !countEmpty && !ratingsEmpty) ;
            {
                using (var _context = new HovLibraryEntities())
                {
                    Book editBook = _context.Books.Find(book.id);
                    Language langId = langsBox.SelectedItem as Language;
                    Publisher pubId = pubBox.SelectedItem as Publisher;


                    editBook.title = titleText.Text;
                    editBook.isbn = isbnText.Text;
                    editBook.isbn13 = isbn13Text.Text;
                    editBook.authors = isbnText.Text;
                    editBook.number_of_pages = Convert.ToInt32(countText.Text);
                    editBook.ratings_count = Convert.ToInt32(ratingsText.Text);
                    editBook.language_id = Convert.ToInt32(langId.id);
                    editBook.publisher_id = Convert.ToInt32(pubId.id);

                    _context.SaveChanges();
                    MessageBox.Show("Succesfully Updated!", "Hov Library", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBooks();







                }
            }
        }

        private void applyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Language langId = langsBox.SelectedItem as Language;

                int rFrom = Convert.ToInt32(ratingsFrom.Text);
                int rTo = Convert.ToInt32(ratingsTo.Text);
                int pFrom = Convert.ToInt32(pageFrom.Text);
                int pTo = Convert.ToInt32(pageTo.Text);
                using (var _context = new HovLibraryEntities())
                {

                    var data = _context.Books.Where(b => (b.number_of_pages >= pFrom && b.number_of_pages <= pTo) && (b.ratings_count >= rTo && b.ratings_count <= rFrom));
                    bookList.DataSource = data.Include("Publishers").Include("Languages").Select(i => new { id = i.id, languange = i.Language.long_text, title = i.title, isbn = i.isbn, isbn13 = i.isbn13, authors = i.authors, publisher = i.Publisher.name, publish_date = i.publication_date, page_count = i.number_of_pages, ratings = i.ratings_count }).ToList();
                }
            }

            catch
            {

            }

        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookList.SelectedRows[0].Selected)
                {

                    int id = Convert.ToInt32(bookList.SelectedRows[0].Cells[0].Value.ToString());
                    using (var _context = new HovLibraryEntities())
                    {
                        book = _context.Books.Find(id);
                        book.deleted_at = DateTime.Now;
                        loadBooks();

                    }



                }
            }
            catch
            {

            }
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            DetailForm form = new DetailForm();
            form.ShowDialog();
            this.Visible = false;
            this.Dispose();
        }

        private void langBox_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }
    }
}
