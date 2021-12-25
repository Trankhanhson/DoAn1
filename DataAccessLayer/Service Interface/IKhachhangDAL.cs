using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface IKhachhangDAL
    {
        void Insert(Khachhang kh);
        void Update(List<Khachhang> ds);
        List<Khachhang> GetAllData();
    }
}
