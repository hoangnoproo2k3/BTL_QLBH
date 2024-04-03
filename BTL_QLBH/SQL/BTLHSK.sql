CREATE DATABASE BTLHSK 
-- Bỏ email, thêm giới tính ở bảng khách hàng --
-- Thêm số lượng hàng có sẵn trong kho ở bảng sản phẩm -- 
-- Thêm mức giảm giá cho chi tiết hóa đơn bán --
-- Xóa mã nhà cung cấp trong bảng đơn nhập -- 
-- Thêm lương cơ bản và phụ cấp, bỏ chức vụ --

-- Thêm khóa vào chi tiết hóa đơn

GO
CREATE TABLE tblLoaiHang
(
sMaLoai VARCHAR (20) PRIMARY KEY NOT NULL,
sTenLoai NVARCHAR (50) NOT NULL
)

CREATE TABLE tblNhaCungCap
(
sMaNCC VARCHAR (20) PRIMARY KEY NOT NULL,
sTenNCC NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL,
sSDT VARCHAR (10) NOT NULL
)

CREATE TABLE tblSanPham
(
sMaSanPham VARCHAR (50) PRIMARY KEY NOT NULL,
sTenSanPham NVARCHAR (50) NOT NULL, 
fDonGia FLOAT NOT NULL,
sNuocSX NVARCHAR (30) NOT NULL,
sMaLoai VARCHAR (20) NOT NULL,
sMaNCC VARCHAR (20) NOT NULL,
fSoLuongKho FLOAT NOT NULL,
dHanSD DATETIME NOT NULL
)

CREATE TABLE tblKhachHang
(
sMaKH VARCHAR (20) PRIMARY KEY NOT NULL,
sTenKh NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL,
dNgaySinh DATETIME NOT NULL,
sSDT VARCHAR (20) NOT NULL,
sGioiTinh NVARCHAR (10) NOT NULL,
)

CREATE TABLE tblNhanVien
(
sMaNV VARCHAR (20) PRIMARY KEY NOT NULL,
sTenNV NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL,
dNgaySinh DATETIME NOT NULL,
dNgayVaoLam DATETIME NOT NULL,
sCCCD VARCHAR (50) UNIQUE NOT NULL,
fLuongCoBan FLOAT NOT NULL,
fPhuCap FLOAT NOT NULL
)
CREATE TABLE tblQuyen
(
    MaQuyen VARCHAR (20) PRIMARY KEY NOT NULL,
    TenQuyen VARCHAR(50) NOT NULL, 
)
CREATE TABLE tblTaiKhoan
(
    MaTaiKhoan INT PRIMARY KEY NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL, 
    MatKhau VARCHAR(50) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    MaQuyen VARCHAR(20) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(sMaNV),
    FOREIGN KEY (MaQuyen) REFERENCES tblQuyen(MaQuyen)
)

CREATE TABLE tblCHITIET_HD_BANHANG
(
sSoHD VARCHAR (20) PRIMARY KEY NOT NULL,
sMaNV VARCHAR (20) NOT NULL,
sMaKH VARCHAR (20) NOT NULL,
dNgayLap DATETIME NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongMua FLOAT NOT NULL,
fDonGia FLOAT NOT NULL,
fMucGiamGia FLOAT NOT NULL,
fTongTien FLOAT NOT NULL,
)

CREATE TABLE tblCHITIET_HD_NHAPHANG
(
sSoHDNhap VARCHAR (20) PRIMARY KEY NOT NULL,
dNgayNhap DATETIME NOT NULL,
sMaNV VARCHAR (20) NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongNhap FLOAT NOT NULL,
fGiaNhap FLOAT NOT NULL,
fTongTien FLOAT NOT NULL,
)

-- Khóa ngoại sản phẩm với nhà sx, loại sp
ALTER TABLE tblSanPham 
ADD CONSTRAINT FK_sanPham_Loai FOREIGN KEY (sMaLoai) REFERENCES tblLoaiHang (sMaLoai)
ALTER TABLE tblSanPham 
ADD CONSTRAINT FK_sanPham_NCC FOREIGN KEY (sMaNCC) REFERENCES tblNhaCungCap(sMaNCC)

-- Khóa ngoại Đơn nhập với nhân viên, nhà cung cấp
-- Khóa ngoại hóa đon với nhân viên, khách hàng
-- Khóa ngoại chi tiết hóa đơn bán
ALTER TABLE tblCHITIET_HD_BANHANG
ADD CONSTRAINT FK_cthdBan_sanPham FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham (sMaSanPham),
CONSTRAINT FK_hoaDon_NV FOREIGN KEY (sMaNV) REFERENCES tblNhanVien (sMaNV),
CONSTRAINT FK_hoaDon_KH FOREIGN KEY (sMaKH) REFERENCES tblKhachHang (sMaKH) 

-- Khóa ngoại chi tiết hóa đơn nhập
ALTER TABLE tblCHITIET_HD_NHAPHANG
ADD CONSTRAINT FK_cthdNhap_sanPham FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham (sMaSanPham),
 CONSTRAINT FK_donNhap_NV FOREIGN KEY (sMaNV) REFERENCES tblNhanVien (sMaNV)


-- Chèn dữ liệu vào bảng
INSERT INTO tblQuyen
VALUES 
    ('Q01','Toàn Quyền'),
    ('Q02','Quản Trị Viên')

INSERT INTO tblTaiKhoan 
VALUES 
    (1,'admin','123456', 'NV01', 'Q01'),
    (2,'admin1', '123456', 'NV02','Q02');

-- tblLoaiMiPham
INSERT INTO tblLoaiHang(sMaLoai, sTenLoai)
VALUES ('L01', N'Thực Phẩm'),
	   ('L02', N'Đồ Gia Dụng'),
	   ('L03', N'Thiết Bị Điện Tử'),
	   ('L04', N'Quần Áo và Phụ Kiện'),
	   ('L05', N'Đồ Chơi và Trò Chơi'),
	   ('L06', N'Hàng Tiêu Dùng')


-- tblNhaCungCap
INSERT INTO tblNhaCungCap (sMaNCC,sTenNCC,sDiaChi,sSDT)
VALUES ('NCC01', 'ResHPCos', N'TP Hồ Chí Minh', '0949996969'),
	   ('NCC02', 'Công ty Việt Hương', N'Hà Nội', '0987654878'),
	   ('NCC03', 'Công ty Vincos Việt Nam', N'Hà Nội', '0982345651'),
	   ('NCC04', 'Công ty sản xuất hóa mỹ phẩm ViCO', N'Hà Nội', '0382030209'),
	   ('NCC05', 'Công ty cổ phần dược phẩm Fresh Life', N'Cần Thơ', '0376543768'),
	   ('NCC06', 'Công ty dược NPro', N'Đà Nẵng', '0398760990');

-- tblSanPham
INSERT INTO tblSanPham(sMaSanPham,sTenSanPham,fDonGia,sNuocSX,sMaLoai,sMaNCC,fSoLuongKho,dHanSD)
VALUES ('SP01',N'Sản Phẩm 1 của Thực Phẩm', 10.0, N'Việt Nam', 'L01', 'NCC01', 100, '2024-12-31'),
	   ('SP02',N'Sản Phẩm 2 của Thực Phẩm', 20.0, N'Việt Nam', 'L01', 'NCC01', 150, '2024-12-31'),
	   ('SP03',N'Sản Phẩm 1 của Đồ Gia Dụng', 15.0, N'Việt Nam', 'L02', 'NCC02', 120, '2024-12-31'),
	   ('SP04',  N'Sản Phẩm 2 của Đồ Gia Dụng', 25.0, N'Việt Nam', 'L02', 'NCC02', 180, '2024-12-31'),
	   ('SP05',  N'Sản Phẩm 1 của Thiết Bị Điện Tử', 100.0, N'Việt Nam', 'L03', 'NCC03', 80,'2027-03-08'),
	   ('SP06',N'Sản Phẩm 2 của Thiết Bị Điện Tử', 200.0, N'Việt Nam', 'L03', 'NCC03', 130,'2026-10-12'),
	   ('SP07', N'Sản Phẩm 1 của Quần Áo và Phụ Kiện', 50.0, N'Việt Nam', 'L04', 'NCC04', 90,'2027-10-12'),
	   ('SP08',  N'Sản Phẩm 2 của Quần Áo và Phụ Kiện', 70.0, N'Việt Nam', 'L04', 'NCC04', 120,'2028-10-06'),
	   ('SP09', N'Sản Phẩm 3 của Quần Áo và Phụ Kiện', 70.0, N'Việt Nam', 'L04', 'NCC05', 190, '2025-12-10')
