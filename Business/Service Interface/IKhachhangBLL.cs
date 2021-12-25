using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
using Project.Utility;
namespace Project.Business
{
    interface IKhachhangBLL
    {
        void ThemKH(Khachhang k);
        void SuaKH(Khachhang k);
        void ThemCongno(string ma, int no);
        void TruCongno(string ma, int thanhtoanthem);
        void XoaKH(string ma);
        List<Khachhang> TimKH(Khachhang k);
        List<Khachhang> GetListKH();
        Khachhang GetKH(string ma);
        List<Hoadon> Thanhtoan(string makh, int thanhtoanthem);
        List<Khachhang> GetKHNo();
        Khachhang GetKHSdt(string sdt);
        
    }
}
