using System;
using System.Collections.Generic;
using System.Text;
using Project.Business;
using Project.Entities;
using Project.Utility;
namespace Project.Presentation
{
    class FormVatlieu
    {
        private IVatlieuBLL vatlieu = new VatlieuBLL();
        private ILibraryCheck check = new LibraryCheck();
        public void Them()
        {
            while (true)
            {

                Vatlieu a = new Vatlieu();
                Console.WriteLine();
                Console.WriteLine("                                       THÊM VẬT LIỆU                                ");
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"         Tên:                         Đơn vị tính:                   Mức cần nhập hàng:             ");
                Console.WriteLine();
                Console.WriteLine($"                  Gía nhập:                             Gía bán:                                  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");

                int i = 11;//dòng thông báo lỗi
                //nhập tên vật liệu
                while (true)
                {
                    Console.SetCursorPosition(14, 4);
                    a.Ten = Console.ReadLine();
                    if (a.Ten.Trim() != "")
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0,"Tên không được trống");
                    }
                }


                //nhập đơn vị tính cho vật liệu
                while (true)
                {
                    Console.SetCursorPosition(51, 4);
                    a.Donvitinh = Console.ReadLine();
                    if (a.Donvitinh.Trim() != "")
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Đơn vị tính phải khác rỗng");
                    }
                }
                Tool.WriteXY(i, 0, "                                ");

                //nhập mức cần nhập hàng
                string mucnhaphang;
                while (true)
                {
                    Console.SetCursorPosition(88, 4);
                    mucnhaphang=Console.ReadLine();
                    if(mucnhaphang.Trim() != "")
                    {
                        if (Tool.DuyetChuoiSo(mucnhaphang) == false)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng                        ");
                        }
                        if (a.Mucnhaphang <0)
                        {
                            Tool.WriteXY(i, 0, "Mức tồn kho cần nhập hàng không được nhỏ hơn 0");
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
                if(mucnhaphang!="")
                {
                    a.Mucnhaphang = int.Parse(mucnhaphang);
                }
                else
                {
                    a.Mucnhaphang = 0;
                }

                //nhập giá nhập giá bán cho vật liệu
                while (true)
                {
                    try
                    {                        
                        Console.SetCursorPosition(28, 6);
                        a.Gianhap = int.Parse(Console.ReadLine());
                        if (a.Gianhap > 0)
                        {
                            break;
                        }
                        else
                        {                            
                            Tool.WriteXY(i, 0, "GIÁ NHẬP LỚN HƠN 0    ");
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng");
                    }
                }
                Tool.WriteXY(i, 0, "                                           ");

                //nhập giá bán
                while (true)
                {
                    
                    try
                    {
                        Console.SetCursorPosition(65, 6);
                        a.Giaban = int.Parse(Console.ReadLine());
                        if (a.Giaban > 0)
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "GIÁ BÁN LỚN HƠN 0     ");
                        }
                    }
                    catch (FormatException)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng");
                    }
                }
                Tool.WriteXY(i, 0, "                                           ");


                //nhập số lượng vật liệu
                a.Soluong = 0; //khi thêm một vật liệu mới thì số lượng bằng 0

                vatlieu.ThemVL(a);

                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu nhập tiếp nhấn bất kì: ");
                ConsoleKeyInfo key=Console.ReadKey();
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
                Console.WriteLine("                                      SỬA THÔNG TIN VẬT LIỆU                                        ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("               Mã:                           Tên:                             Đơn vị tính:              ");
                Console.WriteLine();
                Console.WriteLine("               Mức cần nhập:                 Gía nhập:                        Gía bán:                  ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");
                int i = 11;

                string ma;

                Vatlieu vl;

                //nhập mã vật liệu muốn sửa
                while (true)
                {
                    Console.SetCursorPosition(19, 4);
                    ma = Console.ReadLine();
                    try
                    {
                        vl = vatlieu.GetVL(ma); //gán đối tượng a bằng với đối tượng có mã là ma trong danh sách vật liệu
                        break;
                    }
                    catch (Exception e)
                    {
                        Tool.WriteXY(i, 0, "Vật liệu này không tồn tại");
                    }
                }
                Tool.WriteXY(i, 0, "                                     ");

                #region hiện thông tin vật liệu cũ
                Tool.WriteXY(4, 50, vl.Ten);
                Tool.WriteXY(4, 91, vl.Donvitinh.ToString());
                Tool.WriteXY(6,29,vl.Mucnhaphang.ToString());
                Tool.WriteXY(6, 55, String.Format("{0:0,0}",vl.Gianhap));
                Tool.WriteXY(6,87, String.Format("{0:0,0}", vl.Giaban));
                #endregion

                //cho nhập vào những biến dữ liệu số là string để khi người dùng không muốn sửa dử liệu này thì chỉ cần nhấn Enter
                string ten, donvitinh;
                string giaban, gianhap,muccannhap;

                bool checkChange=false;//kiểm tra xem người dùng có thay đổi thồn tin không
                //sửa tên vật liệu 
                ten = Tool.ReadInfoXY(4, 50, vl.Ten);
                if (ten != "" && ten != vl.Ten)
                {
                    vl.Ten = ten;
                    checkChange=true;
                }


                //sửa đơn vị tính
                donvitinh = Tool.ReadInfoXY(4,91, vl.Donvitinh);
                if (donvitinh != "" && donvitinh != vl.Donvitinh)
                {
                    vl.Donvitinh = donvitinh;
                    checkChange = true;

                }

                //Sửa mức tồn kho cần nhập hàng
                while (true)
                {
                    muccannhap = Tool.ReadInfoXY(6, 29, vl.Mucnhaphang.ToString());
                    if(muccannhap != "")
                    {
                        if (Tool.DuyetChuoiSo(muccannhap)==false)
                        { 
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng               ");

                        }
                        else if (int.Parse(muccannhap) < 0)
                        {
                            Tool.WriteXY(i, 0, "Mức cần nhập hàng không được nỏ hơn 0");
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
                Tool.WriteXY(i, 0, "                                               ");
                if(muccannhap !="" && int.Parse(muccannhap) != vl.Mucnhaphang)
                {
                    vl.Mucnhaphang = int.Parse(muccannhap);
                }

                //sửa giá nhập 
                while (true)
                {
                    gianhap = Tool.ReadInfoXY(6, 55, String.Format("{0:0,0}", vl.Gianhap));
                    if (gianhap != "")
                    {
                        if((Tool.DuyetChuoiSo(gianhap) == true && int.Parse(gianhap)>0))
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng hoặc giá nhỏ hơn 0");                       
                        }
                    }
                    else { break; }

                }
                Tool.WriteXY(i, 0, "                                                    ");
                if (gianhap != "" && int.Parse(gianhap) != vl.Gianhap)
                {
                    vl.Gianhap = int.Parse(gianhap);
                    checkChange = true;

                }

                //sửa giá bán
                while (true)
                {
                    giaban = Tool.ReadInfoXY(6, 87, String.Format("{0:0,0}",vl.Giaban));
                    if(giaban != "")
                    {
                        if ((Tool.DuyetChuoiSo(giaban) == true && int.Parse(giaban)>0))
                        {
                            break;
                        }
                        else
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng hoặc giá nhỏ hơn 0");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Tool.WriteXY(i, 0, "                                                    ");
                if (giaban != "" && int.Parse(giaban) != vl.Giaban)
                {
                    vl.Giaban = int.Parse(giaban);
                    checkChange=true;
                }
                               

                if (checkChange)//nếu người dùng không sửa trường dữ liệu nào thì thôi
                {
                    vatlieu.SuaVL(vl);
                }

                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    
                    break;
                }
            }
        }

        public void Xoa()
        {
            string ma;
            while (true)
            {
                Console.Write("Mời nhập mã vật liệu muốn xóa: ");
                ma = Console.ReadLine();
                try
                {
                    vatlieu.XoaVL(ma);
                    Console.WriteLine("Đã xóa thành công vật liệu có mã {0}", ma);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Nhấn Enter để thoát, nếu xóa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        //Hiện 1 list vật liệu được truyền vào
        public void DisplayListVL(List<Vatlieu> ds)
        {
            Console.WriteLine($@"   {"Mã",-10}{"Tên",-20}{"Đơn vị tính",-17}{"Giá nhập",-17}{"Giá bán",-17}{"Tồn kho",-17}{"Mức cần nhập"}");
            foreach (Vatlieu v in ds)
            {
                Console.WriteLine($@"   {v.Ma,-10}{v.Ten,-20}{v.Donvitinh,-17}{String.Format("{0:0,0}", v.Gianhap),-17}{String.Format("{0:0,0}", v.Giaban),-17}{v.Soluong,-17}{v.Mucnhaphang}");
            }
        }

        //hiện tất cả dữ liệu
        public void Hien()
        {
            List<Vatlieu> ds = vatlieu.GetListVL();
            DisplayListVL(ds);
        }

        public void TimVL()
        {
            Vatlieu v = new Vatlieu();
            char c;
            while (true)
            {
                Console.Clear();
                while (true)
                {
                    Console.Write("\nNếu tìm mã nhấn (m), nếu tìm tên nhấn (t): ");
                    try
                    {
                        c = Char.ToLower(char.Parse(Console.ReadLine()));
                        if (c == 'm' || c == 't' || c == 'g')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("BẠN NHẬP SAI MỜI NHẬP LẠI");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("BẠN NHẬP SAI ĐỊNH DẠNG");
                    }
                }
                Console.Clear();
                switch (c)
                {
                    case 'm':
                        Console.Write("Mời nhập mã muốn tìm: ");
                        v.Ma = Console.ReadLine();
                        break;
                    case 't':
                        Console.Write("Mời nhập tên muốn tìm: ");
                        v.Ten = Console.ReadLine();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();

                List<Vatlieu> dsvatlieu = vatlieu.TimVL(v);
                if (dsvatlieu.Count > 0)
                {
                    DisplayListVL(dsvatlieu);
                }
                else
                    Console.WriteLine("Thông tin vật liệu không tồn tại");

                Console.Write("\n\nNhấn Enter để thoát, nếu tìm tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }

            }
        }

        public void VLCannhap()
        {
            List<Vatlieu> vatlieus = vatlieu.VatlieuCannhap();
            if (vatlieus.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Những vật liệu cần nhập hàng");
                Console.WriteLine();
                DisplayListVL(vatlieus);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Không có vật liệu nào trong mức cần nhập hàng");
            }

            Tool.StopScreen();
        }

        public void TimGia()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Loại:                          Giá từ:                           Đến: ");
            string loai;
            int giadau, giacuoi;

            Console.SetCursorPosition(5, 1);
            loai = Console.ReadLine();

            while (true)
            {
                Console.SetCursorPosition(39, 1);
                giadau = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(70, 1);
                giacuoi = int.Parse(Console.ReadLine());
                if (giadau > 0 && giacuoi>0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Giá phải lớn hơn 0");
                }
            }
            Console.Clear();
            List<Vatlieu> ds=vatlieu.TimGia(loai,giadau,giacuoi);
            if(ds.Count > 0)
            {
                DisplayListVL(ds);
            }
            else
            {
                Console.WriteLine("Không tìm thấy");
            }
            Console.WriteLine();
            Tool.StopScreen();
        }

    }
}
