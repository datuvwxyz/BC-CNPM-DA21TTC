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

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_NhaCungCap : UserControl
    {
        public uc_NhaCungCap()
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi = new SqlDataAdapter();
        DataTable bangncc = new DataTable();
        int donghh;

        void HienThiDuLieu()
        {
            string sql = "select *from NHA_CUNG_CAP";
            bangncc = ketnoi.DocDuLieu(sql);
            bodocghi = ketnoi.docghi;
            dgvNCC.DataSource = bangncc;
        }

        private void uc_NhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }



        private void btn_ThemNCC_Click(object sender, EventArgs e)
        {
            if (txt_MaNCC.Text != "")
            {
                DataRow dongmoi = bangncc.NewRow();
                dongmoi["mancc"] = txt_MaNCC.Text;
                dongmoi["tenncc"] = txt_TenNCC.Text;
                dongmoi["diachi"] = txt_DiaChiNCC.Text;
                dongmoi["sdt"] = txt_DtNCC.Text;
                bangncc.Rows.Add(dongmoi);
                //cap nhat
                ketnoi.CapNhatDuLieu(bodocghi, bangncc);
                bangncc.Clear();
                ClearAll();
                HienThiDuLieu();
            }
        }

        private void btn_SuaNCC_Click(object sender, EventArgs e)
        {
            bangncc.Rows[donghh][0] = txt_MaNCC.Text;
            bangncc.Rows[donghh][1] = txt_TenNCC.Text;
            bangncc.Rows[donghh][2] = txt_DiaChiNCC.Text;
            bangncc.Rows[donghh][3] = txt_DtNCC.Text;
            //capnhat
            ketnoi.CapNhatDuLieu(bodocghi, bangncc);
            bangncc.Clear();
            ClearAll();
            HienThiDuLieu();
        }

        private void btn_XoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                bangncc.Rows[donghh].Delete();
                //capnhat
                ketnoi.CapNhatDuLieu(bodocghi, bangncc);
                bangncc.Clear();
                ClearAll();
                HienThiDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the xoa");
            }
        }

        private void btn_NhapLaiNCC_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txt_MaNCC.Text = bangncc.Rows[donghh][0].ToString();
                txt_TenNCC.Text = bangncc.Rows[donghh][1].ToString();
                txt_DiaChiNCC.Text = bangncc.Rows[donghh][2].ToString();
                txt_DtNCC.Text = bangncc.Rows[donghh][3].ToString();
                txt_MaNCC.Enabled = false;
            }
        }

        private void txt_TimKiemNCC_TextChanged(object sender, EventArgs e)
        {
            string sql = "select *from NHA_CUNG_CAP where tenncc like '%" + txt_TimKiemNCC.Text + "%'";
            DataTable dt = ketnoi.DocDuLieu(sql);
            dgvNCC.DataSource = dt;
        }

        public void ClearAll()
        {
            txt_MaNCC.Clear();
            txt_TenNCC.Clear();
            txt_DiaChiNCC.Clear();
            txt_DtNCC.Clear();
        }

        private void uc_NhaCungCap_Leave(object sender, EventArgs e)
        {
            ClearAll();
            txt_MaNCC.Enabled = true;
        }

        private void btn_RefeshNCC_Click(object sender, EventArgs e)
        {
            uc_NhaCungCap_Load(this, null);
        }

        private void txt_DtNCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                //Từ chối kí tự được nhập vào
                e.Handled = true;
            }
        }

        ExportNCC exportNCC = new ExportNCC();

        private void btn_Export_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("Mã nhà cung cấp");
            DataColumn col2 = new DataColumn("Tên nhà cung cấp");
            DataColumn col3 = new DataColumn("Địa chỉ");
            DataColumn col4 = new DataColumn("Điện thoại");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);

            foreach (DataGridViewRow dtgvRow in dgvNCC.Rows) 
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;

                dataTable.Rows.Add(dtrow);
            }
            exportNCC.ExportFileNCC(dataTable, "DANH SÁCH NHÀ CUNG CẤP", "DANH SÁCH NHÀ CUNG CẤP");
        }
    }
}
