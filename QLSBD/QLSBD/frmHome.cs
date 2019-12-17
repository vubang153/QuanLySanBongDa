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
        }
        // Hàm show MessageConfirm
        public DialogResult messageConfirm(String message)
        {
            var confirmResult = MessageBox.Show(message,
                                     "Thông báo",
                                     MessageBoxButtons.YesNo);
            return confirmResult;
        }
        private void loadDataToForm()
        {
            this.showDgvPitchInfo();
            this.showCbbEmployees();
            this.showCbbCategory(cbbPitchName);
            this.showCbbCategory(cbbTypeOfPitch);
            this.setTimePicker();
            this.setCbbTypeOfStatus();
            this.showDgvPitchList();
        }
        private void setCbbTypeOfStatus()
        {
            cbbBookingType.Items.Add("Đặt ngay");
            cbbBookingType.Items.Add("Đặt trước");
            cbbBookingType.SelectedItem = "Đặt ngay";
        }
        private void setTimePicker()
        {
            for (int i = 0; i < 11; i++)
            {
                cbbHoursPicker.Items.Add(i);
            }
            for (int i = 0; i < 46;)
            {
                cbbMinutePicker.Items.Add(i);
                i += 15;
            }
            cbbHoursPicker.SelectedItem = 1;
            cbbMinutePicker.SelectedItem = 0;
        }
        private void showDgvPitchInfo()
        {

            var query = from booking in db.bookings
                        join pitch in db.pitches on booking.id_pitch equals pitch.id
                        join staff in db.admins on booking.id_user equals staff.id
                        select new
                        {
                            Tên_sân = pitch.name,
                            Thời_gian = booking.time,
                            Giá = booking.price,
                            Ghi_chú = booking.message,
                            Người_lập = staff.username,
                        };
            dgvPitchInfo.DataSource = query;
        }
        private void showDgvPitchList()
        {
            var query = from pitch in db.pitches
                        select new
                        {
                            STT = pitch.id,
                            Tên_sân = pitch.name,
                            Giới_thiệu = pitch.introduction,
                            Trạng_thái = pitch.status
                        };
            this.dgvPitchList.DataSource = query;
        }
        private void showCbbEmployees()
        {
            var query = from admin in db.admins
                        select admin;
            cbbCreater.DataSource = query.ToList();
            cbbCreater.DisplayMember = "username";
            cbbCreater.ValueMember = "id";
        }
        private void showCbbCategory(System.Windows.Forms.ComboBox cbbCategory)
        {
            var query = from category in db.categories
                        select category;
            cbbCategory.DataSource = query.ToList();
            cbbCategory.DisplayMember = "category1";
            cbbCategory.ValueMember = "id";
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

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadDataToForm();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            this.btnConfirm.Visible = false;
            this.loadDataToForm();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = this.messageConfirm("Bạn muốn thêm hoá đơn này chứ ?");
            if (confirmResult == DialogResult.Yes)
            {
                // Convert phần tử
                int hoursPicker = Convert.ToInt32(cbbHoursPicker.SelectedItem.ToString());
                int minutesPicker = Convert.ToInt32(cbbMinutePicker.SelectedItem.ToString());
                // Khai báo class Booking
                booking booking = new booking();
                // Get các giá trị từ form
                int pitchIndex = cbbPitchName.SelectedIndex;
                DateTime bookingDate = dtpBookingDate.Value;
                int timeBooking = (60 * hoursPicker) + minutesPicker;
                int creater = cbbCreater.SelectedIndex;
                string note = tbNote.Text;
                String bookingType = cbbBookingType.Text;
                // Set giá trị vào thực thể
                booking.id_pitch = pitchIndex;
                booking.time = bookingDate;
                booking.message = note;
                booking.price = 1000000;
                booking.id_user = creater;
                booking.id = 7;
                db.bookings.InsertOnSubmit(booking);
                db.SubmitChanges();
            }
        }

        private void btnAddNewPitch_Click(object sender, EventArgs e)
        {

            // Lấy giá trị từ form
            string pitchName = tbPitchName.Text;
            int pitchType = cbbTypeOfPitch.SelectedIndex;
            string pitchAddress = tbPitchAddress.Text;
            string pitchIntroduction = tbPitchIntroduction.Text;
            // Khởi tạo đối tượng
            pitch pitch = new pitch();
            pitch.name = pitchName;
            pitch.introduction = pitchIntroduction;
            pitch.number = pitchType;
            pitch.address = pitchAddress;
            // Xác nhận và Insert vào csdl
            var confirmResult = this.messageConfirm("Bạn muốn thêm sân bóng này chứ ?");
            if (confirmResult == DialogResult.Yes)
            {
                db.pitches.InsertOnSubmit(pitch);
                db.SubmitChanges();
                // reload trang
                this.reloadTabPitchList();
            }
        }
        // Hàm tải lại thông tin sân
        private void reloadTabPitchList()
        {
            tbPitchName.Text = "";
            cbbTypeOfPitch.SelectedIndex = 0;
            tbPitchAddress.Text = "";
            tbPitchIntroduction.Text = "";
            this.showDgvPitchList();
        }

        private void btnReloadFormPitchList_Click(object sender, EventArgs e)
        {
            this.reloadTabPitchList();
        }
    }
}