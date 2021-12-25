using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface ICTNhaphangBLL
    {
        void ThemCTNH(List<CTNhaphang> ds);
        List<CTNhaphang> TimCTNH(string mhd);
        void XoaCTNH(string mahdn);
        
    }
}
