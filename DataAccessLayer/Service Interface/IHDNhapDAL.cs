using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface IHDNhapDAL
    {
        void Insert(HDNhap hdn);
        void Update(List<HDNhap> ds);
        List<HDNhap> GetAllData();
    }
}
