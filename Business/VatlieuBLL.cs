using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
namespace Project.Business
{
    class VatlieuBLL : IVatlieuBLL
    {
        private IVatlieuDAL vl = new VatlieuDAL();
        public void ThemVL(Vatlieu v)
        {
            vl.Insert(v);
        }

        public void SuaVL(Vatlieu v)
        {
            List<Vatlieu> ds = vl.GetAllData();

            for(int i=0; i<ds.Count; i++)
            {
                if (v.Ma == ds[i].Ma)
                {
                    ds[i] = v;
                    vl.Update(ds);
                    break;
                }
            }

        }

        public void XoaVL(string ma)
        {
            List<Vatlieu> ds = vl.GetAllData();
            bool check = false;
            foreach (Vatlieu v in ds)
            {
                if (v.Ma == ma)
                {
                    ds.Remove(v);
                    check = true;
                    break;
                }
            }
            if (check)
            {
                vl.Update(ds);
            }
            else
            {
                throw new Exception("Mã này không tồn tại!");
            }
        }

        public Vatlieu GetVL(string ma)
        {
            List<Vatlieu> ds = vl.GetAllData();
            foreach (Vatlieu v in ds)
            {
                if (v.Ma == ma)
                {
                    return v;
                }
            }
            throw new Exception("Mã này không tồn tại!");
        }

        public List<Vatlieu> TimVL(Vatlieu v)
        {
            List<Vatlieu> ds = vl.GetAllData();
            List<Vatlieu> result = new List<Vatlieu>();
            if (v.Ma != null && v.Ten == null)
            {
                foreach (Vatlieu a in ds)
                {
                    if (a.Ma == v.Ma)
                    {
                        result.Add(a);
                        break;
                    }
                }

            }
            else if (v.Ma == null && v.Ten != null)
            {
                foreach (Vatlieu a in ds)
                {
                    if (a.Ten.ToLower().Contains(v.Ten.ToLower()))
                    {
                        result.Add(a);
                    }
                }

            }
            
            return result;
        }

        public List<Vatlieu> GetListVL()
        {
            return vl.GetAllData();
        }

        public List<Vatlieu> VatlieuCannhap()
        {
            List<Vatlieu> vatlieus=vl.GetAllData();
            List<Vatlieu> result=new List<Vatlieu>();
            foreach (Vatlieu v in vatlieus)
            {
                if (v.Soluong <= v.Mucnhaphang)
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public List<Vatlieu> TimGia(string loai,int giadau,int giacuoi)
        {
            List<Vatlieu> vatlieus = vl.GetAllData();
            List<Vatlieu> result = new List<Vatlieu>();
            foreach(Vatlieu v in vatlieus)
            {
                if(v.Giaban>=giadau && v.Giaban<=giacuoi && (v.Ten).ToLower().Contains(loai.ToLower()))
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public void SuaListVL(List<Vatlieu> newlist)//sử fungj ở hóa đơn nhập
        {
            List<Vatlieu> vatlieus = vl.GetAllData();
            foreach(Vatlieu newvl in newlist)
            {
                for (int i=0;i<vatlieus.Count;i++)
                {
                    if (vatlieus[i].Ma == newvl.Ma)
                    {
                        vatlieus[i].Soluong+=newvl.Soluong;
                        vatlieus[i].Gianhap=newvl.Gianhap;
                        vatlieus[i].Giaban=newvl.Giaban;
                    }
                }
            }
            
            vl.Update(vatlieus);
        }
    }
}
