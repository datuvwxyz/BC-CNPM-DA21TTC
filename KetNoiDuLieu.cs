using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBH_DIEN_TU
{
    internal class KetNoiDuLieu
    {
        public SqlConnection ketnoi;
        public SqlDataAdapter docghi;
        public SqlCommand lenh;
        public SqlCommandBuilder capnhat;

        public KetNoiDuLieu()
        {
            ketnoi = new SqlConnection();
            string chuoiketnoi = "Data Source=LAPTOP-BC8O984N\\SQLEXPRESS;Initial Catalog=QLBANHANGDT;Integrated Security=true";
            ketnoi.ConnectionString = chuoiketnoi;
        }

        public DataTable DocDuLieu(string sql)
        {
            ketnoi.Open();
            docghi = new SqlDataAdapter(sql, ketnoi);
            DataTable bangtam = new DataTable();
            docghi.Fill(bangtam);
            ketnoi.Close();
            return bangtam;
        }

        public void ThaoTacDuLieu(string sql, string message)
        {
            ketnoi.Open();
            lenh = new SqlCommand(sql, ketnoi);
            lenh.ExecuteNonQuery();
            ketnoi.Close();

            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CapNhatDuLieu(SqlDataAdapter bdg, DataTable dt)
        {
            capnhat = new SqlCommandBuilder(bdg);
            bdg.Update(dt);
        }

       
    }
}
