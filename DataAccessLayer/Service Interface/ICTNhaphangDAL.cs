using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
namespace Project.DataAccessLayer
{
    interface ICTNhaphangDAL
    {
        void Insert(CTNhaphang ctnh);
        void Update(List<CTNhaphang> ds);
        List<CTNhaphang> GetAllData();
    }
}
