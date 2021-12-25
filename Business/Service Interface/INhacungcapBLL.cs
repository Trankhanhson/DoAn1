using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface INhacungcapBLL
    {
        void ThemNCC(Nhacungcap n);
        void SuaNCC(Nhacungcap n);
        void XoaNCC(string ma);
        List<Nhacungcap> TimNCC(Nhacungcap n);
        Nhacungcap GetNCC(string ma);
        List<Nhacungcap> GetListNCC();
    }
}
