CREATE DATABASE QuanLiThongTin;

CREATE TABLE DangNhap (
	TaiKhoan nchar(20) primary key,
	MatKhau nchar(20)
);
CREATE TABLE SinhVien(
	MaSV nchar(10)primary key,
	TenSV nvarchar(30),
	GioiTinh nvarchar(20),
	NamSinh nchar(10),
	Lop nchar(5),
	MaLop nchar(10),
	MaKhoa nchar(10),
);
CREATE TABLE Lop(
	MaLop nchar(10) primary key,
	TenLop nvarchar(20),
	TenKhoa nvarchar(20),
);
CREATE TABLE Khoa(
	MaKhoa nchar(10) primary key,
	TenKhoa nvarchar(20),
);

alter table SinhVien add constraint fok_malop foreign key (MaLop) references Lop(MaLop)
alter table SinhVien add constraint fok_maKhoa foreign key (MaKhoa) references Khoa(MaKhoa)

DROP TABLE SinhVien;
DROP TABLE Lop;
DROP TABLE Khoa;