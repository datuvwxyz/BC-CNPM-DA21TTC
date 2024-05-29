using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Guna.UI2.WinForms;
using System.Collections;

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_NhanVien : UserControl
    {
        public uc_NhanVien()
        {
            InitializeComponent();
        }

        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        private void btn_DangKyNhanVien_Click(object sender, EventArgs e)
        {
            if (txt_MaNV.Text != "" && txt_HoTen.Text != "" && txt_SoDienThoai.Text != "" && txt_GioiTinh.Text != "" && txt_taikhoan.Text != "" && txt_matkhau.Text != "" && cmb_Quyen.Text != "")
            {
                // Check if the username contains any spaces
                if (txt_taikhoan.Text.Contains(" "))
                {
                    MessageBox.Show("Tạo tài khoản thất bại, tên tài khoản không được chứa khoảng trắng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Exit the method early if there are spaces in the username
                }

                string sql = "insert into NHAN_VIEN (manv, tennv, gioitinh, diachi, sdt_nv, taikhoan, matkhau, quyen) values ( '" + txt_MaNV.Text + "',N'" + txt_HoTen.Text + "',N'" + txt_GioiTinh.Text + "',N'" + txt_DiaChiNV.Text + "','" + txt_SoDienThoai.Text + "','" + txt_taikhoan.Text + "','" + txt_matkhau.Text + "','" + cmb_Quyen.Text + "')";
                ketnoi.ThaoTacDuLieu(sql, "Đăng ký thành công");
            }
            else
            {
                MessageBox.Show("Tạo tài khoản thất bại, vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            uc_NhanVien_Load(this, null);
            clearAll();
        }

        private void ckb_passwd_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_passwd.Checked)
                txt_matkhau.UseSystemPasswordChar = true;
            if (ckb_passwd.Checked)
                txt_matkhau.UseSystemPasswordChar = false;
        }

        private void uc_NhanVien_Load(object sender, EventArgs e)
        {
            txt_matkhau.UseSystemPasswordChar = true;
        }

        public void setStaff(DataGridView dgv)
        {
            string sql = "select manv, tennv, gioitinh, diachi, sdt_nv, taikhoan, matkhau from NHAN_VIEN";
            DataTable dt = ketnoi.DocDuLieu(sql);
            dgv.DataSource = dt;
        }

        private void tabStaff_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tabStaff.SelectedIndex == 1)
            {
                setStaff(dgvNhanVien);
            }
            else if (tabStaff.SelectedIndex == 2)
            {
                setStaff(dgvNhanVien1);
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            if(txt_IDNV.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sql = "delete from NHAN_VIEN where manv = '" + txt_IDNV.Text + "'";
                    ketnoi.ThaoTacDuLieu(sql, "Xóa nhân viên thành công");
                    tabStaff_SelectedIndexChanged_1(this, null);
                }
            }    
        }

        private void clearAll()
        {
            txt_MaNV.Clear();
            txt_HoTen.Clear();
            txt_GioiTinh.ResetText();
            txt_SoDienThoai.Clear();
            txt_DiaChiNV.Clear();
            txt_taikhoan.Clear();
            txt_matkhau.Clear();
            cmb_Quyen.ResetText();
        }

        private void uc_NhanVien_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_taikhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
