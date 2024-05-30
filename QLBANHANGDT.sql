-- Tao co so du lieu
CREATE DATABASE QLBANHANGDT;
go 
use QLBANHANGDT
go

-- Tao bang KHACH HANG
CREATE TABLE KHACH_HANG (
  makh VARCHAR(50) NOT NULL,
  tenkh NVARCHAR(50) NOT NULL,
  gioitinh NVARCHAR(10) NOT NULL,
  sdt_kh INT NOT NULL,
  diachi NVARCHAR(50) NOT NULL,
  PRIMARY KEY (makh)
);
-- Tạo bảng NHANVIEN
CREATE TABLE NHAN_VIEN (
  manv VARCHAR(50) NOT NULL,
  tennv NVARCHAR(50) NOT NULL,
  gioitinh NVARCHAR (10) NOT NULL,
  diachi NVARCHAR(50) NOT NULL,
  sdt_nv INT NOT NULL,
  taikhoan VARCHAR(50) NOT NULL,
  matkhau VARCHAR(50) NOT NULL,
  quyen VARCHAR(20) NOT NULL,
  PRIMARY KEY (manv)
);


-- Tạo bảng NHACUNGCAP
CREATE TABLE NHA_CUNG_CAP (
  mancc VARCHAR(50) NOT NULL,
  tenncc NVARCHAR(100) NOT NULL,
  diachi NVARCHAR(200) NOT NULL,
  sdt INT NOT NULL,
  PRIMARY KEY (mancc)
);

-- Tạo bảng SANPHAM
CREATE TABLE SAN_PHAM (
  masq VARCHAR(50) NOT NULL,
  mancc VARCHAR(50) NOT NULL,
  tensp NVARCHAR(100) NOT NULL,
  soluongsp INT NOT NULL,
  thongso NVARCHAR(200) NOT NULL,
  giaban INT NOT NULL,
  PRIMARY KEY (masq),
  FOREIGN KEY (mancc) REFERENCES NHA_CUNG_CAP(mancc)
);

-- Tạo bảng HOADON
CREATE TABLE HOA_DON (
  mahd VARCHAR(50) NOT NULL,
  ngaylap DATE NOT NULL,
  tensp NVARCHAR(50) NOT NULL,
  makh VARCHAR(50) NOT NULL,
  tenkh NVARCHAR(50) NOT NULL,
  manv VARCHAR(50) NOT NULL,
  mancc VARCHAR(50) NOT NULL,
  dongia INT NOT NULL,
  soluong INT NOT NULL,
  tongtien FLOAT NOT NULL,
  PRIMARY KEY (mahd),
  FOREIGN KEY (manv) REFERENCES NHAN_VIEN(manv),
  FOREIGN KEY (makh) REFERENCES KHACH_HANG(makh),
  FOREIGN KEY (mancc) REFERENCES NHA_CUNG_CAP(mancc)
);

-- Tạo bảng PHIEU_NHAP 
CREATE TABLE  PHIEU_NHAP(
  mapn VARCHAR(20) NOT NULL,
  tenspm NVARCHAR(50) NOT NULL,
  soluongnhap INT NOT NULL,
  mancc VARCHAR(50) NOT NULL,
  gianhap INT  NOT NULL,
  ngaynhap Date NOT NULL,
  manv VARCHAR(50) NOT NULL,
  ghichu NVARCHAR(50),
	
  PRIMARY KEY (Mapn),
  
  FOREIGN KEY (manv) REFERENCES NHAN_VIEN (manv),
  FOREIGN KEY (mancc) REFERENCES NHA_CUNG_CAP (mancc)

);
-- Them du lieu bang KHACH HANG
INSERT INTO KHACH_HANG (makh, tenkh, gioitinh, sdt_kh, diachi)
VALUES
('KH001',N'Nguyễn Văn Anh',N'Nam', '0345678900',N'Khóm 1, Phường 6, TP.Trà Vinh, Tỉnh Trà Vinh '),
('KH002', N'Nguyễn Thị Bình', N'Nữ', '0987654300', N'Khóm 2, Phường 7, TP.Trà Vinh, Tỉnh Trà Vinh'),
('KH003', N'Trần Văn Cảnh', N'Nam', '0778901234', N'Khóm 3, Phường 8, TP.Trà Vinh, Tỉnh Trà Vinh'),
('KH004', N'Lê Thị Thúy Duy', N'Nữ', '0345678901', N'Khóm 4, Phường 9, TP.Trà Vinh, Tỉnh Trà Vinh'),
('KH005', N'Phan Văn Lĩnh', N'Nam', '0980123456', N'Huyện Châu Thành, Tỉnh Trà Vinh'),
('KH006', N'Trương Thị Hồng', N'Nữ', '0356789012', N'Huyện Càng Long, Tỉnh Trà Vinh'),
('KH007', N'Hoàng Văn Giang', N'Nam', '0981245678', N'Huyện Cầu Kè , Tỉnh Trà Vinh'),
('KH008', N'Võ Thị Hồng Hạnh', N'Nữ', '0767890123', N'Huyện Tiểu Cần, Tỉnh Trà Vinh'),
('KH009', N'Đặng Văn Linh', N'Nam', '0987654321', N'Khóm 1, Phường 1, TP.Trà Vinh, Tỉnh Trà Vinh'),
('KH010', N'Nguyễn Thị Thùy Dương', N'Nữ','0765413109', N'Khóm 2, Phường 4, TP.Trà Vinh, Tỉnh Trà Vinh');
  
-- Thêm dữ liệu bảng NHANVIEN
INSERT INTO NHAN_VIEN (manv, tennv, gioitinh, diachi, sdt_nv, taikhoan, matkhau, quyen)
VALUES 
  ('NV000', N'Admin', N'Nam', N'Khóm 1, Phường 1, TP.Trà Vinh, Tỉnh Trà Vinh', 0980456789, 'admin','abc','Admin'),
  ('NV001', N'Nguyễn Thị An', N'Nữ', N'Khóm 1, Phường 1, TP.Trà Vinh, Tỉnh Trà Vinh', 0323456789, 'annguyen','123','NhanVien'),
  ('NV002', N'Trần Văn Bình', 'Nam', N'Khóm 2, Phường 1, TP.Trà Vinh, Tỉnh Trà Vinh', 0987654321,'binhtran','123','NhanVien'),
  ('NV003', N'Trần Nguyễn Anh Khoa', 'Nam', N'Khóm 3, Phường 2, TP.Trà Vinh, Tỉnh Trà Vinh', 0987654321,'khoatran','123','NhanVien'),
  ('NV004', N'Đào Văn Việt', 'Nam', N'Khóm 4, Phường 2, TP.Trà Vinh, Tỉnh Trà Vinh', 0734567899,'vietdao','123','NhanVien'),
  ('NV005', N'Nguyễn Phước Toàn', 'Nam', N'Khóm 5, Phường 3, TP.Trà Vinh, Tỉnh Trà Vinh', 0730987621,'toannguyen','123','NhanVien'),
  ('NV006', N'Nguyễn Thị Hân', 'Nữ', N'Khóm 5, Phường 4, TP.Trà Vinh, Tỉnh Trà Vinh', 0356789012,'hannguyen','123','NhanVien'),
  ('NV007', N'Nguyễn Phước Tân ', 'Nam', N'Khóm 6, Phường 5, TP.Trà Vinh, Tỉnh Trà Vinh', 0987654321,'tannguyen','123','NhanVien'),
  ('NV008', N'Cao Văn Trí', 'Nam', N'Khóm 7, Phường 6, TP.Trà Vinh, Tỉnh Trà Vinh', 0367890123,'tricao','123','NhanVien'),
  ('NV009', N'Nguyễn Ngọc Thiên Kim', 'Nữ', N'Khóm 8, Phường 7, TP.Trà Vinh, Tỉnh Trà Vinh', 0986543211,'kimnguyen','123','NhanVien'),
  ('NV010', N'Nguyễn Ngọc Linh', 'Nữ', N'Khóm 1, Phường 8, TP.Trà Vinh, Tỉnh Trà Vinh', 0986543219,'linhnguyen','123','NhanVien');



-- Thêm dữ liệu bảng NHACUNGCAP
INSERT INTO NHA_CUNG_CAP (mancc, tenncc, diachi, sdt)
VALUES 
  ('NCC001', 'APPLE', N'Apple Inc. 1 Apple Park Way, Cupertino, CA 95014, United States', 1899611010),
  ('NCC002', 'DELL', N'23 Nguyễn Thị Huỳnh, Phường 8, Quận Phú Nhuận, Thành phố Hồ Chí Minh', 1800282848),
  ('NCC003', 'SAMSUNG', N'Khu công nghiệp Yên Bình, Đồng Tiến, Phổ Yên, Thái Nguyên', 0208357715),
  ('NCC004', 'HP', N'162 Hai Bà Trưng, Đa Kao, Quận 1, Hồ Chí Minh, Việt Nam', 1800588868),
  ('NCC005', 'OPPO', N'Số 27 Nguyễn Trung Trực, Phường Bến Thành, Quận 1, Thành phố Hồ Chí Minh, Việt Nam', 0283822984),
  ('NCC006', 'LENOVO', N'Phòng 1701A, Tầng 17, Empress Tower, 138-142 Hai Bà Trưng, Phường Đa Kao, Quận 1, Hồ Chí Minh, Việt Nam', 0203843504),
  ('NCC007', 'XIAOMI', N'343 Trần Khát Chân, Phường Thanh Nhàn, Quận Hai Bà Trưng, Hà Nội', 1900555567),
  ('NCC008', 'ASUS', N'324/26 Hoàng Văn Thụ, Phường 4, Quận Tân Bình, TP HCM', 0938880967);
  -- Thêm dữ liệu bảng SANPHAM
INSERT INTO SAN_PHAM (masq, mancc, tensp,soluongsp ,thongso, giaban)
VALUES 
  ('SP001', 'NCC001', N'Điện thoại iPhone 12', '3', N'pin: 2815 mAh; dung lượng lưu trữ: 64GB; RAM:4GB; Màn hình: 6.1 inch', '15000000'),
  ('SP002', 'NCC002', N'Laptop Dell XPS 13 Plus 9320 2022','3', N'CPU: i5; RAM: 16GB; Đĩa cứng: 512GB; Màn hình: 13.4 inch ', '25000000'),
  ('SP003', 'NCC003', N'Điện thoại Samsung Galaxy S21','4', N'pin: 5000mAh; dung lượng lưu trữ: 128GB; RAM: 12GB; size: 6.8 inch', '30000000'),
  ('SP004', 'NCC004', N'Laptop HP 15s fq5162TU i5','3',N'CPU: i5; RAM: 8GB; Ổ cứng: 512GB; Màn hình: 15.6 inch','15590000'),
  ('SP005', 'NCC005', N'Điện thoại OPPO Reno8 T 5G 256GB','7', N'pin: 4800 mAh; dung lượng lưu trữ: 256GB; RAM: 8GB; Màn hình: 6.7 inch', '9990000'),
  ('SP006', 'NCC006', N'Laptop Lenovo LOQ Gaming 15IRH8 i5','1', N'CPU: i5; RAM: 16GB; Ổ cứng: 512GB; Màn hình: 15.6 inch', '26990000'),
  ('SP007', 'NCC007', N'Điện thoại Xiaomi Redmi Note 12 Pro 5G','3', N'pin: 5000 mAh; dung lượng lưu trữ: 256GB; RAM: 8GB; Màn hình: 6.67 inch', '7990000'),
  ('SP008', 'NCC008', N'Laptop Asus TUF Gaming F15 FX507ZC4 i5','3', N'CPU: i5; RAM: 16GB; Ổ cứng: 1 TB SSD M.2 PCIe; Màn hình: 15.6 inch', '21990000'),
  ('SP009', 'NCC001', N'Laptop MacBook Air 15 inch M2 2023', '6',N'CPU: Apple M2100GB/s; RAM: 16GB; Ổ cứng: 256GB SSD; Màn hình: 15.3 inch', '36490000');

-- Thêm dữ liệu bảng HOADON
INSERT INTO HOA_DON (mahd, ngaylap, tensp, mancc, makh, tenkh, manv, dongia, soluong, tongtien)
VALUES 
  ('HD001', '2023-01-01', N'Điện thoại iPhone 12','NCC001','KH001', N'Nguyễn Văn An' ,'NV001', '15000000', 2, '30000000'),
  ('HD002', '2023-01-02', N'Laptop Dell XPS 13 Plus 9320 2022','NCC003','KH002',N'Nguyễn Thị Bình','NV002', '25000000', 1, '25000000'),
  ('HD003', '2023-01-02', N'Laptop Dell XPS 13 Plus 9320 2022','NCC003','KH006',N'Nguyễn Thị An','NV003', '25000000', 1, '25000000');

 
-- Them du lieu PHIEU_NHAP  
INSERT INTO PHIEU_NHAP(mapn, tenspm, soluongnhap, mancc, gianhap, ngaynhap, manv, ghichu)
VALUES
   ('PN001', N'Điện thoại iPhone 12', '3', 'NCC001', '14490000', '2023-11-10', 'NV001', ''),
   ('PN002', N'Laptop Dell XPS 13 Plus 9320 2022', '4', 'NCC002', '24190000', '2023-11-15', 'NV001', ''),
   ('PN003', N'Điện thoại Samsung Galaxy S21', '2', 'NCC003', '29000000', '2023-11-14', 'NV002', ''),
   ('PN004', N'Laptop HP 15s fq5162TU i5', '3', 'NCC004', '15000000', '2023-11-17', 'NV002', ''),
   ('PN005', N'Điện thoại OPPO Reno8 T 5G 256GB', '3', 'NCC005', '8990000', '2023-11-10', 'NV001', '');

   
   

  