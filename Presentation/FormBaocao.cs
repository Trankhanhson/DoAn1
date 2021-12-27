using System;
using System.Collections.Generic;
using System.Text;
using Project.Business;
using Project.Entities;
using Project.Utility;
namespace Project.Presentation
{
    class FormBaocao
    {
        private BaocaoBLL baocao = new BaocaoBLL();

        public void HienBaocao(Baocao bc)
        {
            Console.WriteLine($"  {"Doanh thu",-20}{"Thực thu",-20}{"Lợi nhuận gộp",-20}{"Lợi nhuận ròng",-20}{"Tổng chi"}");
            Console.WriteLine($"  {String.Format("{0:0,0}",bc.Tongthu),-20}{String.Format("{0:0,0}", bc.Thucthu),-20}{String.Format("{0:0,0}", bc.Laigop),-20}{String.Format("{0:0,0}", bc.Lairong),-20}{String.Format("{0:0,0}", bc.Tongchi)}");
        }

        public void Baocaongay()
        {
            Console.WriteLine("Thời gian:   /   /");
            Console.WriteLine();
            DateTime time;
            int ngay, thang, nam;
            while (true)
            {

                try
                {
                    Console.SetCursorPosition(11, 0); ngay = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(14, 0); thang = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(18, 0); nam = int.Parse(Console.ReadLine());
                    time = new DateTime(nam, thang, ngay);
                    break;
                }
                catch (FormatException)
                {

                    Console.WriteLine("BẠN NHẬP SAI ĐINH DẠNG!");

                }
                catch (Exception)
                {
                    Console.WriteLine("THỜI GIAN NÀY KHÔNG TỒN TẠI");
                }
            }

            Console.WriteLine();
            Baocao bc = baocao.Baocaongay(time);
            HienBaocao(bc);
            Console.WriteLine("\n");

            //hiển thị thêm các hóa đơn của ngày đó
            List<Hoadon> dshoadon = baocao.TimeHoadon(time);
            Console.WriteLine($"  {"Mã hóa đơn",-15}{"Mã nhân viên",-15}{"Tên khách",-20}{"Tổng tiền",-20}{"Khách thanh toán"}");
            foreach(Hoadon hoadon in dshoadon)
            {
                Console.WriteLine($"  {hoadon.Mahd,-15}{hoadon.Manv,-15}{hoadon.Tenkh,-20}{String.Format("{0:0,0}", hoadon.Tongtien),-20}{String.Format("{0:0,0}",hoadon.Dathanhtoan)}");
            }

            Tool.StopScreen();
        }

        public void Baocaothang()
        {
            Console.WriteLine("Thời gian:   /");
            Console.WriteLine();
            DateTime time;
            int thang, nam;
            while (true)
            {

                try
                {
                    Console.SetCursorPosition(11, 0); thang = int.Parse(Console.ReadLine());

                    Console.SetCursorPosition(14, 0); nam = int.Parse(Console.ReadLine());
                    time = new DateTime(nam, thang, 1);
                    break;
                }
                catch (FormatException)
                {

                    Console.WriteLine("BẠN NHẬP SAI ĐINH DẠNG!");

                }
                catch (Exception)
                {
                    Console.WriteLine("THỜI GIAN NÀY KHÔNG TỒN TẠI");
                }
            }

            Baocao bc = baocao.Baocaothang(time);
            HienBaocao(bc);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("  Chi tiết báo cáo tháng");
            Console.WriteLine();
            int songay = Tool.NgayTrongThang(time.Year, time.Month);
            
            Console.WriteLine($"  {"Ngày",-8}{"Doanh thu",-20}{"Thực thu",-20}{"Lợi nhuận gộp",-20}{"Lợi nhuận ròng",-20}{"Tổng chi"}");

            for (int i = 1; i <= songay; i++)
            {
                Baocao bcNgay=baocao.Baocaongay(new DateTime(time.Year, time.Month, i));
                if (bcNgay.Tongthu != 0 || bcNgay.Tongchi != 0)
                {
                    Console.WriteLine($"  {i,-8}{String.Format("{0:0,0}",bcNgay.Tongthu),-20}{String.Format("{0:0,0}", bcNgay.Thucthu),-20}{String.Format("{0:0,0}", bcNgay.Laigop),-20}{String.Format("{0:0,0}", bcNgay.Lairong),-20}{String.Format("{0:0,0}", bcNgay.Tongchi)}");
                }
            }
            Tool.StopScreen();
        }
        public void Baocaonam()
        {

            int nam;
            DateTime now = DateTime.Now;
            while (true)
            {

                try
                {
                    Console.Write("Mời nhập năm: ");
                    nam = int.Parse(Console.ReadLine());
                    if (nam > 2002 && nam <= now.Year)
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Không tồn tại năm này trong báo cáo");
                }
                catch (FormatException)
                {

                    Console.WriteLine("BẠN NHẬP SAI ĐINH DẠNG!");

                }

            }
            DateTime time;
            Console.WriteLine();
            Baocao tongcanam = baocao.Baocaonam(nam);
            HienBaocao(tongcanam);
            Console.WriteLine();
            Console.WriteLine("Chi tiết các tháng\n");
            Console.WriteLine($"  {"Tháng",-10}{"Doanh thu",-15}{"Thực thu",-15}{"Lợi nhuận gộp",-20}{"Lợi nhuận ròng",-20}{"Tổng chi",-15}");
            Baocao bc;
            for(int i=1;i<=12;i++)
            {
                time=new DateTime(nam,i,1);//duyệt từng tháng một
                bc=baocao.Baocaothang(time);
                if (bc.Tongthu != 0 || bc.Tongchi != 0)
                {
                    Console.WriteLine($"  {i,-10}{String.Format("{0:0,0}", bc.Tongthu),-15}{String.Format("{0:0,0}", bc.Thucthu),-15}{String.Format("{0:0,0}", bc.Laigop),-20}{String.Format("{0:0,0}", bc.Lairong),-20}{String.Format("{0:0,0}", bc.Tongchi),-20}");
                }
            }
            Console.WriteLine();
            Tool.StopScreen();
        }
        public void ThongkeVL()
        {
            int thang, nam;
            DateTime tmp;
            DateTime now=DateTime.Now;
            Console.WriteLine("\n    Mời nhập thời gian:   /  ");
            while (true)
            {
                try {
                    
                    Console.SetCursorPosition(24, 1);
                    thang = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(27, 1);
                    nam = int.Parse(Console.ReadLine());
                    tmp=new DateTime(nam,thang,1);//để kiếm tra xem thời gian có tồn tại không
                    if (tmp <= now)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(3, 4, "Thời gian phải nhỏ hơn hiện tại     ");
                    }
                }
                catch(FormatException)
                {
                    Tool.WriteXY(3,4,"Bạn nhập sai định dạng         ");
                }
                catch (Exception)
                {
                    Tool.WriteXY(3, 4, "Thời gian này không tồn tại       ");
                }
                
            }
            Tool.WriteXY(3, 4, "                                   ");
            Console.WriteLine("\n");

            Console.WriteLine($"    {"Mã vật liệu",-20}{"Tên vật liệu",-20}{"Số lượng bán",-15}{"Đơn vị",-15}{"Doanh thu",-15}{"Lợi nhuận"}");
            foreach (Vatlieu vl in baocao.ThongkeVL(thang, nam))
            {
                Console.WriteLine($"    {vl.Ma,-20}{vl.Ten,-20}{vl.Soluong,-15}{vl.Donvitinh,-15}{String.Format("{0:0,0}",vl.Giaban),-15}{String.Format("{0:0,0}",vl.Gianhap)}");
            }
            Console.WriteLine();

            Tool.StopScreen();
        }
    }
}
