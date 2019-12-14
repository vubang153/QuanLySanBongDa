using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;

namespace QLSBD
{
    public partial class frmHome : Form
    {
        QLSBDataContext db = new QLSBDataContext();
        public frmHome()
        {
            InitializeComponent();
            this.loadDataToForm();
        }
        private void loadDataToForm()
        {
            this.showDgvPitchInfo();
            this.showCbbEmployees();
            this.showCbbCategory();
            this.showCbbNote();
        }
        private void showDgvPitchInfo()
        {
            var query = from booking in db.bookings
                        select new {
                            ID = booking.id,
                            Mã_sân = booking.id_pitch,
                            Thời_gian = booking.time,
                            Giá = booking.price,
                            Ghi_chú = booking.message,
                            Người_lập = booking.id_user                            
                        };
            dgvPitchInfo.DataSource = query; 
        }
        private void showCbbEmployees()
        {
            var query = from admin in db.admins
                        select admin;
            cbbEmployee.DataSource = query.ToList();
            cbbEmployee.DisplayMember = "username";
            cbbEmployee.ValueMember = "id";
        }
        private void showCbbCategory()
        {
            var query = from category in db.categories
                        select category;
            cbbCategory.DataSource = query.ToList();
            cbbCategory.DisplayMember = "category1";
            cbbCategory.ValueMember = "id";
        }
        private void showCbbNote()
        {
            var query = from note in db.notes
                        select note;
            cbbNote.DataSource = query.ToList();
            cbbNote.DisplayMember = "note1";
            cbbNote.ValueMember = "id";
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvPitchInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            /*tbCustomerId.Text = dgvPitchInfo.Rows[numrow].Cells[1].Value.ToString();*/
            /*cbbCategory.SelectedIndex = int.Parse(dgvPitchInfo.Rows[numrow].Cells[1].Value.ToString());*/
            tbCustomerId.Text = dtpNgayDat.Value.ToString();
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadDataToForm();
        }
    }
}