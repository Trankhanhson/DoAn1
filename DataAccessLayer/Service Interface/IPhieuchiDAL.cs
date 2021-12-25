using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface IPhieuchiDAL
    {
        List<Phieuchi> GetAllData();
        void Insert(Phieuchi c);
        void Update(List<Phieuchi> ds);
    }
}
