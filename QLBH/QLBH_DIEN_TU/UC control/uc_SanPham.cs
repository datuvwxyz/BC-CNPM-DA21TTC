using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_SanPham : UserControl
    {
        public uc_SanPham()
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi = new SqlDataAdapter();
        DataTable bangsp = new DataTable();
        int donghh;

        void HienThiDuLieu()
        {
            string sql = "select *from SAN_PHAM";
            bangsp = ketnoi.DocDuLieu(sql);
            bodocghi = ketnoi.docghi;
            dgvSanPham.DataSource = bangsp;
        }

        public void HienNCC()
        {
            string sql = "select *from NHA_CUNG_CAP";
            cmb_MaNCC.DataSource = ketnoi.DocDuLieu(sql);
            cmb_MaNCC.DisplayMember = "tenncc";
            cmb_MaNCC.ValueMember = "mancc";
        }

        private void uc_SanPham_Load(object sender, EventArgs e)
        {
            cmb_MaNCC.SelectedIndex = 0;
            HienThiDuLieu();
            HienNCC();
        }

        private void btn_ThemSP_Click(object sender, EventArgs e)
        {
            if (txt_MaSP.Text != "")
            {
                DataRow dongmoi = bangsp.NewRow();
                dongmoi["masq"] = txt_MaSP.Text;          
                dongmoi["tensp"] = txt_TenSP.Text;
                dongmoi["soluongsp"]= txt_soluongsp.Text;
                dongmoi["mancc"] = cmb_MaNCC.SelectedValue;
                dongmoi["thongso"] = txt_ThongSo.Text;
                dongmoi["giaban"] = txt_GiaBan.Text;
                bangsp.Rows.Add(dongmoi);
                //cap nhat
                ketnoi.CapNhatDuLieu(bodocghi, bangsp);
                bangsp.Clear();
                ClearAll();
                HienThiDuLieu();
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                bangsp.Rows[donghh].Delete();
                //capnhat
                ketnoi.CapNhatDuLieu(bodocghi, bangsp);
                bangsp.Clear();
                ClearAll();
                HienThiDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the xoa");
            }
        }

        private void btn_SuaSP_Click(object sender, EventArgs e)
        {
            bangsp.Rows[donghh][0] = txt_MaSP.Text;
            bangsp.Rows[donghh][1] = cmb_MaNCC.Text;
            bangsp.Rows[donghh][2] = txt_TenSP.Text;
            bangsp.Rows[donghh][3] = txt_soluongsp.Text;
            bangsp.Rows[donghh][4] = txt_ThongSo.Text;
            bangsp.Rows[donghh][5] = txt_GiaBan.Text;
            //capnhat
            ketnoi.CapNhatDuLieu(bodocghi, bangsp);
            bangsp.Clear();
            ClearAll();
            HienThiDuLieu();
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txt_MaSP.Text = bangsp.Rows[donghh][0].ToString();
                cmb_MaNCC.Text = bangsp.Rows[donghh][1].ToString();
                txt_TenSP.Text = bangsp.Rows[donghh][2].ToString();
                txt_soluongsp.Text = bangsp.Rows[donghh][3].ToString();
                txt_ThongSo.Text = bangsp.Rows[donghh][4].ToString();
                txt_GiaBan.Text = bangsp.Rows[donghh][5].ToString();
                txt_MaSP.Enabled = false;
                cmb_MaNCC.Enabled = false;
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

        public void ClearAll()
        {
            txt_soluongsp.Clear();
            txt_MaSP.Clear();
            txt_TenSP.Clear();
            cmb_MaNCC.ResetText();
            txt_GiaBan.Clear();
            txt_ThongSo.Clear();
        }

        private void txt_FullProductName_TextChanged(object sender, EventArgs e)
        {
            string sql = "select *from SAN_PHAM where tensp like N'%" + txt_FullProductName.Text + "%'";
            DataTable dt = ketnoi.DocDuLieu(sql);
            dgvSanPham.DataSource = dt;
        }

        private void uc_SanPham_Leave(object sender, EventArgs e)
        {
            ClearAll();
            txt_MaSP.Enabled = true;
            cmb_MaNCC.Enabled = true;
        }

        private void btn_NhapLaiSP_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btn_Refesh_Click(object sender, EventArgs e)
        {
            uc_SanPham_Load(this, null);
        }

        private void cmb_MaNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chặn các phím nhập
            if (e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        ExportSP exportSP = new ExportSP();

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("Mã sản phẩm");
            DataColumn col2 = new DataColumn("Tên sản phẩm");
            DataColumn col3 = new DataColumn("Số lượng sp");
            DataColumn col4 = new DataColumn("Mã NCC");
            DataColumn col5 = new DataColumn("Thông số");
            DataColumn col6 = new DataColumn("Giá bán");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);

            foreach (DataGridViewRow dtgvRow in dgvSanPham.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;

                dataTable.Rows.Add(dtrow);
            }
            exportSP.ExportFileSP(dataTable, "Danh sách sản phẩm", "DANH SÁCH SẢN PHẨM");
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_soluongsp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
