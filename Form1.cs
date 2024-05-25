using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace QLBH_DIEN_TU
{
    public partial class Form1 : Form
    {
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {  
            string sql = "select taikhoan, matkhau, manv, tennv  from NHAN_VIEN where taikhoan = '" + txt_username.Text + "' and matkhau = '" + txt_passwd.Text + "'";
            DataTable dt = ketnoi.DocDuLieu(sql);
               
            if (dt.Rows.Count != 0)
            {
                Dashboard.quyen = ketnoi.DocDuLieu("select quyen from NHAN_VIEN where taikhoan = '" + txt_username.Text + "' and matkhau = '"+ txt_passwd.Text + "'").Rows[0][0].ToString();
                this.Hide();
                Dashboard db = new Dashboard(dt.Rows[0]["manv"].ToString(), dt.Rows[0]["tennv"].ToString());
                db.Show();
                db.Logout += Db_Logout;
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
         
        }

        private void Db_Logout(object sender, EventArgs e)
        {
            (sender as Dashboard).isExit = false;
            (sender as Dashboard).Close();
            this.Show();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_passwd.Clear();
            txt_passwd.UseSystemPasswordChar = true;
        }

        private void ckb_passwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_password.Checked)
                txt_passwd.UseSystemPasswordChar = true;
            if (ckb_password.Checked)
                txt_passwd.UseSystemPasswordChar = false;
        }
    }
}
