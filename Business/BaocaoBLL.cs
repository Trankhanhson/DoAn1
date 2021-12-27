using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.DataAccessLayer;
namespace Project.Business
{
    class BaocaoBLL : IBaocaoBLL
    {
        private IPhieuchiDAL phieuchi = new PhieuchiDAL();
        private IHoadonDAL hdban = new HoadonDAL();
        private ICTHoadonDAL cthd=new CTHoadonDAL();
        private IVatlieuDAL VatlieuDAL = new VatlieuDAL();

        public Baocao Baocaongay(DateTime time)
        {
            List<Phieuchi> ListPhieuchi = phieuchi.GetAllData();
            List<Hoadon> ListHDBan = hdban.GetAllData();

            int tongchi = 0;
            int tongthu = 0;
            int thucthu = 0;
            int laigop = 0;
            

            for (int i=0;i<ListHDBan.Count;i++)//khách hàng thường tìm những ngày gần
            {
                if (ListHDBan[i].Ngayxuat == time)
                {
                    tongthu += ListHDBan[i].Tongtien;
                    thucthu += ListHDBan[i].Dathanhtoan;
                    laigop += ListHDBan[i].Tienlai; //lãi gộp = Doanh thu - chi phí hầng hóa
                }                
            }

            foreach (Phieuchi pc in ListPhieuchi)
            {
                if (pc.Thoigian == time)
                {
                    tongchi += pc.Sotien;
                }
            }

            //Tính lãi ròng = Lãi gộp - chi phí cố định
            int lairong=laigop - tongchi;
                        

            Baocao bc = new Baocao(tongthu, tongchi, thucthu,lairong,laigop, time);
            return bc;
        }

        public Baocao Baocaothang(DateTime time)
        {
            List<Phieuchi> ListPhieuchi = phieuchi.GetAllData();
            List<Hoadon> ListHDBan = hdban.GetAllData();

            int tongchi = 0;
            int tongthu = 0;
            int thucthu = 0;
            int laigop = 0;

            foreach (Hoadon hd in ListHDBan)
            {
                if (hd.Ngayxuat.Month == time.Month && hd.Ngayxuat.Year == time.Year)
                {
                    tongthu += hd.Tongtien;
                    thucthu += hd.Dathanhtoan;
                    laigop += hd.Tienlai;
                }
            }

            foreach (Phieuchi pc in ListPhieuchi)
            {
                if (pc.Thoigian.Month == time.Month && pc.Thoigian.Year == time.Year)
                {
                    tongchi += pc.Sotien;
                }
            }

            //Tính lãi ròng
            int lairong = laigop - tongchi;
            
            
            Baocao bc = new Baocao(tongthu, tongchi, thucthu,lairong,laigop, time);
            return bc;
        }


        public List<Hoadon> TimeHoadon(DateTime time)
        {
            List<Hoadon> list = hdban.GetAllData();
            List<Hoadon> results=new List<Hoadon>();
            foreach(Hoadon hoadon in list)
            {
                if (hoadon.Ngayxuat == time)
                {
                    results.Add(hoadon);
                }
            }
            return results;
        }

        public Baocao Baocaonam(int nam)
        {
            DateTime time;
            int tongchi = 0;
            int tongthu = 0;
            int thucthu = 0;
            int laigop = 0;
            int lairong = 0;
            for (int i = 1; i < 13; i++)
            {
                time = new DateTime(nam, i, 1);
                Baocao b= Baocaothang(time);
                tongchi += b.Tongchi;
                tongthu += b.Tongthu;
                laigop += b.Laigop;
                lairong += b.Lairong;
                thucthu += b.Thucthu;
            }
            Baocao bcnam = new Baocao(tongthu,tongchi,thucthu,lairong,laigop,new DateTime(nam,1,1));

            return bcnam;
        }

        public List<Vatlieu> ThongkeVL(int thang, int nam)
        {
            List<Vatlieu> dsvatlieu=VatlieuDAL.GetAllData();
            List<Hoadon> dshd=hdban.GetAllData();
            List<CTHoadon> dscthd=cthd.GetAllData();
            List<CTHoadon> cthdOfMonth=new List<CTHoadon>();

            bool check;

            //lấy danh sách cthd của tháng đó
            foreach(Hoadon hoadon in dshd)
            {
                if(hoadon.Ngayxuat.Month==thang && hoadon.Ngayxuat.Year == nam)
                {
                    check = false;
                    for(int i=dscthd.Count-1; i>=0; i--)
                    {
                        if (dscthd[i].Mahd == hoadon.Mahd)
                        {
                            cthdOfMonth.Add(dscthd[i]);
                            check = true;
                        }
                        else if(check==true)//vì cthd có mã hóa đơn luôn đứng cạnh nhau
                        {
                            break;
                        }    
                    }
                }
            }

            //công dồn các vật liệu bán được vào
            foreach(Vatlieu vl in dsvatlieu)
            {
                vl.Soluong = 0;//lấy trường số lượng để chứa tổng số lượng bán được
                vl.Gianhap = 0;//lấy trường giá bán để chứa tiền lãi từ vật liệu đó
                vl.Giaban = 0;//lấy trường giá nhập để chứa doanh thu của vật liệu đó
                foreach (CTHoadon ct in cthdOfMonth)
                {                   
                    if (ct.Mavl == vl.Ma)
                    {                       
                        vl.Soluong+=ct.Soluong;
                        vl.Gianhap += ct.Tienlai;
                        vl.Giaban += ct.Tongtien;
                    }
                }
            }

            return dsvatlieu;
        }
    }
}
