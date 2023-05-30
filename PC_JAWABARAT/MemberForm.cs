using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_JAWABARAT
{
    public partial class MemberForm : Form
    {

        private Member member = null;
        public MemberForm()
        {
            InitializeComponent();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            loadMembers();
            saveBtn.Enabled = true;
        }

        private void loadMembers()
        {
            using (var _context = new HovLibraryEntities())
            {
                memberList.DataSource = _context.Members.Where(e => e.deleted_at == null).ToList();
            }
        }

        private void loadForm(Member member)
        {
            nameText.Text = member.name;
            phoneText.Text = member.phone_number;
            emailText.Text = member.email;
            addressText.Text = member.address;
            cityText.Text = member.city_of_birth;
            birthDate.Value = member.date_of_birth;
            if (member.gender == "Male")
            {
                maleRadio.Checked = true;
                femaleRadio.Checked = false;

            }
            else
            {
                femaleRadio.Checked = true;
                maleRadio.Checked = false;
            }

        }

        private void memberList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (memberList.Columns[e.ColumnIndex].Name == "Edit")
            {
                memberList.CurrentRow.Selected = true;
                using (var _context = new HovLibraryEntities())
                {
                    int selectedId = Convert.ToInt32(memberList.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    member = _context.Members.Where(m => m.id == selectedId).FirstOrDefault();
                    loadForm(member);
                }

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

        private bool validateAddress()
        {
            if (addressText.Text.Trim() == "")
            {
                addressError.SetError(addressText, "Required!");
                return true;
            } else
            {
                addressError.Clear();
                return false;

            }
        }





        private void saveBtn_Click(object sender, EventArgs e)
        {
            bool nameEmpty = validateEmpty(nameText, nameError);
            bool phoneEmpty = validateEmpty(phoneText, phoneError);
            bool emailEmpty = validateEmpty(emailText, emailError);
            bool addressEmpty = validateAddress();
            bool cityEmpty = validateEmpty(cityText, cityError);

            if (!nameEmpty && !phoneEmpty && !emailEmpty && !addressEmpty && !cityEmpty)
            {
                using (var _context = new HovLibraryEntities())
                {
                    Member editMember = _context.Members.Find(member.id);
                    editMember.name = nameText.Text;
                    editMember.phone_number = phoneText.Text;
                    editMember.email = emailText.Text;
                    editMember.address = addressText.Text;
                    editMember.city_of_birth = cityText.Text;
                    editMember.date_of_birth = birthDate.Value;
                    _context.SaveChanges();
                    MessageBox.Show("Succesfully Updated!", "Hov Library", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadMembers();

                }
            }
        }
    }
}
