using System;
using System.Collections.Generic;
using System.Text;
using Project.Business;
using Project.Entities;
using Project.Utility;
namespace Project.Presentation
{
    class FormHoadon
    {
        private IHoadonBLL hoadon = new HoadonBLL();
        private ICTHoadonBLL cthoadon = new CTHoadonBLL();
        private ILibraryCheck check = new LibraryCheck();
        private IKhachhangBLL kh = new KhachhangBLL();
        private IVatlieuBLL vatlieu=new VatlieuBLL();
        public void Them()
        {
            Hoadon hd;
            while (true)
            {
                hd = new Hoadon();
                List<CTHoadon> ListCTHoadons = new List<CTHoadon>();
                List<Hoadon> ds = hoadon.GetListHD();
                Console.WriteLine("                                                 ĐẠI LÝ VẬT LIỆU XÂY DỰNG DA1                                     ");
                Console.WriteLine("    ------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                       HÓA ĐƠN BÁN HÀNG                                            ");
                Console.WriteLine("    ══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine("    Mã khách hàng:                 Tên khách:                         Mã nhân viên:                 Ngày:   /  /     ");
                Console.WriteLine();
                Console.WriteLine("    Số loại vật liệu:                                                                    ");
                Console.WriteLine("    ══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine("    Mã vật liệu  ║     Tên vật liệu       ║     Đơn vị      ║    Đơn giá     ║    Số lượng    ║  Thành tiền    ║  ");

                

                int x = 4;//số cột thông báo lỗi
                int y = 30;//số dong thông báo lỗi
                //gán mã hóa đơn tự động tại form để gán vào chi tiết hóa đơn
                int mahd;
                if (ds.Count == 0)
                {
                    mahd = 1;
                }
                else
                {
                    int i = ds.Count - 1;//vị trí cuối cùng của list
                    mahd = int.Parse(ds[i].Mahd.Substring(2)) + 1;
                }
                hd.Mahd = "HD"+ mahd.ToString();


                //hiện ngày xuất trước tiên
                DateTime now = DateTime.Now;
                Tool.WriteXY(5, 106, now.Day.ToString());
                Tool.WriteXY(5, 109, now.Month.ToString());
                Tool.WriteXY(5, 112, now.Year.ToString());

                //nhập mã khách hàng
                while (true)
                {
                    Console.SetCursorPosition(19, 5);
                    hd.Makh = Console.ReadLine();
                    if (check.CheckListKH(hd.Makh) == true || hd.Makh == "k")
                    {
                        break;
                    }
                    else
                        Tool.WriteXY(y,x, "Nếu là khách lẻ thì nhấn k");                  
                }
                Tool.WriteXY(y, x, "                                                        ");

                //Hiện luôn tên khách hàng
                if (hd.Makh != "k")
                {
                    Khachhang a = kh.GetKH(hd.Makh);
                    hd.Tenkh = a.Ten;
                    
                }
                else {
                    hd.Tenkh = "Khách lẻ";                   
                }

                Tool.WriteXY(5, 46, hd.Tenkh);

                //nhập mã nhân viên
                while (true)
                {
                    Console.SetCursorPosition(84, 5);
                    hd.Manv = Console.ReadLine();
                    if (check.CheckListNV(hd.Manv) == true)
                    {
                        break;
                    }
                    else
                        Tool.WriteXY(y, x, "Mã nhân viên này không tồn tại   ");
                    
                }
                Tool.WriteXY(y, x, "                                                        ");

                //nhập ngày xuất đơn 
                
                DateTime ngayxuat;
                string ngay, thang, nam;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(5, 106, "  ");
                        if (ngay == "")
                        {
                            ngay = now.Day.ToString();
                        }
                        thang = Tool.ReadInfoXY(5,109,"  ");
                        if (thang == "")
                        {
                            thang = now.Month.ToString();
                        }
                        nam = Tool.ReadInfoXY(5,112,"    ");
                        if (nam == "")
                        {
                            nam = now.Year.ToString();
                        }

                        ngayxuat = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));
                        hd.Ngayxuat = ngayxuat;
                        break;
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y,x, "Bạn nhập sai định dạng              ");

                    }
                    catch (Exception)
                    {
                        Tool.WriteXY(y, x, "Thời gian này không tồn tại          ");
                    }
                }
                Tool.WriteXY(y, x, "                                                   ");

                //nhập số loại vật liệu
                int sovl;
                int sovatlieukho = vatlieu.GetListVL().Count;
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(22, 7);
                        sovl = int.Parse(Console.ReadLine());
                        if (sovl < 0 )
                        {
                            Tool.WriteXY(y, x, "Số vật liệu phải lớn hơn 0        ");
                        }
                        else if(sovl > sovatlieukho)
                        {
                            Tool.WriteXY(y, x, $"Trong kho còn {sovatlieukho} loại vật liệu   ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y, x, "Bạn nhập sai định dạng             ");
                    }
                }
                Tool.WriteXY(10, 80, "                                              ");


                //nhập danh dách chí tiết các vật liệu
                int indexline = 10;
                for (int i = 0; i < sovl; i++)
                {
                    CTHoadon ct = new CTHoadon();
                    Console.SetCursorPosition(0, indexline);
                    Console.WriteLine($"                 ║                        ║                 ║                ║                ║                ║  ");

                    ct.Mahd = hd.Mahd;//Mã của chi tiết hóa đơn = mã hóa đơn

                    //nhập mã vật liệu
                    Vatlieu vl;
                    while (true)
                    {
                        Console.SetCursorPosition(5, indexline);
                        ct.Mavl = Console.ReadLine();
                        try
                        {
                            vl=vatlieu.GetVL(ct.Mavl);
                            if (vl.Soluong > 0)
                            {
                                Tool.WriteXY(indexline, 23, vl.Ten);
                                Tool.WriteXY(indexline, 48, vl.Donvitinh);
                                Tool.WriteXY(indexline,65,String.Format("{0:0,0}",vl.Giaban));
                                break;
                            }
                            else
                            {
                                Tool.WriteXY(y, x, "Vật liệu này đã hết hàng nên không thể bán");
                            }                           
                        }
                        catch(Exception ex)
                        {
                            Tool.WriteXY(y, x, ex.Message);
                        }
                    }
                    Tool.WriteXY(y, x, "                                                        ");


                    //nhập số lượng
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(82, indexline);
                            ct.Soluong = int.Parse(Console.ReadLine());
                            if (ct.Soluong < 0 )
                            {
                                Tool.WriteXY(y, x, "Số lượng phải lớn hơn 0           ");
                            }
                            else if (ct.Soluong > vatlieu.GetVL(ct.Mavl).Soluong)
                            {
                                Tool.WriteXY(y, x, "Số lượng vượt quá hàng tồn trong kho");
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Tool.WriteXY(y, x, "Bạn nhập sai định dạng                ");    
                        }
                    }
                    Tool.WriteXY(y, x, "                                                        ");                 

                    ct.Tongtien=cthoadon.TongCtHoadon(ct.Mavl,ct.Soluong);
                    ct.Tienlai = cthoadon.TienlaiCTHD(ct.Mavl,ct.Soluong);
                    Tool.WriteXY(indexline,97,String.Format("{0:0,0}",ct.Tongtien));

                    ListCTHoadons.Add(ct);
                    indexline++;
                }
                Console.SetCursorPosition(0, indexline);
                Console.WriteLine($"    ═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════");

                //Tính tổng tiền của hóa đơn
                hd.Tongtien = hoadon.TongTienBill(ListCTHoadons);

                //Tính tiền lãi của bill
                hd.Tienlai = hoadon.TienlaiBill(ListCTHoadons);

                //in ra tổng tiền và nhập tiền khách hàng đã thanh toán
                Tool.WriteXY(indexline+2,0,"             Tổng tiên phải thanh toán:                           Khách thanh toán:  ");
                Tool.WriteXY(indexline + 2, 40, String.Format("{0:0,0}",hd.Tongtien));
                //nhập tiền khách thanh toán
                while (true)
                {
                    try
                    {
                        Console.SetCursorPosition(84, indexline + 2);
                        hd.Dathanhtoan = int.Parse(Console.ReadLine());
                        if(hd.Makh=="k" && hd.Dathanhtoan < hd.Tongtien)
                        {
                            Tool.WriteXY(y, x, "Khách lẻ không được nợ         ");
                        }
                        else if (hd.Dathanhtoan < 0)
                        {
                            Tool.WriteXY(y, x, "Tiền đã thanh toán phải lớn hơn 0    ");
                        }
                        else if (hd.Dathanhtoan > hd.Tongtien)
                        {
                            Tool.WriteXY(y, x, "Tiền đã thanh toán nhỏ hơn tổng tiền");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(y, x, "Bạn nhập sai định dạng          ");    
                    }
                }
                Tool.WriteXY(y, x, "                                 ");

                //thêm dánh sách chi tiết hóa đơn
                cthoadon.ThemCTHD(ListCTHoadons);

                //Thêm hóa đơn
                hoadon.ThemHD(hd);

                Tool.WriteXY(indexline + 4, 8, "Nhấn Enter để thoát, nếu nhập tiếp nhấn bất kì: ");
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

                Console.WriteLine($"                                             ĐẠI LÝ VẬT LIỆU XÂY DỰNG DA1                                     ");
                Console.WriteLine($"    --------------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"                                                   HÓA ĐƠN BÁN HÀNG                                           ");
                Console.WriteLine($"    ══════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine();
                Console.WriteLine($"    Mã hóa đơn:           Mã khách:            Tên khách:                  Mã nhân viên:        Ngày:   /  /");
                Console.WriteLine();
                Console.WriteLine($"    Số loại vật liệu: ");
                Console.WriteLine($"    ══════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine($"            Mã vật liệu     ║   Tên vật liệu   ║   Đơn vị     ║    Số lượng    ║    Tổng tiền      ");

                Hoadon hd;//chứa thông tin hóa đơn cũ
                int x = 4;//số cột thoogn báo
                int y = 25;//số dòng thông báo

                //nhập mã hóa đơn muốn sửa
                string ma;
                while (true)
                {
                    Console.SetCursorPosition(15,5);
                    ma= Console.ReadLine();
                    try
                    {
                        hd = hoadon.GetHD(ma);
                        break;
                    }
                    catch(Exception e)
                    {
                        Tool.WriteXY(y, x, e.Message);
                    }
                }
                Tool.WriteXY(y,x, "                                         ");


                List<CTHoadon> cthdOld = cthoadon.TimCTHD(hd.Mahd);//gán chi tiết hóa đơn được tìm thấy vào cthdOld

                #region hiển thị thông tin háo đơn cũ
                Tool.WriteXY(5, 35, hd.Makh);
                Tool.WriteXY(5, 57, hd.Tenkh);
                Tool.WriteXY(5, 88, hd.Manv);
                Tool.WriteXY(5, 102, hd.Ngayxuat.Day.ToString());
                Tool.WriteXY(5, 105, hd.Ngayxuat.Month.ToString());
                Tool.WriteXY(5, 108, hd.Ngayxuat.Year.ToString());
                Tool.WriteXY(7, 21, cthdOld.Count.ToString());

                int indexline = 10;
                foreach(CTHoadon ct in cthdOld)
                {
                    Console.SetCursorPosition(0, indexline);
                    Console.WriteLine($"                            ║                  ║              ║                ║    ");
                    Tool.WriteXY(indexline, 12, ct.Mavl);
                    Vatlieu vl = vatlieu.GetVL(ct.Mavl);
                    Tool.WriteXY(indexline, 32, vl.Ten);
                    Tool.WriteXY(indexline, 51, vl.Donvitinh);
                    Tool.WriteXY(indexline, 67, ct.Soluong.ToString());
                    Tool.WriteXY(indexline,84,String.Format("{0:0,0}",ct.Tongtien));               
                    indexline++;
                }

                Console.SetCursorPosition(0, indexline);
                Console.WriteLine("    --------------------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(0, indexline + 2);
                Console.Write($"           Tổng tiên phải thanh toán:                       Tiền đã thanh toán: ");
                Tool.WriteXY(indexline + 2, 38, String.Format("{0:0,0}", hd.Tongtien));
                Tool.WriteXY(indexline + 2, 80, String.Format("{0:0,0}", hd.Dathanhtoan));
                #endregion


                string manhanvien;
                bool checkChange = false;
                //sua ma nhan vien
                while (true)
                {
                    manhanvien=Tool.ReadInfoXY(5,88,hd.Manv);
                    if(check.CheckListNV(manhanvien) == true || manhanvien == "")
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(y, x, "Nhân viên này không tồn tại");
                    }
                }
                Tool.WriteXY(y, x, "                                       ");

                if(manhanvien != "" && manhanvien != hd.Manv)
                {
                    hd.Manv = manhanvien;
                    checkChange=true;
                }

                //sửa ngày xuất
                DateTime ngayxuat;
                string ngay, thang, nam;
                while (true)
                {
                    try
                    {
                        ngay = Tool.ReadInfoXY(5, 102, "  ");
                        if (ngay == "")
                        {
                            ngay = hd.Ngayxuat.Day.ToString();
                        }
                        thang = Tool.ReadInfoXY(5, 105, "  ");
                        if (thang == "")
                        {
                            thang = hd.Ngayxuat.Month.ToString();
                        }
                        nam = Tool.ReadInfoXY(5, 108, "  ");
                        if (nam == "")
                        {
                            nam = hd.Ngayxuat.Year.ToString();
                        }

                        ngayxuat = new DateTime(int.Parse(nam), int.Parse(thang), int.Parse(ngay));                       
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
                if (ngayxuat != hd.Ngayxuat)
                {
                    hd.Ngayxuat = ngayxuat;
                }

                //sửa trường đã thanh toán
                string dathanhtoan;
                while (true)
                {                
                    dathanhtoan=Tool.ReadInfoXY(indexline+2,80, String.Format("{0:0,0}", hd.Dathanhtoan));
                    if(dathanhtoan != "")
                    {
                        if (Tool.DuyetChuoiSo(dathanhtoan) == false)
                        {
                            Tool.WriteXY(y, x, "Bạn nhập sai định dạng                                        ");
                        }
                        else if (int.Parse(dathanhtoan) > hd.Tongtien)
                        {
                            Tool.WriteXY(y, x, "Tiền khách thanh toán không được lớn hơn tổng tiềnn phải trả");
                        }
                        else if (int.Parse(dathanhtoan) < hd.Dathanhtoan)
                        {
                            Tool.WriteXY(y, x, "Không được nhỏ hơn tiền khách đã thanh toán trong hóa đơn      ");
                        }
                        else
                        {
                            break;
                        }
                    }
                    else {
                        break;       
                    }
                }
                Tool.WriteXY(y, x, "                                                                            ");

                if(dathanhtoan!=""&& int.Parse(dathanhtoan)!=hd.Dathanhtoan)
                {
                    hd.Dathanhtoan = int.Parse(dathanhtoan);
                    checkChange=true;
                }
            
                if (checkChange)
                {
                    hoadon.SuaHD(hd);
                }
                Tool.WriteXY(indexline + 4, 0, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void HienDSHoadon(List<Hoadon> ds)
        {
            Console.WriteLine($"  {"Mã hóa đơn",-15}{"Mã nhân viên",-15}{"Mã khách",-15}{"Tên khách",-20}{"Ngày xuất",-15}{"Tổng tiền",-20}{"Khách thanh toán"}");
            for(int i=ds.Count-1;i>=0;i--)
            {
                Console.WriteLine($"  {ds[i].Mahd,-15}{ds[i].Manv,-15}{ds[i].Makh,-15}{ds[i].Tenkh,-20}{ds[i].Ngayxuat.Day + "/" + ds[i].Ngayxuat.Month + "/" + ds[i].Ngayxuat.Year,-15}{String.Format("{0:0,0}",ds[i].Tongtien),-20}{String.Format("{0:0,0}",ds[i].Dathanhtoan)}");
            }

        }

        public void Tim()
        {
            char check;
            while (true)
            {
                try
                {
                    Console.Write("Tìm theo mã hóa đơn nhấn (m), mã nhân viên nhấn (n), tên khách hàng nhấn (k), tìm theo ngày xuất nhấn (x): ");
                    check = Char.ToLower(char.Parse(Console.ReadLine()));
                    if (check == 'm' || check == 'n' || check == 'k' || check == 'x')
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
            Hoadon hd = new Hoadon();
            switch (Char.ToLower(check))
            {
                case 'm':
                    Console.Write("Nhập mã hóa đơn muốn tìm: ");
                    hd.Mahd = Console.ReadLine();
                    break;
                case 'n':
                    Console.Write("Nhập mã nhân viên:                   Thời gian:   /");
                    Console.SetCursorPosition(19,0);
                    hd.Manv = Console.ReadLine();
                    int month, year;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(48, 0);
                            month = int.Parse(Console.ReadLine());

                            Console.SetCursorPosition(51, 0);
                            year = int.Parse(Console.ReadLine());
                            hd.Ngayxuat = new DateTime(year, month, 1);
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

                case 'k':
                    Console.Write("Nhập tên khách hàng khách hàng: ");
                    hd.Tenkh = Console.ReadLine(); break;
                case 'x':
                    int ngay, thang, nam;
                    Console.Write("Ngày bán:   /   /   ");
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
                            hd.Ngayxuat = new DateTime(nam, thang, ngay);
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
            Console.Clear();
            List<Hoadon> hoadons = hoadon.TimHD(hd);
            if (hoadons.Count > 0)
            {
                Console.WriteLine("    Bán được {0} hóa đơn", hoadons.Count);
                Console.WriteLine();
                HienDSHoadon(hoadons);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Hóa đơn này không tồn tại");
            }
            Tool.StopScreen();
        }

        public void Xoa()
        {
            while (true)
            {
                Console.Write("Mời nhập mã hóa đơn muốn xóa: ");
                string mahd = Console.ReadLine();
                try
                {
                    hoadon.XoaHD(mahd);
                    cthoadon.XoaCTHD(mahd);
                    Console.WriteLine("Đã xóa thành công hóa đơn có mã " + mahd);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("\nNhấn Enter để thoát, nhấn bất kì để xóa mã khác: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void Hien()
        {
            List<Hoadon> ds = hoadon.GetListHD();
            HienDSHoadon(ds);
        }

    }
}
