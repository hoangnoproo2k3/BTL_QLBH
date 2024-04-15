CREATE DATABASE BTLHSK_1404
GO
CREATE TABLE tblNhanVien
(
sMaNV VARCHAR (20) PRIMARY KEY NOT NULL,
sTenNV NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL,
dNgaySinh Date NOT NULL,
dNgayVaoLam Date NOT NULL,
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
    MaTaiKhoan INT PRIMARY KEY IDENTITY,
    TenDangNhap VARCHAR(50) NOT NULL, 
    MatKhau VARCHAR(50) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    MaQuyen VARCHAR(20) NOT NULL,
    FOREIGN KEY (MaNV) REFERENCES tblNhanVien(sMaNV),
    FOREIGN KEY (MaQuyen) REFERENCES tblQuyen(MaQuyen)
)

CREATE TABLE tblNhaCungCap
(
sMaNCC VARCHAR (20) PRIMARY KEY NOT NULL,
sTenNCC NVARCHAR (50) NOT NULL,
sDiaChi NVARCHAR (50) NOT NULL,
sSDT VARCHAR (10) NOT NULL
)
CREATE TABLE tblLoaiHang
(
sMaLoai VARCHAR (20) PRIMARY KEY NOT NULL,
sTenLoai NVARCHAR (50) NOT NULL
)
--ALTER TABLE tblLoaiHang
--ADD sGhiChu VARCHAR (255)

CREATE TABLE tblSanPham
(
sMaSanPham VARCHAR (50) PRIMARY KEY NOT NULL,
sTenSanPham NVARCHAR (50) NOT NULL, 
fDonGia FLOAT NOT NULL,
sMaLoai VARCHAR (20) NOT NULL,
sMaNCC VARCHAR (20) NOT NULL,
fSoLuongKho FLOAT NOT NULL,
dHanSD DATETIME NOT NULL,
FOREIGN KEY (sMaNCC) REFERENCES tblNhaCungCap(sMaNCC),
FOREIGN KEY (sMaLoai) REFERENCES tblLoaiHang(sMaLoai)
)

CREATE TABLE tblHoaDon
(
sSoHD INT PRIMARY KEY IDENTITY,
sMaNV VARCHAR (20) NOT NULL,
sTenKH VARCHAR (20) NOT NULL,
sSDT VARCHAR (20) NOT NULL,
fTongTien FLOAT,
FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV),
dNgayLap DATE NOT NULL
)

CREATE TABLE tblCHITIET_HD_BANHANG
(
sSoHD INT NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongMua FLOAT NOT NULL,
fDonGia FLOAT NOT NULL,
fMucGiamGia FLOAT NOT NULL,
PRIMARY KEY (sSoHD, sMaSanPham),
FOREIGN KEY (sSoHD) REFERENCES tblHoadon(sSoHD),
FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham(sMaSanPham),
)
CREATE TABLE tblDonNhap
(
sSoHDNhap INT PRIMARY KEY IDENTITY,
dNgayNhap DATE NOT NULL,
sMaNV VARCHAR (20) NOT NULL,
fTongTien FLOAT,
FOREIGN KEY (sMaNV) REFERENCES tblNhanVien(sMaNV),
)

CREATE TABLE tblCHITIET_HD_NHAPHANG
(
sSoHDNhap  INT NOT NULL,
sMaSanPham VARCHAR (50) NOT NULL,
fSoLuongNhap FLOAT NOT NULL,
fGiaNhap FLOAT NOT NULL,
PRIMARY KEY (sSoHDNhap, sMaSanPham),
FOREIGN KEY (sSoHDNhap) REFERENCES tblDonNhap(sSoHDNhap),
FOREIGN KEY (sMaSanPham) REFERENCES tblSanPham(sMaSanPham)
)
go

-- Chèn dữ liệu vào bảng
INSERT INTO tblNhanVien (sMaNV, sTenNV, sDiaChi, dNgaySinh, dNgayVaoLam, sCCCD, fLuongCoBan, fPhuCap) 
VALUES 
('NV001', N'Trần Văn A', N'123 Đường ABC', '1990-01-15', '2010-05-20', '123456789', 5000000, 1000000),
('NV002', N'Nguyễn Thị B', N'456 Đường XYZ', '1995-08-20', '2015-10-10', '987654321', 6000000, 1500000);
INSERT INTO tblQuyen (MaQuyen, TenQuyen)
VALUES 
('Q1', N'Quản lý'),
('Q2', N'Nhân viên');
INSERT INTO tblTaiKhoan ( TenDangNhap, MatKhau, MaNV, MaQuyen) 
VALUES 
('admin', 'admin123', 'NV001', 'Q1'),
('user', 'user123', 'NV002', 'Q2');
INSERT INTO tblNhaCungCap (sMaNCC, sTenNCC, sDiaChi, sSDT) 
VALUES 
('NCC001', N'Công ty A', N'789 Đường DEF', '0123456789'),
('NCC002', N'Công ty B', N'101 Đường GHI', '0987654321');
INSERT INTO tblLoaiHang (sMaLoai, sTenLoai) 
VALUES 
('LH001', N'Điện thoại di động'),
('LH002', N'Laptop');
INSERT INTO tblSanPham (sMaSanPham, sTenSanPham, fDonGia, sMaLoai, sMaNCC, fSoLuongKho, dHanSD) 
VALUES 
('SP001', N'iPhone 12', 25000000, 'LH001', 'NCC001', 100, '2024-04-06'),
('SP002', N'MacBook Pro', 40000000, 'LH002', 'NCC002', 50, '2024-04-06'),
('SP003', N'Samsung Galaxy S21', 20000000, 'LH001', 'NCC003', 80, '2024-04-06'),
('SP004', N'Dell XPS 15', 35000000, 'LH002', 'NCC002', 70, '2024-04-06'),
('SP005', N'Canon EOS R5', 60000000, 'LH003', 'NCC001', 30, '2024-04-06'),
('SP006', N'PlayStation 5', 15000000, 'LH001', 'NCC002', 90, '2024-04-06'),
('SP007', N'Nike Air Jordan 1', 5000000, 'LH002', 'NCC001', 120, '2024-04-06');

--====================== Produre hóa đơn và chi tiết hóa đơn
go
CREATE TYPE dbo.CHITIET_HD_BANHANG_Details AS TABLE
(
    sMaSanPham VARCHAR(50),
    fSoLuongMua FLOAT,
    fDonGia FLOAT,
    fMucGiamGia FLOAT
);
GO

CREATE PROCEDURE [dbo].[sp_InsertHoaDon]
    @sMaNV VARCHAR(20),
    @sTenKH VARCHAR(20),
    @sSDT VARCHAR(20),
    @dNgayLap DATE,
    @CHITIET_HD_BANHANG_Details AS dbo.CHITIET_HD_BANHANG_Details READONLY
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sSoHD INT;
    DECLARE @fTongTien FLOAT;
    -- Thêm mới hóa đơn
    INSERT INTO tblHoaDon (sMaNV, sTenKH, sSDT, dNgayLap)
    VALUES (@sMaNV, @sTenKH, @sSDT, @dNgayLap);

    -- Lấy số hóa đơn vừa thêm mới
    SET @sSoHD = SCOPE_IDENTITY();
    -- Thêm chi tiết hóa đơn
    INSERT INTO tblCHITIET_HD_BANHANG (sSoHD, sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia)
    SELECT @sSoHD, sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia
    FROM @CHITIET_HD_BANHANG_Details;
    -- Tính tổng tiền
    SELECT @fTongTien = SUM(fSoLuongMua * fDonGia * (1 - fMucGiamGia))
    FROM @CHITIET_HD_BANHANG_Details;

    -- Cập nhật tổng tiền cho hóa đơn
    UPDATE tblHoaDon
    SET fTongTien = @fTongTien
    WHERE sSoHD = @sSoHD;
END;

go
DECLARE @details AS dbo.CHITIET_HD_BANHANG_Details;
INSERT INTO @details (sMaSanPham, fSoLuongMua, fDonGia, fMucGiamGia)
VALUES
    ('SP001', 2, 10.5, 0.1),
    ('SP002', 3, 8.75, 0.05)
EXEC sp_InsertHoaDon 
    @sMaNV = 'NV001',
    @sTenKH = 'Khách hàng A',
    @sSDT = '0123456789',
    @dNgayLap = '2024-04-09',
    @CHITIET_HD_BANHANG_Details = @details;
go
select * from tblHoaDon
select * from tblCHITIET_HD_BANHANG
--============== Phiếu nhập
go
CREATE TYPE dbo.CHITIET_HD_NHAPHANG_Details AS TABLE
(
    sMaSanPham VARCHAR(50),
    fSoLuongNhap FLOAT,
    fGiaNhap FLOAT
);
go
CREATE PROCEDURE [dbo].[sp_InsertDonNhap]
    @sMaNV VARCHAR(20),
    @dNgayNhap DATE,
    @ChitietHoadonDetails AS dbo.CHITIET_HD_NHAPHANG_Details READONLY
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Thêm đơn nhập hàng vào bảng tblDonNhap
    DECLARE @sSoHDNhap INT;
    INSERT INTO tblDonNhap (sMaNV, dNgayNhap)
    VALUES (@sMaNV, @dNgayNhap);
    SET @sSoHDNhap = SCOPE_IDENTITY();
    
    -- Tính tổng tiền từ các chi tiết hóa đơn và cập nhật vào bảng tblDonNhap
    DECLARE @fTongtien FLOAT;
    SELECT @fTongtien = SUM(fSoLuongNhap * fGiaNhap)
    FROM @ChitietHoadonDetails;
    
    UPDATE tblDonNhap
    SET fTongTien = @fTongtien
    WHERE sSoHDNhap = @sSoHDNhap;

    -- Thêm chi tiết đơn nhập hàng vào bảng tblCHITIET_HD_NHAPHANG
    INSERT INTO tblCHITIET_HD_NHAPHANG (sSoHDNhap, sMaSanPham, fSoLuongNhap, fGiaNhap)
    SELECT @sSoHDNhap, sMaSanPham, fSoLuongNhap, fGiaNhap
    FROM @ChitietHoadonDetails;
END;
DECLARE @CHITIET_HD_NHAPHANG_Details AS dbo.CHITIET_HD_NHAPHANG_Details;

INSERT INTO @CHITIET_HD_NHAPHANG_Details (sMaSanPham, fSoLuongNhap, fGiaNhap)
VALUES
('SP001', 10, 12.0),
('SP002', 20, 3.0);

EXEC sp_InsertDonNhap 'NV001', '2024-04-15', @CHITIET_HD_NHAPHANG_Details;

select * from tblDonNhap
select * from tblCHITIET_HD_NHAPHANG
--- Crystal - procedure
go
CREATE PROCEDURE sp_GetChiTietHoaDonWithInfo
    @SoHD INT
AS
BEGIN
    SELECT hd.sSoHD,
           hd.sMaNV,
           nv.sTenNV AS TenNhanVien,
           hd.sTenKH,
           hd.sSDT,
           hd.dNgayLap,
           chitiet.sMaSanPham,
           sp.sTenSanPham,
           chitiet.fSoLuongMua,
           chitiet.fDonGia,
           chitiet.fMucGiamGia
    FROM tblHoaDon hd
    INNER JOIN tblNhanVien nv ON hd.sMaNV = nv.sMaNV
    LEFT JOIN tblCHITIET_HD_BANHANG chitiet ON hd.sSoHD = chitiet.sSoHD
    LEFT JOIN tblSanPham sp ON chitiet.sMaSanPham = sp.sMaSanPham
    WHERE hd.sSoHD = @SoHD;
END;
EXEC sp_GetChiTietHoaDonWithInfo @SoHD = 1;
go
CREATE PROCEDURE GetInvoicesByDate
AS
BEGIN
    SELECT 
        hd.sSoHD AS 'SoHD',
        hd.sMaNV AS 'MaNV',
        nv.sTenNV AS 'TenNhanVien',
        hd.sTenKH AS 'TenKH',
        hd.sSDT AS 'SDT',
        hd.dNgayLap AS 'NgayLap',
        ctp.sMaSanPham AS 'MaSanPham',
        sp.sTenSanPham AS 'TenSanPham',
        ctp.fSoLuongMua AS 'SoLuongMua',
        ctp.fDonGia AS 'DonGia',
        ctp.fMucGiamGia AS 'MucGiamGia'
    FROM 
        tblHoaDon hd
    INNER JOIN 
        tblNhanVien nv ON hd.sMaNV = nv.sMaNV
    INNER JOIN 
        tblCHITIET_HD_BANHANG ctp ON hd.sSoHD = ctp.sSoHD
    INNER JOIN 
        tblSanPham sp ON ctp.sMaSanPham = sp.sMaSanPham
    ORDER BY 
        hd.dNgayLap, hd.sSoHD, ctp.sMaSanPham;
END;
go
CREATE PROCEDURE [dbo].[sp_TimKiemDonNhap]
    @sMaNV VARCHAR(20),
    @dNgayNhap DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT PN.sSoHDNhap, NV.sTenNV, PN.dNgayNhap, PN.fTongtien
    FROM tblDonNhap PN
    INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
    WHERE PN.sMaNV = @sMaNV OR PN.dNgayNhap = @dNgayNhap;
END;
go
CREATE PROCEDURE sp_GetReceiptDetails @SoHDNhap INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Thông tin đơn nhập và chi tiết hóa đơn nhập hàng
    SELECT 
        dn.sSoHDNhap,
        dn.dNgayNhap,
        nv.sTenNV,
        dn.fTongTien,
        sp.sTenSanPham,
        sp.fDonGia,
        ncc.sTenNCC,
        sp.fSoLuongKho,
        ctn.fSoLuongNhap,
        ctn.fGiaNhap
    FROM 
        tblDonNhap dn
    INNER JOIN 
        tblNhanVien nv ON dn.sMaNV = nv.sMaNV
    INNER JOIN 
        tblCHITIET_HD_NHAPHANG ctn ON dn.sSoHDNhap = ctn.sSoHDNhap
    INNER JOIN 
        tblSanPham sp ON ctn.sMaSanPham = sp.sMaSanPham
	INNER JOIN 
        tblNhaCungCap ncc ON sp.sMaNCC = ncc.sMaNCC
    WHERE 
        dn.sSoHDNhap =@SoHDNhap;
END;

--- Nhân viên
go
CREATE PROCEDURE sp_ThemNhanVien
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @NgaySinh DATE,
    @NgayVaoLam DATE,
    @CCCD VARCHAR(50),
    @LuongCoBan FLOAT,
    @PhuCap FLOAT
AS
BEGIN
    INSERT INTO tblNhanVien (sMaNV, sTenNV, sDiaChi, dNgaySinh, dNgayVaoLam, sCCCD, fLuongCoBan, fPhuCap)
    VALUES (@MaNV, @TenNV, @DiaChi, @NgaySinh, @NgayVaoLam, @CCCD, @LuongCoBan, @PhuCap)
END
-- Cập nhật
go
CREATE PROCEDURE sp_CapNhatNhanVien
    @MaNV VARCHAR(20),
    @TenNV NVARCHAR(50),
    @DiaChi NVARCHAR(50),
    @NgaySinh DATE,
    @NgayVaoLam DATE,
    @CCCD VARCHAR(50),
    @LuongCoBan FLOAT,
    @PhuCap FLOAT
AS
BEGIN
    UPDATE tblNhanVien
    SET 
        sTenNV = @TenNV,
        sDiaChi = @DiaChi,
        dNgaySinh = @NgaySinh,
        dNgayVaoLam = @NgayVaoLam,
        sCCCD = @CCCD,
        fLuongCoBan = @LuongCoBan,
        fPhuCap = @PhuCap
    WHERE
        sMaNV = @MaNV;
END

select * from tblNhanVien
-- Xóa
go
CREATE PROCEDURE sp_XoaNhanVien
    @MaNV VARCHAR(20)
AS
BEGIN
    DELETE FROM tblNhanVien
    WHERE sMaNV = @MaNV;
END
-- danh sách
go 
CREATE PROCEDURE [dbo].[usp_GetEmployeeList]
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT sMaNV, sTenNV, sDiaChi, dNgaySinh, dNgayVaoLam, sCCCD, fLuongCoBan, fPhuCap
    FROM tblNhanVien;
END
-- Tài khoản
go
CREATE PROCEDURE [dbo].[GetAccountList]
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy danh sách tài khoản và thông tin tương ứng của nhân viên
    SELECT 
        TK.MaTaiKhoan,
        TK.TenDangNhap,
        NV.sTenNV AS TenNhanVien,  -- Lấy tên của nhân viên từ bảng tblNhanVien
        TK.MatKhau,
        Q.TenQuyen AS TenQuyen  -- Lấy tên quyền từ bảng tblQuyen
    FROM 
        tblTaiKhoan TK
    INNER JOIN 
        tblNhanVien NV ON TK.MaNV = NV.sMaNV
    INNER JOIN 
        tblQuyen Q ON TK.MaQuyen = Q.MaQuyen;
END


go
--================ TestSelect =------=====
SELECT PN.sSoHD,  NV.sTenNV,PN.sTenKH, PN.sSDT, PN.dNgaylap, PN.fTongtien 
FROM tblHoadon PN 
INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
SELECT PN.sSoHDNhap,  NV.sTenNV, PN.dNgayNhap, PN.fTongtien
FROM tblDonNhap PN 
INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
SELECT PN.sSoHDNhap,  NV.sTenNV, PN.dNgayNhap, PN.fTongtien
FROM tblDonNhap PN 
INNER JOIN tblNhanvien NV ON PN.sMaNV = NV.sMaNV
WHERE PN.sMaNV  = 'NV002' or PN.dNgayNhap='2023-12-02'