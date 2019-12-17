using QLSBD.Class;
using QLSBD.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using QLSBD.Commons;

namespace QLSBD
{
    public partial class frmLogin : Form
    {
        QLSBDataContext db = new QLSBDataContext();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clAdmin admin = new clAdmin();
            admin.Username = txtUsername.Text;
            admin.Password = txtPassword.Text;
            var query = from table in db.admins
                        where table.username.Equals(admin.Username) && table.password.Equals(admin.Password)
                        select table;
            if (query.ToList().Count > 0)
            {
                frmHome frmHome = new frmHome();
                this.Hide();
                frmHome.ShowDialog();
                this.Show();
            }
            else
            {
                lbLoginError.Show();
            }
            /*int result = new tblUser().checkLoginAdmin(admin);
 if (result == DB_QUERY.OK)
 {
     frmHome frmHome = new frmHome();
     this.Hide();
     frmHome.ShowDialog();
     this.Show();
 }
 else
 {
     lbLoginError.Show();
 }*/
            /*lbLoginError.Visible = true*/

        }


        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát ?", "Warning", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

    }
}