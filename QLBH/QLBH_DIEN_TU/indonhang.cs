using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QLBH_DIEN_TU
{
    public partial class indonhang : Form
    {
        public indonhang()
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        DataTable banghd = new DataTable();
        private object hOA_DONTableAdapter;

        void LoadDonHang()
        {
            string sql = "select* from HOA_DON";
            cmbmahd.DataSource = ketnoi.DocDuLieu(sql);
            cmbmahd.DisplayMember = "mahd";
            cmbmahd.ValueMember = "mahd";
        }

        private void indonhang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLBANHANGDTDataSet.HOA_DON' table. You can move, or remove it, as needed.
            this.rpv_hoadon.RefreshReport();
            LoadDonHang();
            this.rpv_hoadon.RefreshReport();
        }

        private void bt_inhoadon_Click(object sender, EventArgs e)
        {
            string sql = "select* from HOA_DON where mahd like '%" + cmbmahd.SelectedValue + "%'";
            banghd = ketnoi.DocDuLieu(sql);
            rpv_hoadon.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rpv_hoadon.LocalReport.ReportPath = "Report_indonhang.rdlc";
            if (banghd.Rows.Count > 0)
            {
                ReportDataSource nguondl = new ReportDataSource();
                nguondl.Name = "indonhang";
                nguondl.Value = banghd;
                rpv_hoadon.LocalReport.DataSources.Clear();
                rpv_hoadon.LocalReport.DataSources.Add(nguondl);
                rpv_hoadon.RefreshReport();
            }

        }
    }
}
