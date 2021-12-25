using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface IBaocaoBLL
    {
        Baocao Baocaothang(DateTime time);
        Baocao Baocaongay(DateTime time);
        Baocao Baocaonam(int nam);       
        List<Hoadon> TimeHoadon(DateTime time);
        List<Vatlieu> ThongkeVL(int thang, int nam);
    }
}
