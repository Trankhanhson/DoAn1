using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface IHDNhapBLL
    {
        void ThemHDN(HDNhap hdn);
        List<HDNhap> TimHDN(HDNhap hdn);
        List<HDNhap> GetListHDN();
        int TongTienHDN(List<CTNhaphang> ds);
        void XoaHDN(string mahdn);
        void SuaHDN(HDNhap hdn);
        HDNhap GetHDN(string mahdn);
    }
}
