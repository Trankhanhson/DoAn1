using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface IHoadonDAL
    {
        List<Hoadon> GetAllData();
        void Insert(Hoadon c);
        void Update(List<Hoadon> ds);
    }
}
