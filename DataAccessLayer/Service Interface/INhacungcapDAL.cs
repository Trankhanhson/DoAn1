using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface INhacungcapDAL
    {
        List<Nhacungcap> GetAllData();
        void Insert(Nhacungcap n);
        void Update(List<Nhacungcap> ds);
    }
}
