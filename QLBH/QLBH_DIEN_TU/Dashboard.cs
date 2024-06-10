﻿using QLBH_DIEN_TU.UC_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace QLBH_DIEN_TU
{
    public partial class Dashboard : Form
    {
        public bool isExit = true;
        public event EventHandler Logout;
        public static string quyen;//bien tinh de su dung cho form khac
        public string manv = "";
        public string tennv = "";

        
        public Dashboard(string manv, string tennv)
        {
            InitializeComponent();
            this.manv = manv;
            this.tennv = tennv;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
       
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            if (isExit)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình này?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Thoát chương trình
                    Application.Exit();
                }
                else
                {
                    //ở lại chương trình
                }
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            uc_SanPham1.Visible = false;
            uc_KhachHang1.Visible = false;
            uc_Phieunhap1.Visible = false;
            uc_DonHang1.Visible = false;
            uc_NhanVien1.Visible = false;
            uc_ThongKe1.Visible = false;
            

            if (quyen == "NhanVien")
            {
                btn_NhanVien.Enabled = false;
                btn_NhanVien.Visible = false;
                btn_ThongKe.Enabled = false;
                btn_ThongKe.Visible = false;
                btn_NCC.Enabled = false;
                bt_nhaphang.Enabled = false;
                labeltennhanvien.Text = tennv;
                uc_DonHang1.MaNV = manv;
                uc_DonHang1.HienNhanVien();

            }
            else if (quyen == "Admin")
            {
                btn_NhanVien.Enabled = true;
                btn_NhanVien.Visible = true;
                btn_ThongKe.Enabled = true;
                btn_ThongKe.Visible = true;
                btn_NCC.Enabled = true;
                bt_nhaphang.Enabled = true;
                labeltennhanvien.Text = tennv;
            }


        }

        private void btn_DonHang_Click(object sender, EventArgs e)
        {
            uc_DonHang1.Visible = true;
            uc_DonHang1.BringToFront();
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            uc_SanPham1.Visible = true;
            uc_SanPham1.BringToFront();
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            uc_KhachHang1.Visible = true;
            uc_KhachHang1.BringToFront();
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            uc_NhanVien1.Visible = true;
            uc_NhanVien1.BringToFront();
        }

        private void btn_NCC_Click(object sender, EventArgs e)
        {
            uc_NhaCungCap1.Visible = true;
            uc_NhaCungCap1.BringToFront();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            uc_ThongKe1.Visible = true;
            uc_ThongKe1.BringToFront();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
           //gọi hàm ủy thác
           Logout(this, new EventArgs());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btn_PhongTo_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btn_ThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Title_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void bt_nhaphang_Click(object sender, EventArgs e)
        {
            uc_Phieunhap1.Visible = true;
            uc_Phieunhap1.BringToFront();
        }
    }
}