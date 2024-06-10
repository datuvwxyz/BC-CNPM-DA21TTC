using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_KhachHang : UserControl
    {
        public uc_KhachHang()
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi = new SqlDataAdapter();
        DataTable bangkh = new DataTable();
        int donghh;

        void HienThiDuLieu()
        {
            string sql = "select *from KHACH_HANG";
            bangkh = ketnoi.DocDuLieu(sql);
            bodocghi = ketnoi.docghi;
            dgvKhachHang.DataSource = bangkh;
        }

        private void uc_KhachHang_Load(object sender, EventArgs e)
        {
            cmb_GioiTinh.SelectedIndex = 0;
            HienThiDuLieu();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                bangkh.Rows[donghh].Delete();
                //capnhat
                ketnoi.CapNhatDuLieu(bodocghi, bangkh);
                bangkh.Clear();
                ClearAll();
                HienThiDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the xoa");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            bangkh.Rows[donghh][0] = txt_MaKH.Text;
            bangkh.Rows[donghh][1] = txt_TenKH.Text;
            bangkh.Rows[donghh][2] = cmb_GioiTinh.Text;
            bangkh.Rows[donghh][3] = txt_DienThoai.Text;
            bangkh.Rows[donghh][4] = txt_DiaChi.Text;
            //capnhat
            ketnoi.CapNhatDuLieu(bodocghi, bangkh);
            bangkh.Clear();
            ClearAll();
            HienThiDuLieu();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txt_MaKH.Text = bangkh.Rows[donghh][0].ToString();
                txt_TenKH.Text = bangkh.Rows[donghh][1].ToString();
                cmb_GioiTinh.Text = bangkh.Rows[donghh][2].ToString();
                txt_DienThoai.Text = bangkh.Rows[donghh][3].ToString();
                txt_DiaChi.Text = bangkh.Rows[donghh][4].ToString();
                txt_MaKH.Enabled = false;
            }
        }

        private void txt_FullName_TextChanged(object sender, EventArgs e)
        {
            string sql = "select *from KHACH_HANG where tenkh like N'%" + txt_FullName.Text + "%'";
            DataTable dt = ketnoi.DocDuLieu(sql);
            dgvKhachHang.DataSource = dt;
        }

        private void txt_DienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                //Từ chối kí tự được nhập vào
                e.Handled = true;
            }    
        }

        public void ClearAll()
        {
            txt_MaKH.Clear();
            txt_TenKH.Clear();
            txt_DienThoai.Clear();
            txt_DiaChi.Clear();
            cmb_GioiTinh.ResetText();
        }

        private void uc_KhachHang_Leave(object sender, EventArgs e)
        {
            ClearAll();
            txt_MaKH.Enabled = true;
        }

        private void guna_bt_them_Click(object sender, EventArgs e)
        {
      
        }

        private void btn_NhapLai_Click(object sender, EventArgs e)
        {

        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (txt_MaKH.Text != "")
            {
                DataRow dongmoi = bangkh.NewRow();
                dongmoi["makh"] = txt_MaKH.Text;
                dongmoi["tenkh"] = txt_TenKH.Text;
                dongmoi["gioitinh"] = cmb_GioiTinh.Text;
                dongmoi["sdt_kh"] = txt_DienThoai.Text;
                dongmoi["diachi"] = txt_DiaChi.Text;
                bangkh.Rows.Add(dongmoi);
                //cap nhat
                ketnoi.CapNhatDuLieu(bodocghi, bangkh);
                bangkh.Clear();
                ClearAll();
                HienThiDuLieu();
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
