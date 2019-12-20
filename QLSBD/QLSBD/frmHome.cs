using System;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using System.Collections.Generic;

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
        // Hàm get tất cả dữ liệu từ db đổ ra form
        private void loadDataToForm()
        {
            this.showDgvPitchInfo();
            this.showCbbEmployees();
            this.showCbbCategory(cbbPitchName);
            this.showCbbCategory(cbbTypeOfPitch);
            this.setTimePicker();
            this.showDgvPitchList();
        }
      
        // Hàm in ra giá trị của phần chọn thời gian
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
        // Hiện datagridview bảng booking(join 3 bảng booking, pitch, admin)
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
        // Hiện datagridview các sân bên tab Thông tin sân
        private void showDgvPitchList()
        {
            var query = from pitch in db.pitches
                        select new
                        {
                            STT = pitch.id,
                            Tên_sân = pitch.name,
                            Loại_sân = pitch.id_category,
                            Giới_thiệu = pitch.introduction,
                            Địa_chỉ = pitch.address,
                            Trạng_thái = pitch.status
                        };
            this.dgvPitchList.DataSource = query;
        }
        // Hàm lấy giá trị từ bảng admin đẩy ra combobox
        private void showCbbEmployees()
        {
            var query = from admin in db.admins
                        select admin;
            cbbCreater.DataSource = query.ToList();
            cbbCreater.DisplayMember = "username";
            cbbCreater.ValueMember = "id";
        }
        // Hàm hlấy giá trị từ bảng category đẩy ra combobox
        private void showCbbCategory(System.Windows.Forms.ComboBox cbbCategory)
        {
            var query = from category in db.categories
                        select category;
            cbbCategory.DataSource = query.ToList();
            cbbCategory.DisplayMember = "category1";
            cbbCategory.ValueMember = "id";
        }
        // Hàm khi click vào cel; của datagridview
        private void dgvPitchInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            /*tbCustomerId.Text = dgvPitchInfo.Rows[numrow].Cells[1].Value.ToString();*/
            /*cbbCategory.SelectedIndex = int.Parse(dgvPitchInfo.Rows[numrow].Cells[1].Value.ToString());*/

        }
        // Hàm làm click làm mới form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.loadDataToForm();
        }
        // Hàm load tất cả dữ liệu từ db
        private void frmHome_Load(object sender, EventArgs e)
        {
            this.btnConfirm.Visible = false;
            this.btnEditPitch.Enabled = false;
            this.loadDataToForm();

        }
        // Sự kiện click vào nút Thêm bên bảng Quản lý sân bóng
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
                // Set giá trị vào thực thể
                booking.id_pitch = pitchIndex;
                booking.time = timeBooking;
                booking.message = note;
                booking.price = 1000000;
                booking.id_user = creater;
                booking.id = 7;
                db.bookings.InsertOnSubmit(booking);
                db.SubmitChanges();
            }
        }
        // Hàm thêm sân bóng bên tabPanel thông tin sân
        private void btnAddNewPitch_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các ô còn trốgn thì không cho phép insert

            string pitchName = tbPitchName.Text;
            int pitchType = Convert.ToInt32(cbbTypeOfPitch.SelectedValue.ToString());
            string pitchAddress = tbPitchAddress.Text;
            string pitchIntroduction = tbPitchIntroduction.Text;

            // Khởi tạo đối tượng
            pitch pitch = new pitch();
            pitch.name = pitchName;
            pitch.introduction = pitchIntroduction;
            pitch.id_category= pitchType;
            pitch.address = pitchAddress;
            // Xác nhận và Insert vào csdl
            var confirmResult = this.messageConfirm("Bạn muốn thêm sân bóng này chứ ?");
            if (confirmResult == DialogResult.Yes)
            {
                if (tbPitchAddress.Text == "" || tbPitchIntroduction.Text == "" || tbPitchName.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập vào các truờng");
                }
                else
                {
                    db.pitches.InsertOnSubmit(pitch);
                    db.SubmitChanges();
                    // reload trang
                    this.reloadTabPitchList();
                }
            }

            // Lấy giá trị từ form

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
        // Phần này là phần bên thông tin sân(đang làm)
        private void btnReloadFormPitchList_Click(object sender, EventArgs e)
        {
            this.reloadTabPitchList();
        }

        private void btnEditPitch_Click(object sender, EventArgs e)
        {
            if (this.messageConfirm("Bạn muốn sửa chứ ?") == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvPitchList.CurrentRow.Cells["STT"].Value.ToString());
                var query = from pitch in db.pitches
                            where pitch.id == id
                            select pitch;
                foreach (pitch pitch in query)
                {
                    pitch.id_category = Convert.ToInt32(cbbTypeOfPitch.SelectedValue.ToString());
                    pitch.name = tbPitchName.Text.ToString();
                    pitch.introduction = tbPitchIntroduction.Text.ToString();
                    pitch.address = tbPitchAddress.Text.ToString();
                }
                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    this.reloadTabPitchList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi !!!");
                }
                
            }
            
            

        }

        private void dgvPitchList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbPitchName.Text = dgvPitchList.CurrentRow.Cells["Tên_sân"].Value.ToString();
            tbPitchIntroduction.Text = dgvPitchList.CurrentRow.Cells["Giới_thiệu"].Value.ToString();
            tbPitchName.Text = dgvPitchList.CurrentRow.Cells["Tên_sân"].Value.ToString();
            tbPitchAddress.Text = dgvPitchList.CurrentRow.Cells["Địa_chỉ"].Value.ToString();
            btnEditPitch.Enabled = true;
        }

        private void btnDeletePitch_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvPitchList.CurrentRow.Cells["STT"].Value.ToString());
            var query = (from pitch in db.pitches
                         where pitch.id == id
                         select pitch).FirstOrDefault();
            if (query != null)
            {
                var confirm = this.messageConfirm("Bạn muốn xoá sân này chứ ?");
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        db.pitches.DeleteOnSubmit(query);
                        db.SubmitChanges();
                        this.reloadTabPitchList();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi !!!");
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Lỗi ! Xin thử lại");
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}