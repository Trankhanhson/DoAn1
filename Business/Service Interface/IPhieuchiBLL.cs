using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.Business
{
    interface IPhieuchiBLL
    {
        void ThemPC(Phieuchi pc);
        void SuaPC(Phieuchi pc);
        void XoaPC(string mapc);
        List<Phieuchi> TimPC(Phieuchi pc);
        List<Phieuchi> GetListPC();
    }
}
