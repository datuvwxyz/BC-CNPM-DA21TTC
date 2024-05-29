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
    public partial class uc_ThongKe : UserControl
    {

        public uc_ThongKe()
        {
            InitializeComponent();
        }
        KetNoiDuLieu ketnoi = new KetNoiDuLieu();
        SqlDataAdapter bodocghi = new SqlDataAdapter();
        DataTable banghd = new DataTable();

        void HienThiDuLieu()
        {
            string sql = "select * from HOA_DON";
            banghd = ketnoi.DocDuLieu(sql);
            bodocghi = ketnoi.docghi;
            dgvDonHang.DataSource = banghd;
        }
        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            string searchText = txt_TheoSP.Text;
            DateTime selectedDate = dtp_TheoNgay.Value;

            // Lọc DataTable dựa trên các tiêu chí đã chọn
            DataRow[] filteredRows = banghd.Select($"tensp LIKE '%{searchText}%' AND ngaylap = '{selectedDate.ToString("yyyy-MM-dd")}'");

            // Sử dụng Dictionary để lưu trữ thông tin về số lượng và tổng tiền của mỗi mặt hàng
            Dictionary<string, int> sanPhamDictionary = new Dictionary<string, int>();
            Dictionary<string, decimal> tongTienDictionary = new Dictionary<string, decimal>();

            // Tính tổng số lượng và tổng tiền cho mỗi mặt hàng
            foreach (DataRow row in filteredRows)
            {
                string tensp = row["tensp"].ToString();
                int soluong = Convert.ToInt32(row["soluong"]);
                string tongtienString = row["tongtien"].ToString();

                // Chuyển đổi chuỗi tổng tiền thành kiểu decimal
                decimal tongtien = decimal.Parse(tongtienString);

                if (sanPhamDictionary.ContainsKey(tensp))
                {
                    // Nếu mặt hàng đã tồn tại trong Dictionary, cộng thêm số lượng mới vào số lượng hiện có
                    sanPhamDictionary[tensp] += soluong;
                    // Cộng thêm tổng tiền mới vào tổng tiền hiện có
                    tongTienDictionary[tensp] += tongtien;
                }
                else
                {
                    // Nếu mặt hàng chưa tồn tại trong Dictionary, thêm nó vào Dictionary với số lượng ban đầu và tổng tiền ban đầu
                    sanPhamDictionary.Add(tensp, soluong);
                    tongTienDictionary.Add(tensp, tongtien);
                }
            }

            // Hiển thị kết quả lọc một cách phù hợp
            string report;

            if (sanPhamDictionary.Count > 0)
            {
                report = $"Báo cáo: Số lượng sản phẩm '{searchText}' đã bán trong ngày {selectedDate.ToString("dd/MM/yyyy")}:\n\n";
                foreach (var kvp in sanPhamDictionary)
                {
                    string tensp = kvp.Key;
                    int soluong = kvp.Value;
                    decimal tongtien = tongTienDictionary[tensp];
                    report += $"{tensp}: {soluong} máy, Tổng tiền: {tongtien}\n";
                }
            }
            else
            {
                report = $"Không có sản phẩm nào được bán trong ngày {selectedDate.ToString("dd/MM/yyyy")}.";
            }

            // Hiển thị báo cáo trong MessageBox hoặc cách phù hợp khác
            MessageBox.Show(report, "Báo Cáo Số Lượng Sản Phẩm");
        }

        private void uc_ThongKe_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }
    }
    
}