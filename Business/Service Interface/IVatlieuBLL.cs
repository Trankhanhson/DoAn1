using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface IVatlieuBLL
    {
        void ThemVL(Vatlieu v);
        void XoaVL(string mavl);
        void SuaVL(Vatlieu mavl);
        List<Vatlieu> TimVL(Vatlieu vl);
        Vatlieu GetVL(string ma);
        List<Vatlieu> GetListVL();
        List<Vatlieu> TimGia(string loai, int giadau, int giacuoi);
        List<Vatlieu> VatlieuCannhap();
        void SuaListVL(List<Vatlieu> vl);
    }
}
