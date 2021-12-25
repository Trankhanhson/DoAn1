using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface IVatlieuDAL
    {
        List<Vatlieu> GetAllData();
        void Insert(Vatlieu vl);
        void Update(List<Vatlieu> ds);
    }
}
