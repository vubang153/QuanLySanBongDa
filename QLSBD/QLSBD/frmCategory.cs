using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSBD
{
    public partial class frmCategory : Form
    {
        QLSBDataContext db = new QLSBDataContext();
        public frmCategory()
        {
            InitializeComponent();
        }
        private void addNewCategory()
        {
            if (tbCategoryName.Text == "")
            {
                this.lbError.Text = "Bạn phải nhập vào trường này !";
                this.lbError.Visible = true;
            }
            else
            {
                string categoryName = tbCategoryName.Text;
                var query = from category in db.categories
                            where category.category1 == categoryName
                            select category;
                int totalRecord = query.ToList().Count;
                if (totalRecord > 0)
                {
                    this.lbError.Text = "Tên loại sân này đã tồn tại";
                }
                else
                {
                    category category = new category();
                    category.category1 = tbCategoryName.Text;
                    db.categories.InsertOnSubmit(category);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm mới thành công");
                }
            }
        }

        private void btnAddNewCategoryFromClosing_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
