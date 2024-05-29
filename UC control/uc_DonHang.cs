using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_DonHang : UserControl
    {
        public string manv ="";

        public uc_DonHang() 
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi = new SqlDataAdapter();
        DataTable banghd = new DataTable();
        int donghh;

        public string MaNV
        {
            get { return manv; }
            set { manv = value; }
        }
        
        void HienThiDuLieu()
        {
            string sql = "select *from HOA_DON";
            banghd = ketnoi.DocDuLieu(sql);
            bodocghi = ketnoi.docghi;
            dgvDonHang.DataSource = banghd;

        }

        public void HienNhanVien()
        {
            txt_nhanvien.Text = manv;
            txt_nhanvien.Enabled = false;
        }

        void HienSanPham()
        {
            string sql = "SELECT tensp, masq + ' | ' + tensp AS 'masq | tensp' from SAN_PHAM";
            cmb_MaSP.DataSource = ketnoi.DocDuLieu(sql);
            cmb_MaSP.ValueMember = "tensp";
            cmb_MaSP.DisplayMember = "masq | tensp";
        }
        void Load_cmb_MaKH()
        {
            string sql = "select* from KHACH_HANG";
            cmb_MaKH.DataSource = ketnoi.DocDuLieu(sql);
            cmb_MaKH.DisplayMember = "makh";
            cmb_MaKH.ValueMember = "makh";

        }
        void Load_cmb_TenKH()
        {
            string sql = "select* from KHACH_HANG";
            cmb_TenKH.DataSource = ketnoi.DocDuLieu(sql);
            cmb_TenKH.DisplayMember = "tenkh";
            cmb_TenKH.ValueMember = "tenkh";

        }
        void Load_cmb_NCC()
        {
            string sql = "select* from NHA_CUNG_CAP";
            cmb_MaNCC.DataSource = ketnoi.DocDuLieu(sql);
            cmb_MaNCC.DisplayMember = "mancc";
            cmb_MaNCC.ValueMember = "mancc";

        }
        private void uc_DonHang_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            HienNhanVien();
            HienSanPham();
            Load_cmb_MaKH();
            Load_cmb_TenKH();
            Load_cmb_NCC();
            ClearAll();
        }

        private void btn_TaoDonHang_Click(object sender, EventArgs e)
        {
            if (cmb_MaKH.Text != "" && cmb_TenKH.Text != "" && cmb_MaNCC.Text != "" && txt_SoLuongMua.Text != "" && txt_DonGia.Text != "" && cmb_MaNCC.Text != "" && txt_nhanvien.Text != "") // thong tin cho cac truong con lai
            {
                DateTime ngaytao = DateTime.Now;
                dtp_NgayTao.Value = ngaytao;
                String tensp = (String)cmb_MaSP.SelectedValue;
                string mahd = "HD" + new Random().Next(1, 1000).ToString();
                long dongia = long.Parse(txt_DonGia.Text);
                long soluong = long.Parse(txt_SoLuongMua.Text);
                long tongtien;

                if (dongia > 15000000)
                {
                    tongtien = (long)(soluong * dongia * 0.98); // Giảm giá 2%
                }
                else
                {
                    tongtien = soluong * dongia;
                }
               

                DataRow dongmoi = banghd.NewRow();
                dongmoi["mahd"] = mahd;
                dongmoi["ngaylap"] = ngaytao;
                dongmoi["tensp"] = tensp;
                dongmoi["makh"] = cmb_MaKH.SelectedValue;
                dongmoi["tenkh"] = cmb_TenKH.SelectedValue;
                dongmoi["manv"] = txt_nhanvien.Text;
                dongmoi["mancc"] = cmb_MaNCC.SelectedValue;
                dongmoi["soluong"] = soluong;
                dongmoi["dongia"] = txt_DonGia.Text;

                dongmoi["tongtien"] = tongtien;
                banghd.Rows.Add(dongmoi);

                // cap nhat csdl
                ketnoi.CapNhatDuLieu(bodocghi, banghd); // goi ham cap nhat
                banghd.Clear();
                HienThiDuLieu();
                MessageBox.Show("Đã tạo đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_DienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                //Từ chối kí tự được nhập vào
                e.Handled = true;
            }
        }

        private void cmb_GioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chặn các phím nhập
            if (e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btn_NhapLaiCSP_Click(object sender, EventArgs e)
        {
            ClearAll();
            HienNhanVien();
        }

        public void ClearAll()
        {
            cmb_MaSP.ResetText();
            cmb_MaNCC.ResetText();
            cmb_MaKH.ResetText();
            cmb_TenKH.ResetText();
            txt_DonGia.Clear();
            txt_SoLuongMua.Clear();
        }

        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            indonhang form = new indonhang();
            form.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                banghd.Rows[donghh].Delete();
                //capnhat
                ketnoi.CapNhatDuLieu(bodocghi, banghd);
                banghd.Clear();
                ClearAll();
                HienThiDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the xoa");
            }
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                cmb_MaKH.Text = banghd.Rows[donghh][0].ToString();
                cmb_MaNCC.Text = banghd.Rows[donghh][1].ToString();
                cmb_TenKH.Text = banghd.Rows[donghh][2].ToString();             
                txt_nhanvien.Text = banghd.Rows[donghh][3].ToString();
                string ngayTaoStr = banghd.Rows[donghh][4].ToString();
                DateTime ngayTao;
                if (DateTime.TryParseExact(ngayTaoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayTao))
                {
                    dtp_NgayTao.Value = ngayTao;
                }
            }
        }

        private void bt_cap_nhap_Click(object sender, EventArgs e)
        {
            ketnoi.CapNhatDuLieu(bodocghi, banghd);
            banghd.Clear();
            ClearAll();
            HienThiDuLieu();
        }
    }
}
