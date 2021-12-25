using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface ICTHoadonDAL
    {
        List<CTHoadon> GetAllData();
        void Insert(CTHoadon c);
        void Update(List<CTHoadon> ds);
    }
}
