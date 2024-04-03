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

CREATE TABLE tblNhaSanXuat
(
sMaNSX NVARCHAR (20)PRIMARY KEY NOT NULL,
sTenNSX NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL
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
sMaNSX NVARCHAR (20) NOT NULL,
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

CREATE TABLE tblTaiKhoan
(
    MaTaiKhoan INT PRIMARY KEY NOT NULL,
    TenDangNhap VARCHAR(50) NOT NULL, 
    MatKhau VARCHAR(50) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(sMaNV)
)

CREATE TABLE tblHoaDon
(
sSoHD VARCHAR (20) PRIMARY KEY NOT NULL,
sMaNV VARCHAR (20) NOT NULL,
sMaKH VARCHAR (20) NOT NULL,
dNgayLap DATETIME NOT NULL
)

CREATE TABLE tblDonNhap
(
sSoHDNhap VARCHAR (20) PRIMARY KEY NOT NULL,
dNgayNhap DATETIME NOT NULL,
sMaNV VARCHAR (20) NOT NULL
)

CREATE TABLE tblCHITIET_HD_BANHANG
(
sSoHD VARCHAR (20) NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongMua FLOAT NOT NULL,
fDonGia FLOAT NOT NULL,
fMucGiamGia FLOAT NOT NULL,
PRIMARY KEY (sSoHD, sMaSanPham)
)

CREATE TABLE tblCHITIET_HD_NHAPHANG
(
sSoHDNhap VARCHAR (20) NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongNhap FLOAT NOT NULL,
fGiaNhap FLOAT NOT NULL,
PRIMARY KEY (sSoHDNhap, sMaSanPham)
)

-- Khóa ngoại sản phẩm với nhà sx, loại sp
ALTER TABLE tblSanPham 
ADD CONSTRAINT FK_sanPham_NSX FOREIGN KEY (sMaNSX) REFERENCES tblNhaSanXuat (sMaNSX)
ALTER TABLE tblSanPham 
ADD CONSTRAINT FK_sanPham_Loai FOREIGN KEY (sMaLoai) REFERENCES tblLoaiHang (sMaLoai)
ALTER TABLE tblSanPham 
ADD CONSTRAINT FK_sanPham_NCC FOREIGN KEY (sMaNCC) REFERENCES tblNhaCungCap(sMaNCC)

-- Khóa ngoại Đơn nhập với nhân viên, nhà cung cấp
ALTER TABLE tblDonNhap
ADD CONSTRAINT FK_donNhap_NV FOREIGN KEY (sMaNV) REFERENCES tblNhanVien (sMaNV)



-- Khóa ngoại hóa đon với nhân viên, khách hàng
ALTER TABLE tblHoaDon
ADD CONSTRAINT FK_hoaDon_NV FOREIGN KEY (sMaNV) REFERENCES tblNhanVien (sMaNV) ,
CONSTRAINT FK_hoaDon_KH FOREIGN KEY (sMaKH) REFERENCES tblKhachHang (sMaKH)

-- Khóa ngoại chi tiết hóa đơn bán
ALTER TABLE tblCHITIET_HD_BANHANG
ADD CONSTRAINT FK_cthdBan_sanPham FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham (sMaSanPham),
CONSTRAINT FK_cthdBan_HD FOREIGN KEY (sSoHD) REFERENCES tblHoaDon (sSoHD)

-- Khóa ngoại chi tiết hóa đơn nhập
ALTER TABLE tblCHITIET_HD_NHAPHANG
ADD CONSTRAINT FK_cthdNhap_sanPham FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham (sMaSanPham),
CONSTRAINT FK_cthdNhap_donNhap FOREIGN KEY (sSoHDNhap) REFERENCES tblDonNhap (sSoHDNhap)


-- Chèn dữ liệu vào bảng
-- tblLoaiMiPham
INSERT INTO tblLoaiHang(sMaLoai, sTenLoai)
VALUES ('L01', N'Sữa rửa mặt'),
	   ('L02', N'Sữa Fami'),
	   ('L03', N'Bim Bim Oishi'),
	   ('L04', N'Rong biển'),
	   ('L05', N'Dầu gội đầu'),
	   ('L06', N'Bánh gạo'),
	   ('L07', N'Mì tôm Hảo Hảo');

-- tblNhaSanXuat
INSERT INTO tblNhaSanXuat(sMaNSX,sTenNSX,sDiaChi)
VALUES ('NSX01', 'Cetaphil', N'Hà Nội'),
	   ('NSX02', 'Senka', N'TP Hồ Chí Minh'),
	   ('NSX03', 'Sunsilk', N'Cần Thơ'),
	   ('NSX04', 'Dove', N'Bắc Giang'),
	   ('NSX05', 'Vaseline', N'Hà Nội'),
	   ('NSX06', 'Innisfree', N'Đà Nẵng'),
	   ('NSX07', 'Sunplay', N'Hải Dương');

-- tblNhaCungCap
INSERT INTO tblNhaCungCap (sMaNCC,sTenNCC,sDiaChi,sSDT)
VALUES ('NCC01', 'ResHPCos', N'TP Hồ Chí Minh', '0949996969'),
	   ('NCC02', 'Công ty Việt Hương', N'Hà Nội', '0987654878'),
	   ('NCC03', 'Công ty Vincos Việt Nam', N'Hà Nội', '0982345651'),
	   ('NCC04', 'Công ty sản xuất hóa mỹ phẩm ViCO', N'Hà Nội', '0382030209'),
	   ('NCC05', 'Công ty cổ phần dược phẩm Fresh Life', N'Cần Thơ', '0376543768'),
	   ('NCC06', 'Công ty dược NPro', N'Đà Nẵng', '0398760990');

-- tblSanPham
INSERT INTO tblSanPham(sMaSanPham,sTenSanPham,fDonGia,sNuocSX,sMaNSX,sMaLoai,sMaNCC,fSoLuongKho,dHanSD)
VALUES ('SP01', N'Sữa rửa mặt Cetaphil 125ml', 100000, N'Mỹ', 'NSX01', 'L01', 'NCC01',1000, '2025-12-06'),
	   ('SP02', N'Nước tẩy trang Senka 125ml', 90000, N'Nhật bản', 'NSX02', 'L02', 'NCC02',1000, '2026-08-07'),
	   ('SP03', N'Dầu gội đầu Sunsilk 650g', 112000, N'Anh', 'NSX03', 'L05', 'NCC03',1000,'2025-09-09'),
	   ('SP04', N'Nước tẩy trang Dove 235ml', 98000, N'Anh', 'NSX04', 'L02', 'NCC04',1000,'2025-11-10'),
	   ('SP05', N'Son dưỡng môi Vaseline lô hội', 50000, N'Mỹ', 'NSX05', 'L03', 'NCC05',1000,'2027-03-08'),
	   ('SP06', N'Kem chống nắng Innisfree SPF50', 204000, N'Hàn Quốc', 'NSX06', 'L04', 'NCC01',1000,'2026-10-12'),
	   ('SP07', N'Kem chống nắng Sunplay SPF50+', 79000, N'Nhật Bản', 'NSX07', 'L04', 'NCC02',1000,'2027-10-12'),
	   ('SP08', N'Serum Innisfree trà xanh dưỡng ẩm 80ml', 506000, N'Hàn Quốc', 'NSX06', 'L06', 'NCC02',1000,'2028-10-06'),
	   ('SP09', N'Toner Innisfree trà xanh 160ml', 540000, N'Hàn Quốc', 'NSX06', 'L07', 'NCC02',1000, '2025-12-10'),
	   ('SP10', N'Sữa rửa mặt Senka  125ml', 65000, N'Nhật Bản', 'NSX02', 'L01', 'NCC03',1000, '2026-10-01'),
	   ('SP11', N'Nước tẩy trang Senka 230ml', 103000, N'Nhật Bản', 'NSX02', 'L02', 'NCC04',1000, '2026-10-02'),
	   ('SP12', N'Dầu gội đầu Dove 640g', 155000, N'Anh', 'NSX04', 'L05', 'NCC06',1000, '2026-10-03'),
	   ('SP13', N'Kem chống nắng Dove SPF 90', 250000, N'Anh', 'NSX04', 'L05', 'NCC06',1000, '2026-01-12'),
	   ('SP14', N'Sữa rửa mặt Innisfree trà xanh', 260000, N'Hàn Quốc', 'NSX06', 'L01', 'NCC06',1000, '2026-02-12'),
	   ('SP15', N'Son dưỡng môi Vaseline trà xanh', 50000, N'Mỹ', 'NSX05', 'L03', 'NCC02',1000, '2026-03-13');

-- tblNhanVien
INSERT INTO tblNhanVien(sMaNV,sTenNV,sDiaChi,dNgaySinh,dNgayVaoLam,sCCCD,fLuongCoBan,fPhuCap)
VALUES  ('NV01', N'Lê Văn Quang Huy', N'Hà Nội', '2003-12-22', '2022-06-07', '038203010792', 10000000, 500000),
	    ('NV02', N'Thân Khánh Huyền', N'Hà Nội', '2003-03-13', '2022-07-06', '038203010793', 10000000, 500000),
	    ('NV03', N'Nguyễn Đức Huy', N'Hà Nội', '1993-05-19', '2016-08-06', '037203010793', 10000000, 500000),
	    ('NV04', N'Ngô Quốc Linh', N'Thanh Hóa', '1992-04-16', '2014-07-06', '038123010793', 10000000, 500000),
	    ('NV05', N'Nguyễn Khánh Linh', N'Cần Thơ', '1995-04-07', '2017-09-03', '038203123793', 10000000, 500000),
	    ('NV06', N'Nguyễn Thu Nguyệt', N'Hà Nội', '2003-06-17', '2022-05-06', '031283010793', 10000000, 500000),
	    ('NV07', N'Nguyễn Thu Vân', N'Hà Nội', '2001-07-08', '2021-04-09', '038870019873', 10000000, 500000),
	    ('NV08', N'Nguyễn Văn Huy', N'Hà Nội', '2002-04-13', '2022-01-06', '038203000993', 10000000, 500000),
	    ('NV09', N'Nguyễn Ánh Ngọc', N'Hà Nội', '2003-10-01', '2022-09-06', '098203010793', 10000000, 500000),
	    ('NV10', N'Nguyễn Quang Ánh', N'Hà Nội', '2000-06-08', '2020-03-09', '038870019982', 10000000, 500000);

INSERT INTO tblTaiKhoan (MaTaiKhoan, TenDangNhap, MatKhau, MaNV)
VALUES 
    (1,'admin','123456', 'NV01'),
    (2,'admin1', '123456', 'NV02');

-- tblKhachHang
INSERT INTO tblKhachHang (sMaKH, sTenKh, sDiaChi, dNgaySinh, sSDT, sGioiTinh)
VALUES ('KH01', N'Tạ Quang Thắng', N'Hà Nội', '1993-04-07', '0912345765', N'Nam'),
	   ('KH02', N'Tạ Quang Huy', N'Hà Nội', '1995-05-06', '0999945765', N'Nam'),
	   ('KH03', N'Nguyễn Văn Linh', N'Hà Nội', '1996-03-07', '0912387699', N'Nam'),
	   ('KH04', N'Nguyễn Khánh Huyền', N'Hà Nội', '2002-05-07', '0912999699', N'Nữ'),
	   ('KH05', N'Nguyễn Thị Hòa', N'Thanh Hóa', '2000-02-09', '0983887699', N'Nữ');

--- tblHoaDon 
INSERT INTO tblHoaDon (sSoHD, sMaNV, sMaKH, dNgayLap)
VALUES ('HD01', 'NV05', 'KH01', '2022-07-08'),
	   ('HD02', 'NV05', 'KH02', '2021-09-03'),
	   ('HD03', 'NV07', 'KH03', '2022-01-03'),
	   ('HD04', 'NV06', 'KH04', '2022-09-01'),
	   ('HD05', 'NV05', 'KH05', '2022-10-01'),
	   ('HD06', 'NV07', 'KH01', '2022-10-01'),
	   ('HD07', 'NV07', 'KH01', '2022-10-02'),
	   ('HD08', 'NV04', 'KH02', '2022-10-03');

--tblChiTietHoaDon
INSERT INTO tblCHITIET_HD_BANHANG(sSoHD, sMaSanPham, fSoLuongMua, fDonGia,fMucGiamGia)
VALUES ('HD01', 'SP01', 2, 110000, 0),
	   ('HD02', 'SP05', 2, 80000, 0),
	   ('HD03', 'SP06', 2, 300000, 0),
	   ('HD04', 'SP07', 1, 100000, 0),
	   ('HD05', 'SP07', 1, 100000, 0),
	   ('HD06', 'SP08', 2, 550000, 0),
	   ('HD07', 'SP02', 3, 110000, 0),
	   ('HD08', 'SP02', 3, 110000, 0);

-- tblDonNhap
INSERT INTO tblDonNhap (sSoHDNhap, dNgayNhap, sMaNV)
VALUES ('HDN01', '2022-01-10', 'NV04'),
	   ('HDN02', '2022-02-10', 'NV04'),
	   ('HDN03', '2022-02-11', 'NV04'),
	   ('HDN04', '2022-02-12', 'NV05'),
	   ('HDN05', '2022-02-13', 'NV05'),
	   ('HDN06', '2022-02-14', 'NV06'),
	   ('HDN07', '2022-03-01', 'NV07'),
	   ('HDN08', '2022-03-05', 'NV10');

-- tblCHITIET_HD_NHAPMP

INSERT INTO tblCHITIET_HD_NHAPHANG (sSoHDNhap, sMaSanPham, fSoLuongNhap, fGiaNhap)
VALUES('HDN01', 'SP01', 50, 90000),
	  ('HDN02', 'SP02', 50, 80000),
	  ('HDN03', 'SP04', 50, 90000),
	  ('HDN04', 'SP03', 50, 100000),
	  ('HDN05', 'SP05', 50, 40000),
	  ('HDN06', 'SP07', 50, 70000),
	  ('HDN07', 'SP06', 50, 200000),
	  ('HDN08', 'SP08', 50, 500000)

-- Tạo view
-- Tạo view cho biết số lượng nhân viên
GO
CREATE VIEW [soLuongNhanVien]
AS
SELECT COUNT(tblNhanVien.sMaNV) AS N'Số lượng nhân viên' 
FROM tblNhanVien

-- Tạo view cho biết các sản phẩm đang bán tại cửa hàng 
-- (mã SP, tên SP, đơn giá, nước sản xuất)

GO
CREATE VIEW [cacSanPhamDangBan]
AS
SELECT 
tblSanPham.sMaSanPham AS N'Mã sản phẩm', tblSanPham.sTenSanPham AS N'Tên sản phẩm',
tblSanPham.fDonGia AS 'Đơn giá', tblSanPham.sNuocSX AS N'Nước sản xuất'
FROM tblSanPham

SELECT * FROM [cacSanPhamDangBan]

-- Tạo view cho biết số mĩ phẩm đang bán trong cửa hàng

GO
CREATE VIEW [soLuongMiPhamTrongCuaHang]
AS
SELECT SUM(tblCHITIET_HD_NHAPMP.fSoLuongNhap) AS 'TỔNG SỐ MĨ PHẨM NHẬP VỀ CỬA HÀNG'
FROM tblCHITIET_HD_NHAPMP

SELECT * FROM [soLuongMiPhamTrongCuaHang]

-- Tạo view tính tổng tiền của từng hóa đơn theo mã hóa đơn
GO
CREATE VIEW [tongTienCuaTungHoaDon]
AS
SELECT sSoHD AS N'Số hóa đơn', SUM(fSoLuongMua*fDonGia) AS N'Tổng tiền'
FROM tblCHITIET_HD_BANMP
GROUP BY sSoHD

SELECT * FROM [tongTienCuaTungHoaDon]

-- Tạo view tính tổng tiền nhập mĩ phẩm

GO
CREATE VIEW [tongTienNhapMiPham]
AS
SELECT SUM(fSoLuongNhap*fGiaNhap) AS N'Tổng tiền nhập mĩ phẩm'
FROM tblCHITIET_HD_NHAPMP 

SELECT * FROM [tongTienNhapMiPham]

-- Tạo view cho biết số lượng nhập từng loại sản phẩm

GO
CREATE VIEW [soLuongNhapTungLoaiSP]
AS
SELECT tblSanPham.sMaSanPham, tblSanPham.sTenSanPham, SUM(tblCHITIET_HD_NHAPMP.fSoLuongNhap) AS N'Số lượng nhập'
FROM tblSanPham INNER JOIN tblCHITIET_HD_NHAPMP
ON tblSanPham.sMaSanPham = tblCHITIET_HD_NHAPMP.sMaSanPham
GROUP BY tblSanPham.sMaSanPham, tblSanPham.sTenSanPham

SELECT * FROM [soLuongNhapTungLoaiSP]

-- Tạo view cho xem danh sách 3 khách hàng mua hàng nhiều nhất

GO
CREATE VIEW [3KhachHangMuaNhieuNhat]
AS
SELECT TOP(3) tblKhachHang.sMaKH AS N'Mã KH', tblKhachHang.sTenKH AS N'Tên KH', COUNT(tblHoaDon.sSoHD) AS N'Số lần đặt hàng'
FROM tblKhachHang, tblHoaDon
WHERE tblKhachHang.sMaKH = tblHoaDon.sMaKH
GROUP BY tblKhachHang.sMaKH, tblKhachHang.sTenKH
ORDER BY COUNT(tblHoaDon.sSoHD) DESC

SELECT * FROM [3KhachHangMuaNhieuNhat]

-- Tạo view cho biết số lượng đã bán của từng loại hàng năm 2021

GO
CREATE VIEW [soLuongDaBanTungLoai2021]
AS
SELECT tblSanPham.sMaLoai AS N'Mã loại', tblLoaiMiPham.sTenLoai AS N'Tên loại', SUM(tblCHITIET_HD_BANMP.fSoLuongMua) AS N'Số lượng đã bán'
FROM tblSanPham, tblCHITIET_HD_BANMP, tblHoaDon, tblLoaiMiPham
WHERE tblSanPham.sMaLoai = tblLoaiMiPham.sMaLoai
AND tblHoaDon.sSoHD = tblCHITIET_HD_BANMP.sSoHD
AND tblSanPham.sMaSanPham = tblCHITIET_HD_BANMP.sMaSanPham
AND YEAR(tblHoaDon.dNgayLap) = 2021
GROUP BY tblSanPham.sMaLoai, tblLoaiMiPham.sTenLoai

SELECT * FROM [soLuongDaBanTungLoai2021]

-- Tạo proc biết năm truyền vào, cho biết các nhân viên sinh vào năm đó
GO
CREATE PROC BirthNhanVien
@year INT
AS
BEGIN
	SELECT * FROM tblNhanVien 
	WHERE YEAR(dNgaySinh) = @year
END
EXEC BirthNhanVien 2003

SELECT * FROM tblSanPham
SELECT * FROM tblNhaSanXuat

-- Tạo proc biết tên nhà sản xuất, cho biết số sản phẩm nhập về từ nhà sản xuất đó
GO
CREATE PROC numberOfProducts
@tenNSX NVARCHAR (50) 
AS
BEGIN
	SELECT tblNhaSanXuat.sTenNSX AS N'Tên nhà sản xuất', SUM(tblCHITIET_HD_NHAPMP.fSoLuongNhap) AS N'Số sản phẩm nhập về'
	FROM tblNhaSanXuat, tblCHITIET_HD_NHAPMP, tblSanPham
	WHERE tblNhaSanXuat.sMaNSX = tblSanPham.sMaNSX
	AND tblSanPham.sMaSanPham = tblCHITIET_HD_NHAPMP.sMaSanPham
	AND tblNhaSanXuat.sTenNSX = @tenNSX
	GROUP BY tblNhaSanXuat.sTenNSX
END
EXEC numberOfProducts Cetaphil

-- Tạo thủ tục biết tham số truyền vào là mã nhà cung cấp, cho biết cửa hàng đã nhập bao nhiêu sản phẩm từ nhà cung cấp đó
GO
CREATE PROC numberOfProductFromProvider
@maNCC VARCHAR (20)
AS
BEGIN
	SELECT tblNhaCungCap.sMaNCC AS N'Mã nhà cung cấp', SUM(fSoLuongNhap) AS N'Số lượng sản phẩm đã nhập'
	FROM tblNhaCungCap, tblCHITIET_HD_NHAPMP, tblDonNhap,tblSanPham
	WHERE tblNhaCungCap.sMaNCC = tblSanPham.sMaNCC
	AND tblDonNhap.sSoHDNhap = tblCHITIET_HD_NHAPMP.sSoHDNhap
	AND tblSanPham.sMaSanPham=tblCHITIET_HD_NHAPMP.sMaSanPham
	GROUP BY tblNhaCungCap.sMaNCC
END
EXEC numberOfProductFromProvider NCC01

-- Tạo thủ tục chèn thêm dữ liệu vào bảng Sản Phẩm (Thêm điều kiện vào)
GO
CREATE PROC insertProduct
@sMaSanPham VARCHAR (50), @sTenSanPham NVARCHAR (50), @fDonGia FLOAT, @sNuocSX NVARCHAR (30), 
@sMaNSX VARCHAR (20), @sMaLoai VARCHAR (20), @sMaNCC VARCHAR (20), @soluongtrongkho FLOAT
AS
BEGIN
INSERT INTO tblSanPham 
VALUES (@sMaSanPham, @sTenSanPham, @fDonGia, @sNuocSX, @sMaNSX, @sMaLoai, @sMaNCC, @soluongtrongkho)
END
EXEC insertProduct 'SP16', N'Sữa rửa mặt Cetaphil 500ml', 315000, N'Mỹ', 'NSX01', 'L01', 'NCC01', 50

-- Tạo thủ tục với tham số truyền vào là mã loại, in ra thông tin của các sản phẩm thuộc loại đó
GO
CREATE PROC ProductTypeInformation
@sMaLoai VARCHAR (20)
AS 
BEGIN
SELECT * FROM tblSanPham
WHERE tblSanPham.sMaLoai = @sMaLoai
END
EXEC ProductTypeInformation L01


-- Trigger kiểm soát nhân viên vào làm phải trên 18 tuổi
-- Trigger kiểm soát số lượng bán không được vượt quá số lượng tồn (tổng hàng nhập - số hàng đã bán)
-- Trigger để khi nhập sản phẩm, số lượng không quá 500 một lần
-- Trigger kiểm soát giá bán luôn lớn hơn giá nhập
-- Trigger tính tổng tiền tự động

-- Trigger kiểm soát nhân viên vào làm phải trên 18 tuổi
GO
CREATE TRIGGER nhanVienPhaiTren18 ON tblNhanVien
FOR INSERT
AS
BEGIN
	DECLARE @ngaysinh DATETIME
	SELECT @ngaysinh = dNgaySinh FROM INSERTED
	IF (DATEDIFF(YEAR, @ngaysinh, GETDATE()) < 18)
	BEGIN
		PRINT N'Nhân viên không hợp lệ vì chưa đủ 18 tuổi'
		ROLLBACK TRAN
	END
END

-- Trigger kiểm soát số lượng bán không được vượt quá số lượng tồn (tổng hàng nhập - số hàng đã bán)
GO
CREATE TRIGGER soLuongBanVaTon ON tblCHITIET_HD_BANMP
FOR INSERT
AS
BEGIN
	DECLARE @sohd VARCHAR (20), @hanghienco FLOAT, @hangbanra FLOAT, @mahang VARCHAR (50)
	SELECT @sohd = sSoHD, @hangbanra = fSoLuongMua, @mahang = sMaSanPham FROM INSERTED
	SELECT @hanghienco = 
	(
	SELECT tblSanPham.fSoLuongKho 
	FROM tblSanPham
	WHERE tblSanPham.sMaSanPham = @mahang
	)
	IF (@hangbanra > @hanghienco)
		BEGIN
			PRINT N'Không hợp lệ vì lượng hàng bán ra lớn hơn lượng hàng hiện có'
			ROLLBACK TRAN
		END
END

-- Trigger để khi nhập sản phẩm, số lượng không quá 500 một lần
GO
CREATE TRIGGER nhapKhongQua50 ON tblCHITIET_HD_NHAPMP
FOR INSERT
AS
BEGIN
	DECLARE @soluongnhap FLOAT
	SELECT @soluongnhap = fSoLuongNhap FROM INSERTED
	IF (@soluongnhap > 500)
	BEGIN
		PRINT N'Nhập quá số lượng cho phép!'
		ROLLBACK TRAN
	END
END

-- Trigger kiểm soát giá bán luôn lớn hơn giá nhập
GO
CREATE TRIGGER giaBanLonHonGiaNhap ON tblCHITIET_HD_BANMP
FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @giaban FLOAT, @gianhap FLOAT, @mahang VARCHAR (50)
	SELECT @giaban = fDonGia FROM INSERTED
	SELECT @gianhap = 
		(
		SELECT fGiaNhap 
		FROM tblCHITIET_HD_NHAPMP
		WHERE tblCHITIET_HD_NHAPMP.sMaSanPham = @mahang
		)
	IF (@giaban <= @gianhap)
		BEGIN
			PRINT N'Không hợp lệ vì giá bán nhỏ hơn hoặc bằng giá nhâp!'
			ROLLBACK TRAN
		END
END

-- Trigger tính tổng tiền tự động 
-- THÊM CỘT TỔNG TIỀN CHO KHÁCH HÀNG
ALTER TABLE tblKhachHang ADD fTongTien FLOAT NOT NULL DEFAULT (0)
GO 
ALTER TRIGGER tongTienTuDong ON tblCHITIET_HD_BANMP
AFTER INSERT 
AS
BEGIN
DECLARE @maKH  VARCHAR (20), @soHD VARCHAR(50), @tongtien FLOAT
SELECT @soHD = sSoHD
FROM inserted
SELECT @maKH = 
	(
	SELECT sMaKH
	FROM tblHoaDon
	WHERE tblHoaDon.sSoHD = @soHD
	)
SELECT @tongtien = 
	( 
	SELECT SUM (fDonGia * fSoLuongMua * (1-fMucGiamGia))
	FROM tblCHITIET_HD_BANMP
	WHERE tblCHITIET_HD_BANMP.sSoHD = @soHD
	GROUP BY sSoHD
	)
UPDATE tblKhachHang SET fTongTien = @tongtien WHERE sMaKH = @maKH
END
ALTER TABLE tblCHITIET_HD_BANMP ENABLE TRIGGER tongTienTuDong

INSERT INTO tblCHITIET_HD_BANMP 
VALUES ('HD02', 'SP07', 2, 100000, 0)

INSERT INTO tblCHITIET_HD_BANMP 
VALUES ('HD02', 'SP02', 2, 110000, 0)

INSERT INTO tblCHITIET_HD_BANMP 
VALUES ('HD03', 'SP07', 2, 100000, 0)

INSERT INTO tblCHITIET_HD_BANMP 
VALUES ('HD03', 'SP02', 2, 110000, 0)

DELETE FROM tblCHITIET_HD_BANMP 
WHERE sMaSanPham = 'SP07'
AND sSoHD = 'HD02'

DELETE FROM tblCHITIET_HD_BANMP 
WHERE sMaSanPham = 'SP02'
AND sSoHD = 'HD02'


DELETE FROM tblCHITIET_HD_BANMP 
WHERE sMaSanPham = 'SP07'
AND sSoHD = 'HD03'

DELETE FROM tblCHITIET_HD_BANMP 
WHERE sMaSanPham = 'SP02'
AND sSoHD = 'HD03'

-- PHÂN QUYỀN 
-- Tạo login và user

CREATE LOGIN LeVanQuangHuy WITH PASSWORD = '0000'
CREATE USER LeVanQuangHuy_User FOR LOGIN LeVanQuangHuy

CREATE LOGIN ThanKhanhHuyen WITH PASSWORD = '0000'
CREATE USER ThanKhanhHuyen_User FOR LOGIN ThanKhanhHuyen

CREATE LOGIN NguyenAnhNgoc WITH PASSWORD = '0000'
CREATE USER NguyenAnhNgoc_User FOR LOGIN NguyenAnhNgoc

CREATE LOGIN NguyenVanHuy WITH PASSWORD = '0000'
CREATE USER NguyenVanHuy_User FOR LOGIN NguyenVanHuy

-- Cấp tất cả các quyền cho user LeVanQuangHuy_User trên bảng tblKhachHang
GRANT ALL ON tblKhachHang TO LeVanQuangHuy

-- Cấp quyền chèn, sửa cho user ThanKhanhHuyen_User trên bảng tblNhanVien
GRANT INSERT, ALTER ON tblNhanVien to ThanKhanhHuyen_User

-- Cấp quyền xóa cho user NguyenAnhNgoc_User trên bảng tblSanPham
GRANT DELETE ON tblSanPham to NguyenAnhNgoc_User

-- Cấp quyền cập nhật cho user NguyenVanHuy_User trên bảng tblNhaCungCap
GRANT UPDATE ON tblNhaCungCap to NguyenVanHuy_User

-- tạo linked server
EXEC master.dbo.sp_addlinkedserver 
@server = N'LINKED_SERVER_1',
@provider = N'SQLOLEDB', 
@datasrc = N'HUY', 
@srvproduct = N'Sql2K8'

-- đăng nhập vào linked server
EXEC master.dbo.sp_addlinkedsrvlogin 
@rmtsrvname = N'LINKED_SERVER_1', 
@useself = N'False', 
@locallogin = NULL, 
@rmtuser = N'test', 
@rmtpassword = '0000'

-- Phân tán ngang bảng nhân viên, nhân viên trên 22 tuổi để ở server2, còn lại tại server 2 tạo bản tblNhanVien

-- Insert vào bảng tblNhanVien ở trạm 2
INSERT INTO LINKED_SERVER_1.BTL.dbo.tblNhanVien_Tram2
SELECT * FROM tblNhanVien WHERE (DATEDIFF(DAY,tblNhanVien.dNgaySinh,GETDATE()) >= 7920)

SELECT * FROM LINKED_SERVER_1.BTL.dbo.tblNhanVien_Tram2

-- Thủ tục lưu lấy danh sách các nhà cung cấp mà số lượng nhập > x
CREATE PROC cau1
@soluong FLOAT
AS
BEGIN
SELECT tblNhaCungCap.sMaNCC AS N'Mã nhà cung cấp', 
tblNhaCungCap.sTenNCC AS N'Tên nhà cung cấp', 
sum(tblCHITIET_HD_NHAPMP.fSoLuongNhap) AS N'Tổng số lượng nhâp', 
sum(tblCHITIET_HD_NHAPMP.fGiaNhap*tblCHITIET_HD_NHAPMP.fSoLuongNhap) AS N'Tổng giá trị nhâp'
FROM tblNhaCungCap
JOIN tblSanPham ON tblNhaCungCap.sMaNCC = tblSanPham.sMaNCC
JOIN tblCHITIET_HD_NHAPMP ON tblCHITIET_HD_NHAPMP.sMaSanPham = tblSanPham.sMaSanPham
JOIN tblDonNhap ON tblCHITIET_HD_NHAPMP.sSoHDNhap = tblDonNhap.sSoHDNhap
GROUP BY tblNhaCungCap.sMaNCC, tblNhaCungCap.sTenNCC
HAVING sum(tblCHITIET_HD_NHAPMP.fSoLuongNhap) > @soluong
END

EXEC cau1 70

-- Trigger để tăng số lượng sản phẩm mỗi khi sản phẩm được nhập thêm
CREATE TRIGGER cau2
ON tblCHITIET_HD_NHAPMP
AFTER INSERT
AS
BEGIN
	DECLARE @maSP VARCHAR (50), @soluongnhap FLOAT
	SELECT @maSP = INSERTED.sMaSanPham, @soluongnhap = INSERTED.fSoLuongNhap
	FROM INSERTED
	UPDATE tblSanPham
	SET fSoLuongKho = fSoLuongKho + @soluongnhap
	WHERE @maSP = sMaSanPham
END

INSERT INTO tblCHITIET_HD_NHAPMP 
VALUES ('HDN01', 'SP16', 1, 310000)

--
CREATE TRIGGER cau1
ON tblCHITIET_HD_BANMP
INSTEAD OF INSERT 
AS
BEGIN
	DECLARE @sSoHD VARCHAR (20), @sMaSanPham VARCHAR (50), @fSoLuongMua FLOAT, @fDonGia FLOAT, @fMucGiamGia FLOAT, @count FLOAT
	SELECT @sSoHD = sSoHD, @sMaSanPham = sMaSanPham, @fSoLuongMua = fSoLuongMua, @fDonGia = fDonGia, @fMucGiamGia = fMucGiamGia
	FROM INSERTED
	SELECT @count = a.soHoaDon
	FROM ( SELECT sSoHD, COUNT (sSoHD) AS [soHoaDon] 
		FROM tblCHITIET_HD_BANMP
		WHERE @sSoHD = sSoHD
		GROUP BY sSoHD ) AS a
	IF @count <= 3
		BEGIN
			INSERT INTO dbo.tblCHITIET_HD_BANMP (sSoHD, sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia)
			VALUES (@sSoHD, @sMaSanPham, @fSoLuongMua, @fDonGia, @fMucGiamGia)
		END
	ELSE 
		BEGIN 
			PRINT N'Hoa don da du 3 chi tiet'
			ROLLBACK TRAN
		END
END

CREATE LOGIN abc WITH PASSWORD = '1234'
CREATE USER abc_user FOR LOGIN abc
CREATE ROLE Thi_R 
ALTER ROLE Thi_R ADD MEMBER abc_user
GRANT SELECT ON tblCHITIET_HD_BANMP TO Thi_R
DENY SELECT ON tblHoaDon TO Thi_R

CREATE SYNONYM tblCTHD_Tram2 FOR LINKED_SERVER_1.BTL.dbo.tblCHITIET_HD_BANMP
CREATE SYNONYM tblHoaDon_Tram2 FOR LINKED_SERVER_1.BTL.dbo.tblHoaDon
CREATE TRIGGER cau1_2
ON tblCTHD_Tram2
INSTEAD OF INSERT 
AS
BEGIN
	DECLARE @sSoHD VARCHAR (20), @sMaSanPham VARCHAR (50), @fSoLuongMua FLOAT, @fDonGia FLOAT, @fMucGiamGia FLOAT, @count FLOAT
	SELECT @sSoHD = sSoHD, @sMaSanPham = sMaSanPham, @fSoLuongMua = fSoLuongMua, @fDonGia = fDonGia, @fMucGiamGia = fMucGiamGia
	FROM INSERTED
	SELECT @count = a.soHoaDon
	FROM ( SELECT sSoHD, COUNT (sSoHD) AS [soHoaDon] 
		FROM tblCTHD_Tram2
		WHERE @sSoHD = sSoHD
		GROUP BY sSoHD ) AS a
	IF @count <= 3
		BEGIN
			INSERT INTO tblCTHD_Tram2 (sSoHD, sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia)
			VALUES (@sSoHD, @sMaSanPham, @fSoLuongMua, @fDonGia, @fMucGiamGia)
		END
	ELSE 
		BEGIN 
			PRINT N'Hoa don da du 3 chi tiet'
			ROLLBACK TRAN
		END
END





-- BTL HSK (CAI NAY KHONG CAN QUAN TAM)

create proc themLoaiHang(@maloai VARCHAR (20),
@tenloai NVARCHAR (50))
	as
	begin
	insert into tblLoaiHang values(@maloai, @tenloai)
	end
	GO

CREATE proc hienLoaiHang
	as
	begin 
	select * from tblLoaiHang
	end
	go 

CREATE PROC xoaLoaiHang (@maloai VARCHAR(20))
AS
BEGIN
DELETE FROM tblLoaiHang WHERE tblLoaiHang.sMaLoai = @maloai
END 
GO

CREATE PROC suaLoaiHang (@maloai VARCHAR (20),
@tenloai NVARCHAR (50))
AS
BEGIN
UPDATE tblLoaiHang 
SET sMaLoai = @maloai, sTenLoai = @tenloai
WHERE sMaLoai = @maloai
END
GO

CREATE PROC layMaLoaiHang (@maloai VARCHAR (10))
AS
BEGIN
SELECT sMaLoai FROM tblLoaiHang 
WHERE tblLoaiHang.sMaLoai = @maloai
END
GO

-- PROC THÊM NHÂN VIÊN
DROP PROC themNhanVien
create proc themNhanVien(@manv VARCHAR (20),
@tennv NVARCHAR (50),
@diachi NVARCHAR (50),
@ngaysinh DATETIME,
@ngayvaolam DATETIME,
@cccd VARCHAR (50),
@luongcoban FLOAT,
@phucap FLOAT)
	as
	begin
	insert into tblNhanVien values(@manv, @tennv, @diachi, @ngaysinh, @ngayvaolam, @cccd, @luongcoban, @phucap)
	end
	GO

-- PROC HIỆN NHÂN VIÊN
CREATE proc hienNhanVien
	as
	begin 
	select * from tblNhanVien
	end
	go 

EXEC hienNhanVien

-- PROC XÓA NHÂN VIÊN
GO
ALTER PROC xoaNhanVien (@maNV VARCHAR(20))
AS
BEGIN
DELETE FROM tblNhanVien WHERE tblNhanVien.sMaNV = @maNV
END 
GO

-- PROC SỬA NHÂN VIÊN
CREATE PROC suaNhanVien (@manv VARCHAR (20),
@tennv NVARCHAR (50),
@diachi NVARCHAR (50),
@ngaysinh DATETIME,
@ngayvaolam DATETIME,
@cccd VARCHAR (50),
@luongcoban FLOAT,
@phucap FLOAT)
AS
BEGIN
UPDATE tblNhanVien 
SET sMaNV = @manv, sTenNV = @tennv, sDiaChi = @diachi, dNgaySinh = @ngaysinh, dNgayVaoLam = @ngayvaolam, sCCCD = @cccd, fLuongCoBan = @luongcoban, fPhuCap = @phucap
WHERE sMaNV = @manv
END
GO

-- PROC Tìm Nhân Viên
CREATE PROC timNhanVien (@manv VARCHAR (20))
AS
BEGIN
SELECT * FROM tblNhanVien WHERE tblNhanVien.sMaNV = @manv
END

EXEC timNhanVien NV01

EXEC suaNhanVien 

CREATE PROCEDURE sapXepNhanVienTheoLuongCoBanTangDan
AS
BEGIN
    SELECT * 
    FROM tblNhanVien 
    ORDER BY tblNhanVien.fLuongCoBan ASC;
END

DELETE FROM tblDonNhap 
DELETE FROM tblCHITIET_HD_NHAPMP
DELETE FROM tblCHITIET_HD_BANMP
DELETE FROM tblHoaDon

-- PROC HIỆN SẢN PHẨM
CREATE proc hienSanPham
	as
	begin 
	select sMaSanPham AS 'Mã SP', sTenSanPham AS 'Tên SP', fDonGia AS 'Đơn giá', sNuocSX AS 'Nước SX', sMaNSX AS 'Mã NSX', 
	sMaLoai AS 'Mã loại', sMaNCC AS 'Mã NCC', fSoLuongKho AS 'Số lượng kho' 
	from tblSanPham
	end
	go 
EXEC hienSanPham

DROP PROC hienSanPham

-- Proc thêm sản phẩm
GO
CREATE PROC themSanPham(@maSP VARCHAR(50), 
						@tenSP NVARCHAR(50), 
						@donGia FLOAT, 
						@nuocSanXuat NVARCHAR (30), 
						@maNSX VARCHAR (20), 
						@maLoai VARCHAR (20), 
						@maNCC VARCHAR (20), 
						@soLuongKho FLOAT) 
AS
BEGIN
INSERT INTO tblSanPham VALUES (@maSP, 
							   @tenSP, 
							   @donGia, 
							   @nuocSanXuat, 
							   @maNSX, 
							   @maLoai, 
							   @maNCC, 
							   @soLuongKho)
END

-- Proc Xóa sản phẩm
GO 
CREATE PROC xoaSanPham (@maSP VARCHAR (50))
AS
BEGIN
DELETE FROM tblSanPham WHERE tblSanPham.sMaSanPham = @maSP
END
-- Proc update sản phẩm
GO
CREATE PROC suaSanPham (@maSP VARCHAR(50), 
						@tenSP NVARCHAR(50), 
						@donGia FLOAT, 
						@nuocSanXuat NVARCHAR (30), 
						@maNSX VARCHAR (20), 
						@maLoai VARCHAR (20), 
						@maNCC VARCHAR (20), 
						@soLuongKho FLOAT) 
AS
BEGIN
UPDATE tblSanPham
SET sMaSanPham = @maSP,
	sTenSanPham = @tenSP,
	fDonGia = @donGia,
	sNuocSX = @nuocSanXuat,
	sMaNSX = @maNSX,
	sMaLoai = @maLoai, 
	sMaNCC = @maNCC,
	fSoLuongKho = @soLuongKho
WHERE sMaSanPham = @maSP
END

-- Proc hiện khách hàng
GO 
CREATE PROC hienKhachHang
AS
BEGIN
SELECT * FROM tblKhachHang
END

-- Proc lấy giới tính
GO 
CREATE PROC layGioiTinhKhachHang
AS
BEGIN
SELECT sGioiTinh FROM tblKhachHang
END

-- Proc thêm khách hàng
GO 
CREATE PROC themKhachHang (@maKH VARCHAR (20),
						   @tenKH NVARCHAR (50),
						   @diaChi NVARCHAR (50),
						   @ngaySinh DATETIME,
						   @sdt VARCHAR (20),
						   @gioiTinh NVARCHAR (10),
						   @tongTien FLOAT)
AS
BEGIN
INSERT INTO tblKhachHang VALUES (@maKH, @tenKH, @diaChi, @ngaySinh, @sdt, @gioiTinh, @tongTien)
END

-- Proc sửa khách hàng
GO
CREATE PROC suaKhachHang (@maKH VARCHAR (20),
						   @tenKH NVARCHAR (50),
						   @diaChi NVARCHAR (50),
						   @ngaySinh DATETIME,
						   @sdt VARCHAR (20),
						   @gioiTinh NVARCHAR (10),
						   @tongTien FLOAT)
AS
BEGIN
UPDATE tblKhachHang SET sMaKH = @maKH,
						sTenKh = @tenKH,
						sDiaChi = @diaChi,
						dNgaySinh = @ngaySinh,
						sSDT = @sdt,
						sGioiTinh = @gioiTinh,
						fTongTien = @tongTien
WHERE sMaKH = @maKH
END

-- PROC Xóa khách hàng
GO
CREATE PROC xoaKhachHang (@maKH VARCHAR(20))
AS
BEGIN
DELETE FROM tblKhachHang WHERE tblKhachHang.sMaKH = @maKH
END 
GO

INSERT INTO tblHoaDon (sSoHD, sMaNV, sMaKH, dNgayLap) VALUES (HD01, NV01, KH01, '2022-07-08')


-- Proc hiện hóa đơn
GO
CREATE PROC hienHoaDon
AS
BEGIN
SELECT * FROM tblHoaDon
END

-- Proc thêm hóa đơn
GO
CREATE PROC themHoaDon (@sohd VARCHAR(20), @manv VARCHAR (20), @makh VARCHAR(20), @ngaylap DATETIME)
AS
BEGIN
INSERT INTO tblHoaDon VALUES (@sohd, @manv, @makh, @ngaylap)
END

-- Proc sửa hóa đơn
GO
CREATE PROC suaHoaDon (@sohd VARCHAR(20), @manv VARCHAR (20), @makh VARCHAR(20), @ngaylap DATETIME)
AS
BEGIN
UPDATE tblHoaDon
SET sSoHD = @sohd, sMaNV = @manv, sMaKH = @makh, dNgayLap = @ngaylap
WHERE sSoHD = @sohd
END

ALTER TABLE tblHoaDon DROP CONSTRAINT FK_hoaDon_NV;
ALTER TABLE tblHoaDon DROP CONSTRAINT FK_hoaDon_KH;
ALTER TABLE tblHoaDon ADD CONSTRAINT FK_hoaDon_NV FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV) ON DELETE CASCADE
ALTER TABLE tblHoaDon ADD CONSTRAINT FK_hoaDon_KH FOREIGN KEY (sMaKH) REFERENCES tblKhachHang(sMaKH) ON DELETE CASCADE

CREATE TABLE tblTaiKhoan 
(
sTenDangNhap VARCHAR (50),
sMatKhau VARCHAR (50),
sEmail VARCHAR (50)
)