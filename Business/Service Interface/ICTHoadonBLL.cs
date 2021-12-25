using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface ICTHoadonBLL
    {
        void ThemCTHD(List<CTHoadon> ds);
        List<CTHoadon> TimCTHD(string mhd);//lấy ra chi tiết hóa đơn của một hóa đơn
        void XoaCTHD(string mahd);        
        int TongCtHoadon(string mavl, int soluong);
        int TinhtienLaiBill(List<CTHoadon> ds);
    }
}
