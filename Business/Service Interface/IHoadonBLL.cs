using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface IHoadonBLL
    {
        void ThemHD(Hoadon h);
        List<Hoadon> TimHD(Hoadon h);
        List<Hoadon> GetListHD();
        Hoadon GetHD(string ma);
        void XoaHD(string mahd);
        int TongTienBill(List<CTHoadon> ds);//Tính tổng tiền của hóa đơn
        List<Hoadon> GetHDChuaThanhToan(string makh);
        void SuaHD(Hoadon hd);
        int TienlaiBill(List<CTHoadon> ds);//Tính tiền lãi cho bill
    }
}
