using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using Project.DataAccessLayer;
namespace Project.Business
{
    class CTHoadonBLL : ICTHoadonBLL
    {
        private ICTHoadonDAL cthd = new CTHoadonDAL();
        private IVatlieuDAL vatlieuDAL = new VatlieuDAL();
        public void ThemCTHD(List<CTHoadon> ds)
        {            
            foreach(CTHoadon d in ds)
            {
                cthd.Insert(d);
            }

            //Sửa thông tin trong bảng vật liệu khi bán hàng
            List<Vatlieu> vatlieus = vatlieuDAL.GetAllData();
            foreach(CTHoadon ct in ds)
            {
                foreach (Vatlieu v in vatlieus)
                {
                    if (v.Ma == ct.Mavl)
                    {
                        v.Soluong -= ct.Soluong;       
                    }
                }
            }         
            
            vatlieuDAL.Update(vatlieus);
        }

        public int TongCtHoadon(string mavl,int soluong)
        {
            int tongtien = 0;
            foreach(Vatlieu v in vatlieuDAL.GetAllData())
            {
                if (v.Ma == mavl)
                {
                    tongtien = v.Giaban * soluong;
                    break;
                }
            }
            return tongtien;
        }

        public void XoaCTHD(string mahd)
        {
            List<CTHoadon> ds = cthd.GetAllData();//vị trí đầu tệp là vị trí đầu danh sách
            List<Vatlieu> dsvl = vatlieuDAL.GetAllData();
            bool check = false;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].Mahd == mahd)
                {
                    //Cộng lại số lượng vật liệu vào kho nếu xóa
                    foreach(Vatlieu v in dsvl)
                    {
                        if (v.Ma == ds[i].Mavl)
                        {
                            v.Soluong += ds[i].Soluong;
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
            cthd.Update(ds); //không cần kiểm tra tồn tại vì có trong bảng hóa đơn thì sẽ có trong chi tiết hóa đơn
            vatlieuDAL.Update(dsvl);
            
        }
        
        public List<CTHoadon> TimCTHD(string mahd)
        {
            List<CTHoadon> ds = cthd.GetAllData();
            List<CTHoadon> result = new List<CTHoadon>();
            bool check = false;
            for(int i=ds.Count-1; i>=0; i--)
            {
                if (ds[i].Mahd == mahd)
                {
                    result.Add(ds[i]);
                    check = true;
                }
                else if (check == true)
                {
                    break;
                }
            }
            return result;
        }
       
        public int TienlaiCTHD(string mavl, int soluong)
        {
            int tienlai = 0;
            foreach (Vatlieu v in vatlieuDAL.GetAllData())
            {
                if (v.Ma == mavl)
                {
                    tienlai = (v.Giaban-v.Gianhap) * soluong;
                    break;
                }
            }
            return tienlai;
        }

    }
}
