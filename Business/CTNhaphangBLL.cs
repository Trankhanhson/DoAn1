using System;
using System.Collections.Generic;
using System.Text;
using Project.DataAccessLayer;
using Project.Entities;
namespace Project.Business
{
    class CTNhaphangBLL : ICTNhaphangBLL
    {
        ICTNhaphangDAL cthdn = new CTNhaphangDAL();
        IVatlieuDAL vatlieuDAL = new VatlieuDAL();
        public void ThemCTNH(List<CTNhaphang> ds)
        {
            foreach (CTNhaphang ct in ds)
            {
                cthdn.Insert(ct);              
            }
        }

        public List<CTNhaphang> TimCTNH(string mahdn)
        {
            List<CTNhaphang> ds = cthdn.GetAllData();
            List<CTNhaphang> result = new List<CTNhaphang>();
            bool check = false;
            foreach (CTNhaphang a in ds)
            {
                if (a.Mahdn == mahdn)
                {
                    result.Add(a);
                    check = true;
                }
                else if (check == true)
                {
                    break;
                }
            }
            return result;
        }
        public void XoaCTNH(string mahdn)
        {
            List<CTNhaphang> ds = cthdn.GetAllData();//vị trí đầu tệp là vị trí đầu danh sách
            List<Vatlieu> dsvl=vatlieuDAL.GetAllData();
            bool check = false;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].Mahdn == mahdn)
                {
                    foreach (Vatlieu v in dsvl)//vì lý do nào đó mà khi nhập hóa đơn rồi nhưng không nhập được hàng vào kho
                    {
                        if (v.Ma == ds[i].Mavl)
                        {
                            v.Soluong -= ds[i].Soluong;
                            break;
                        }
                    }
                    ds[i] = null;//nếu dùng remove thì vòng for sẽ bị đảo lộn vị trí khi remove nhiều phần tử
                    check = true;
                }
                else if (check == true)//nó sẽ không duyệt hết vòng for
                {
                    break;
                }
            }
            cthdn.Update(ds);
            vatlieuDAL.Update(dsvl);
        }
    }
}
