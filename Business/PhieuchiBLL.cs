using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
namespace Project.Business
{
    class PhieuchiBLL : IPhieuchiBLL
    {
        private IPhieuchiDAL phieuchi = new PhieuchiDAL();
        public void ThemPC(Phieuchi pc)
        {
            phieuchi.Insert(pc);
        }
        public void SuaPC(Phieuchi pc)
        {
            List<Phieuchi> ds = phieuchi.GetAllData();
            for(int i=0; i<ds.Count; i++)
            {
                if (pc.Maphieu == ds[i].Maphieu)
                {
                    ds[i] = pc;
                    phieuchi.Update(ds);
                    break;
                }
            }

        }
        public Phieuchi GetPC(string ma)
        {
            List<Phieuchi> ds = phieuchi.GetAllData();
            foreach (Phieuchi a in ds)
            {
                if (a.Maphieu == ma)
                {
                    return a;
                }
            }
            throw new Exception("Phiếu nàu không tồn tại");
        }
        public void XoaPC(string mapc)
        {
            List<Phieuchi> ds = phieuchi.GetAllData();
            bool check = true;
            foreach (Phieuchi a in ds)
            {
                if (a.Maphieu == mapc)
                {
                    ds.Remove(a);
                    phieuchi.Update(ds);
                    check = false;
                    break;
                }
            }
            if (check)
            {
                throw new Exception("Phiếu chi này không tồn tại");
            }
        }
        public List<Phieuchi> GetListPC()
        {
            return phieuchi.GetAllData();
        }

        public List<Phieuchi> TimPC(Phieuchi pc)
        {
            List<Phieuchi> ds = phieuchi.GetAllData();
            List<Phieuchi> result = new List<Phieuchi>();
            DateTime defaultTime = new DateTime(1, 1, 0001);//nếu không nhập thì Datetime có giá trị mặc định là 1/1/0001
            if (pc.Thoigian != defaultTime)
            {
                foreach (Phieuchi a in ds)
                {
                    if (a.Thoigian.Month == pc.Thoigian.Month && a.Thoigian.Year==pc.Thoigian.Year)
                    {
                        result.Add(a);
                    }
                }
            }
            else if (pc.Maphieu != null)
            {
                foreach (Phieuchi a in ds)
                {
                    if (a.Maphieu == pc.Maphieu)
                    {
                        result.Add(a);
                        break;
                    }
                }
            }
            else if (pc.Ghichu != null)
            {
                foreach (Phieuchi a in ds)
                {
                    if (a.Ghichu.Contains(pc.Ghichu))
                    {
                        result.Add(a);
                    }
                }
            }
            return result;
        }
    }
}
