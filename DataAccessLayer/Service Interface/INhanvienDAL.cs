using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface INhanVienDAL
    {
        List<Nhanvien> GetAllData();
        void Insert(Nhanvien n);
        void Update(List<Nhanvien> ds);
    }
}
