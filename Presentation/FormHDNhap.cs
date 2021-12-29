using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;
using Project.Utility;
using Project.Business;
namespace Project.Presentation
{
    class FormHDNhap
    {
        private IHDNhapBLL hoadonnhap = new HDNhapBLL();
        private ICTNhaphangBLL ctnhaphang = new CTNhaphangBLL();
        private IVatlieuBLL vatlieu = new VatlieuBLL();    
        private LibraryCheck check = new LibraryCheck();
        public void Them()
        {
            HDNhap hdn = new HDNhap();
            while (true)
            {

                List<CTNhaphang> ListCTHoadonnhap = new List<CTNhaphang>();
                List<HDNhap> ds = hoadonnhap.GetListHDN();
                Console.WriteLine($"                                          ĐẠI LÝ VẬT LIỆU XÂY DỰNG DA1                                     ");
                Console.WriteLine($"    ------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"                                               HÓA ĐƠN NHẬP HÀNG                                          ");
                Console.WriteLine($"    ════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine($"    Nhà cung cấp:                                                               Ngày nhập:   /  /         ");
                Console.WriteLine();
                Console.WriteLine($"    Số loại vật liệu: ");
                Console.WriteLine($"    ════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($"    Mã vật liệu  ║  Tên vật liệu   ║  Số lượng    ║  Giá nhập    ║  Giá bán     ║ Thành tiền   ║  ");

                int x = 4;
                int y = 25;
                //gán mã hóa đơn tự động 
                int mahdn;
                if (ds.Count == 0)
                {
                    mahdn = 1;
                }
                else
                {
                    int i = ds.Count - 1;//vị trí cuối cùng của list
                    mahdn = int.Parse(ds[i].Mahdn.Substring(3)) + 1;
                }
                hdn.Mahdn = "HDN" +mahdn.ToString();

                //Hiện ngày hiện tại lên
                DateTime now=DateTime.Now;
                Tool.WriteXY(5, 91, now.Day.ToString());
                Tool.WriteXY(5, 94, now.Month.ToString());
                Tool.WriteXY(5, 97, now.Year.ToString());

                //nhập tên nhà cung cấp
                while (true)
                {
                    Console.SetCursorPosition(18, 5);
                    hdn.Tenncc = Tool.Catxau(Console.ReadLine());
                    if (hdn.Tenncc.Trim() != "")
                    {
                        if (check.CheckListNCC(hdn.Tenncc))
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(y,x, "NHÀ CUNG CẤP CHƯA TỒN TẠI    ");
                        }
                    }
                    else
                    {
                        Tool.WriteXY(y, x, "NHÀ CUNG CẤP KHÔNG ĐƯỢC KHÁC RỖNG    ");
                    }

                }
                Tool.WriteXY(y, x, "                                        ");

                //ngày nhập hàng
                DateTime ngaynhap;
                string ngay, thang, nam;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(5, 91, "  ");
                        if (ngay == "")
                        {
                            ngay = now.Day.ToString();
                        }
                        thang = Tool.ReadInfoXY(5, 94, "  ");
                        if (thang == "")
                        {
                            thang = now.Month.ToString();
                        }
                        nam = Tool.ReadInfoXY(5, 97, "    ");
                        if (nam == "")
                        {
                            nam = now.Year.ToString();
                        }

                        ngaynhap = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));
                        hdn.Ngaynhap = ngaynhap;
                        break;
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y, x, "Bạn nhập sai định dạng          ");

                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(y, x, "Thời gian này không tồn tại      ");
                    }
                }
                Tool.WriteXY(y, x, "                                        ");

                //nhập số loại vật liệu
                int sovl;
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(22, 7);
                        sovl = int.Parse(Console.ReadLine());
                        if (sovl <= 0 )
                        {
                            Tool.WriteXY(y, x, "Số vật liệu phải lớn hơn 0");
                        }
                        else if(sovl > vatlieu.GetListVL().Count)
                        {
                            Tool.WriteXY(y, x, "Số vật liệu trong kho là " + vatlieu.GetListVL().Count);
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y, x, "Bạn nhập sai định dạng      ");
                    }
                }
                Tool.WriteXY(y, x, "                                     ");

                //nhập danh dách chí tiết các vật liệu
                List<Vatlieu> vatlieus=new List<Vatlieu>();//danh sách để chứa thông tin giá và số lượng vật liệu vừa thay đổi

                int indexline = 10;
                for (int i = 0; i < sovl; i++)
                {
                    CTNhaphang ct = new CTNhaphang();
                    Console.SetCursorPosition(0, indexline);
                    Console.WriteLine($"                 ║                 ║              ║              ║              ║              ║                                ");

                    ct.Mahdn = hdn.Mahdn;//gán Mã của chi tiết hóa đơn = mã hóa đơn

                    //nhập mã vật liệu
                    Vatlieu vl;
                    while (true)
                    {
                        Console.SetCursorPosition(5, indexline);
                        ct.Mavl = Console.ReadLine();
                        try
                        {
                            vl = vatlieu.GetVL(ct.Mavl);
                            Tool.WriteXY(indexline, 20, vl.Ten);
                            Tool.WriteXY(indexline, 53, String.Format("{0:0,0}", vl.Gianhap));
                            Tool.WriteXY(indexline, 68, String.Format("{0:0,0}",vl.Giaban));
                            break;
                        }
                        catch(Exception ex)
                        {
                            Tool.WriteXY(y, x, ex.Message);
                        }
                    }
                    Tool.WriteXY(y, x, "                                ");

                    //nhập số lượng
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(38, indexline);
                            ct.Soluong = int.Parse(Console.ReadLine());
                            if (ct.Soluong > 0)
                            {
                                break;
                            }
                            else
                            {
                                Tool.WriteXY(y, x, "Số lượng phải lớn hơn 0");
                            }
                        }
                        catch (FormatException)
                        {
                            Tool.WriteXY(y, x, "Bạn nhập sai định dạng   ");
                        }
                    }
                    vl.Soluong=ct.Soluong;//VL.Soluong bây giò chỉ chứa số lượng nhập thêm vật liệu
                    Tool.WriteXY(y,x, "                                ");

                    string gianhap, giaban;
                    //Giá nhập
                    while (true)
                    {
                        gianhap = Tool.ReadInfoXY(indexline, 53, String.Format("{0:0,0}",vl.Gianhap));
                        if (gianhap != "")
                        {
                            if (Tool.DuyetChuoiSo(gianhap) == false)
                            {
                                Tool.WriteXY(y, x, "Bạn nhập sai định dạng       ");
                            }
                            else if (int.Parse(gianhap) <= 0)
                            {
                                Tool.WriteXY(y, x, "Gía nhập phải lớn hơn 0       ");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }

                    }                   
                    if (gianhap!="")
                    {
                        ct.Gianhap = int.Parse(gianhap);
                        vl.Gianhap=int.Parse(gianhap);//thay đổi giá nhập
                    }
                    else
                    {
                        ct.Gianhap=vl.Gianhap;
                    }
                    Tool.WriteXY(y,x, "                                ");

                    //Giá bán
                    while (true)
                    {
                        Console.SetCursorPosition(58, indexline);
                        giaban = Tool.ReadInfoXY(indexline, 68, String.Format("{0:0,0}", vl.Giaban));
                        if (giaban != "")
                        {
                            if (Tool.DuyetChuoiSo(giaban)==false)
                            {
                                Tool.WriteXY(y, x, "Bạn nhập sai định dạng       ");
                            }
                            else if (int.Parse(giaban) <= 0)
                            {
                                Tool.WriteXY(y, x, "Gía bán phải lớn hơn 0       ");
                            }
                            else
                            {
                                break;
                            }
                        }
                        else 
                        {
                            break;
                        }
                    }
                    if(giaban!="" && int.Parse(giaban) != vl.Giaban)
                    {
                        vl.Giaban = int.Parse(giaban);//thay đổi giá bán
                    }
                    Tool.WriteXY(y, x, "                                ");

                    vatlieus.Add(vl);//add vào list để thay đổi trong bảng vl

                    ct.Tongtien = ct.Gianhap * ct.Soluong;
                    ListCTHoadonnhap.Add(ct);

                    Tool.WriteXY(indexline, 82,String.Format("{0:0,0}",ct.Tongtien));
                    indexline++;
                }
                Console.SetCursorPosition(0, indexline);
                Console.WriteLine($"    ------------------------------------------------------------------------------------------------------------");
                //Tính tổng tiền của hóa đơn

                hdn.Tongtien = hoadonnhap.TongTienHDN(ListCTHoadonnhap);

                //in ra tổng tiền 
                Console.SetCursorPosition(82, indexline + 1);
                Console.Write($"Tổng tiên : {String.Format("{0:0,0}",hdn.Tongtien)}");

                //Thêm danh sách háo đơn nhập
                ctnhaphang.ThemCTNH(ListCTHoadonnhap);

                //Thêm hóa đơn nhập
                hoadonnhap.ThemHDN(hdn);

                //Thay đổi thông tin vật liệu
                vatlieu.SuaListVL(vatlieus);

                Tool.WriteXY(indexline + 4, 4, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void Sua()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("                                                  HÓA ĐƠN NHẬP HÀNG                                             ");
                Console.WriteLine("     ═══════════════════════════════════════════════════════════════════════════════════════════════════════  ");
                Console.WriteLine();
                Console.WriteLine("              Mã:                         Nhà cung cấp:                        Ngày nhập:   /  /        ");
                Console.WriteLine();
                Console.WriteLine("     -------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                        Mã vật liệu     ║   Giá nhập    ║    Số lượng     ║    Thành tiền                      ");


                HDNhap hdn=new HDNhap();
                string mahdn;

                int x = 4;//vị trí cột thông báo
                int y = 25; //vị trí dòng của thông báo
                while (true)
                {
                    Console.SetCursorPosition(18, 5);
                    mahdn = Console.ReadLine();
                    try
                    {
                        hdn=hoadonnhap.GetHDN(mahdn);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Tool.WriteXY(y,x,ex.Message);
                    }
                }
                Tool.WriteXY(y, x, "                                      ");

                #region hiện thông tin cũ
                Tool.WriteXY(5, 56, hdn.Tenncc);
                Tool.WriteXY(5, 90, hdn.Ngaynhap.Day.ToString());
                Tool.WriteXY(5, 93, hdn.Ngaynhap.Month.ToString());
                Tool.WriteXY(5, 96, hdn.Ngaynhap.Year.ToString());

                List<CTNhaphang> dsctnh = ctnhaphang.TimCTNH(hdn.Mahdn);
                int i = 9;
                foreach(CTNhaphang ctnh in dsctnh)
                {
                    Tool.WriteXY(i,0,"                                        ║               ║                 ║ ");
                    Tool.WriteXY(i, 27, ctnh.Mavl);
                    Tool.WriteXY(i, 44, String.Format("{0:0,0}",ctnh.Gianhap));
                    Tool.WriteXY(i, 61, ctnh.Soluong.ToString());
                    Tool.WriteXY(i, 79, String.Format("{0:0,0}",ctnh.Tongtien));
                    i++;
                }
                Tool.WriteXY(i + 1,0,"     -------------------------------------------------------------------------------------------------------") ;
                Tool.WriteXY(i + 2, 0, $"               Tổng tiền: {String.Format("{0:0,0}",hdn.Tongtien)}                                         ");
                #endregion

                //sửa ngày xuất
                DateTime ngaynhap;
                string ngay, thang, nam;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(5, 90, "  ");
                        if (ngay == "")
                        {
                            ngay = hdn.Ngaynhap.Day.ToString();
                        }
                        thang = Tool.ReadInfoXY(5, 93, "  ");
                        if (thang == "")
                        {
                            thang = hdn.Ngaynhap.Month.ToString();
                        }
                        nam = Tool.ReadInfoXY(5, 96, "  ");
                        if (nam == "")
                        {
                            nam = hdn.Ngaynhap.Year.ToString();
                        }

                        ngaynhap = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));
                        break;
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y, x, "Bạn nhập sai định dạng           ");

                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(y, x, "Thời gian này không tồn tại      ");
                    }
                }
                Tool.WriteXY(y, x, "                                                   ");
                bool check = false;
                if (ngaynhap != hdn.Ngaynhap)
                {
                    hdn.Ngaynhap = ngaynhap;
                    check = true;
                }

                if (check)
                {
                    hoadonnhap.SuaHDN(hdn);
                }

                Tool.WriteXY(i + 4, 0, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            
        }

        //vì hóa đơn nhập ít nên có thể hiển thị cả chi tiết hóa đơn
        public void HienDSHoadonnhapTimkiem(List<HDNhap> ds)
        {
            foreach (HDNhap a in ds)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"                                                  HÓA ĐƠN NHẬP {a.Mahdn}                                             ");
                Console.WriteLine("     ═══════════════════════════════════════════════════════════════════════════════════════════════════════════   ");
                Console.WriteLine();
                Console.WriteLine($"      Nhà cung cấp:{a.Tenncc}                                        Ngày nhập: {a.Ngaynhap.Day}/{a.Ngaynhap.Month}/{a.Ngaynhap.Year}        ");
                Console.WriteLine();
                Console.WriteLine("     ----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"      {"Mã vật liệu",-15}{"║",-15}{"Giá nhập",-15}{"║",-15}{"Số lượng",-15}{"║",-15}{"Thành tiền"}   ");
                foreach (CTNhaphang b in ctnhaphang.TimCTNH(a.Mahdn))
                {
                    Console.WriteLine($"      {b.Mavl,-15}{"║",-15}{String.Format("{0:0,0}", b.Gianhap),-15}{"║",-15}{b.Soluong,-15}{"║",-15}{String.Format("{0:0,0}", b.Tongtien)}");
                }
                Console.WriteLine("     ----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"      Tổng tiền thanh toán:{String.Format("{0:0,0}", a.Tongtien)}               ");
                Console.WriteLine("     ══════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine();
            
            }
        }

        public void Hien()
        {
            List<HDNhap> ds = hoadonnhap.GetListHDN();
            Console.WriteLine($"  {"Mã",-15}{"Tên Nhà cung cấp",-25}{"Ngày nhập hàng",-20}{"Tổng tiền"}");
            foreach (HDNhap a in ds)
            {
                Console.WriteLine($"  {a.Mahdn,-15}{a.Tenncc,-25}{a.Ngaynhap.Day + "/" + a.Ngaynhap.Month + "/" + a.Ngaynhap.Year,-20}{String.Format("{0:0,0}",a.Tongtien)}");
            }
        }

        public void Tim()
        {
            char check;
            while (true)
            {
                try
                {
                    Console.Write("Tìm hóa đơn nhập theo mã nhấn (m), tên nhà cung cấp nhấn (n) hoặc ngày nhập nhấn (d): ");
                    check = Char.ToLower(char.Parse(Console.ReadLine()));
                    if (check == 'm' || check == 'n' || check == 'd')
                    {
                        break;
                    }
                    else
                        Console.WriteLine("Bạn nhập sai");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bạn nhập sai định dạng");
                }
            }
            Console.Clear();
            HDNhap hdn = new HDNhap();
            switch (Char.ToLower(check))
            {
                case 'm':
                    Console.Write("Mời nhập mã hóa đơn nhập: ");
                    hdn.Mahdn=Console.ReadLine();
                    break;
                case 'n':
                    Console.Write("Nhập Tên nhà cung cấp: ");
                    hdn.Tenncc = Console.ReadLine(); break;

                case 'd':
                    int ngay, thang, nam;
                    Console.Write("Ngày Bán:   /   /   ");
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(10, 0);
                            ngay = int.Parse(Console.ReadLine());

                            Console.SetCursorPosition(13, 0);
                            thang = int.Parse(Console.ReadLine());

                            Console.SetCursorPosition(17, 0);
                            nam = int.Parse(Console.ReadLine());
                            hdn.Ngaynhap = new DateTime(nam, thang, ngay);
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Bạn nhập sai định dạng     ");
                        }
                        catch (Exception)
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Thời gian này không tồn tại      ");
                        }
                    }
                    break;
            }
            if (hoadonnhap.TimHDN(hdn).Count > 0)
            {
                HienDSHoadonnhapTimkiem(hoadonnhap.TimHDN(hdn));
            }
            else
            {
                Console.WriteLine("Hóa đơn này không tồn tại");
            }
            Tool.StopScreen();
        }

        public void Xoa()
        {
            Console.Write("Mời nhập mã hóa đơn nhập muốn xóa: ");
            string mahdn = Console.ReadLine();
            try
            {
                hoadonnhap.XoaHDN(mahdn);
                ctnhaphang.XoaCTNH(mahdn);
                Console.WriteLine("Đã xóa thành công hóa đơn nhập có mã " + mahdn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Tool.StopScreen();
        }
    }
}
