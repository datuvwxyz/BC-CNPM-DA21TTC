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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QLBH_DIEN_TU.UC_control
{
    public partial class uc_Phieunhap : UserControl
    {
        public uc_Phieunhap()
        {
            InitializeComponent();
        }
        // Khai bao doi tuong
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi;
        DataTable bangpn = new DataTable();
        int donghh;
        // hien thi du lieu
        void HienThiDuLieu()
        {
            string sql = "select* from PHIEU_NHAP";
            bangpn = ketnoi.DocDuLieu(sql); // goi ham trong lop
            bodocghi = ketnoi.docghi;   // gan gia tri
            dgvpn.DataSource = bangpn;

        }
        void Load_cmb_NCC()
        {
            string sql = "select* from NHA_CUNG_CAP";
            cmb_MaNCC.DataSource = ketnoi.DocDuLieu(sql);
            cmb_MaNCC.DisplayMember = "mancc";
            cmb_MaNCC.ValueMember = "mancc";

        }

        void Load_cmb_MaNV()
        {
            string sql = "select* from NHAN_VIEN";
            cmbmanv.DataSource = ketnoi.DocDuLieu(sql);
            cmbmanv.DisplayMember = "manv";
            cmbmanv.ValueMember = "manv";

        }
        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (txtmapn.Text != "" && cmb_MaNCC.Text != "" && txttenspm.Text != "" && txtsoluongnhap.Text != "" && txtgianhap.Text != "") // thong tin cho cac truong con lai
            {
                DateTime ngaynhap = DateTime.Now;
                dtp_ngaynhap.Value = ngaynhap;
                DataRow dongmoi = bangpn.NewRow();
                dongmoi["mapn"] = txtmapn.Text;
                dongmoi["tenspm"] = txttenspm.Text;
                dongmoi["soluongnhap"] = txtsoluongnhap.Text;
                dongmoi["mancc"] = cmb_MaNCC.Text;
                dongmoi["gianhap"] = txtgianhap.Text;
                dongmoi["ngaynhap"] = ngaynhap;
                dongmoi["manv"] = cmbmanv.Text;
                dongmoi["ghichu"] = txtghichu.Text;
                bangpn.Rows.Add(dongmoi);
                //cap nhat
                ketnoi.CapNhatDuLieu(bodocghi, bangpn);
                bangpn.Clear();
                ClearAll();
                HienThiDuLieu();
                MessageBox.Show("Đã nhập hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void uc_Phieunhap_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            Load_cmb_NCC();
            Load_cmb_MaNV();
            txtmapn.Enabled = true;

        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                bangpn.Rows[donghh].Delete();
                //cap nhat CSDL
                ketnoi.CapNhatDuLieu(bodocghi, bangpn); // goiham cap nhat
                bangpn.Clear();
                HienThiDuLieu();
            }
            catch (Exception)
            {
                MessageBox.Show("Khong the xoa");
            }
        }

        private void uc_Phieunhap_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvpn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            donghh = e.RowIndex;
            if (donghh >= 0)
            {
                txtmapn.Text = bangpn.Rows[donghh][0].ToString();
                txttenspm.Text = bangpn.Rows[donghh][1].ToString();
                txtsoluongnhap.Text = bangpn.Rows[donghh][2].ToString();
                cmb_MaNCC.Text = bangpn.Rows[donghh][3].ToString();
                txtgianhap.Text = bangpn.Rows[donghh][4].ToString();
                dtp_ngaynhap.Text = bangpn.Rows[donghh][5].ToString();
                cmbmanv.Text = bangpn.Rows[donghh][6].ToString();
                txtghichu.Text = bangpn.Rows[donghh][7].ToString();
                txtmapn.Enabled = false;
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            bangpn.Rows[donghh][0] = txtmapn.Text;
            bangpn.Rows[donghh][1] = txttenspm.Text;
            bangpn.Rows[donghh][2] = txtsoluongnhap.Text;
            bangpn.Rows[donghh][3] = cmb_MaNCC.Text;
            bangpn.Rows[donghh][4] = txtgianhap.Text;
            bangpn.Rows[donghh][5] = dtp_ngaynhap.Text;
            bangpn.Rows[donghh][6] = cmbmanv.Text;
            bangpn.Rows[donghh][7] = txtghichu.Text;


            //cap nhat CSDL;
            ketnoi.CapNhatDuLieu(bodocghi, bangpn); // goiham cap nhat
            bangpn.Clear();
            HienThiDuLieu();
        }
        public void ClearAll()
        {
            cmb_MaNCC.ResetText();
            txtmapn.Clear();
            txttenspm.ResetText();
            txtsoluongnhap.Clear();
            txtgianhap.Clear();
            txtghichu.Clear();
            cmbmanv.ResetText();
        }

        private void btn_NhapLaiCSP_Click(object sender, EventArgs e)
        {
            ClearAll();
            uc_Phieunhap_Load(this, null);
        }


        ExportPN exportPN = new ExportPN();
        private void bt_xuatfile_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();

            DataColumn col1 = new DataColumn("MÃ PHIẾU NHẬP");
            DataColumn col2 = new DataColumn("TÊN SẢN PHẨM MỚI");
            DataColumn col3 = new DataColumn("SỐ LƯỢNG NHẬP");
            DataColumn col4 = new DataColumn("MÃ NHÀ CUNG CẤP");
            DataColumn col5 = new DataColumn("GÍA NHẬP");
            DataColumn col6 = new DataColumn("NGÀY NHẬP");
            DataColumn col7 = new DataColumn("MÃ NV");
            DataColumn col8 = new DataColumn("GHI CHÚ");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);


            foreach (DataGridViewRow dtgvRow in dgvpn.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;
                dtrow[7] = dtgvRow.Cells[7].Value;



                dataTable.Rows.Add(dtrow);
            }
            exportPN.ExportFileSP(dataTable, "Danh sách sản phẩm mới nhập ", "DANH SÁCH SẢN PHẨM MỚI NHẬP");
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void uc_Phieunhap_Leave(object sender, EventArgs e)
        {
            uc_Phieunhap_Load(this, null);
        }
    }
}
