using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface INhanvienBLL
    {
        void ThemNV(Nhanvien v);
        void SuaNV(Nhanvien v);
        void XoaNV(string ma);
        List<Nhanvien> TimNV(Nhanvien v);
        List<Nhanvien> GetListNV();
        Nhanvien GetNV(string ma);
    }
}
