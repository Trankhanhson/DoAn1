using System;
using System.Collections.Generic;
using System.Text;
using Project.Business;
using Project.Entities;
using Project.Utility;
namespace Project.Presentation
{
    class FormNCC
    {
        private INhacungcapBLL ncc = new NhacungcapBLL();
        public void Them()
        {
            while (true)
            {

                Nhacungcap newNCC = new Nhacungcap();
                Console.WriteLine();
                Console.WriteLine("                           NHẬP THÔNG TIN NHÀ CUNG CẤP                            ");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Tên:                  Địa chỉ:                         Số điện thoại:              ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");
                int i = 9;

                //nhập tên ncc
                while (true)
                {
                    Console.SetCursorPosition(4, 4); newNCC.Ten = Tool.Catxau(Console.ReadLine());
                    if (newNCC.Ten.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Tên không được để trống     ");
                    }
                }
                Tool.WriteXY(i, 0, "                                        ");

                //nhâ[j địa chỉ
                while (true)
                {
                    Console.SetCursorPosition(30, 4);
                    newNCC.Diachi = Console.ReadLine();
                    if (newNCC.Diachi.Trim() != null)
                    {
                        break;
                    }
                    else
                    {
                        Tool.WriteXY(i, 0, "Địa chỉ không được trống");

                    }
                }
                Tool.WriteXY(i, 0, "                                                ");

                while (true)
                {
                    Console.SetCursorPosition(69, 4);
                    newNCC.Sdt = Console.ReadLine();

                    if (Tool.DuyetChuoiSo(newNCC.Sdt) == false)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập sai định dạng");
                    }
                    else if (newNCC.Sdt.Length !=10 && newNCC.Sdt.Length !=9 && newNCC.Sdt.Length!=8)
                    {
                        Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số");
                    }
                    else
                    {
                        break;
                    }                   
                }
                //thêm đối tượng vào danh sách
                ncc.ThemNCC(newNCC);

                Tool.WriteXY(i + 2, 0, "Nhấn Enter để thoát, nếu nhập tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public void Xoa()
        {
            string ma;
            while (true)
            {
                Console.Write("MỜI NHẬP MÃ NHÀ CUNG CẤP MUỐN XÓA: ");
                ma = Console.ReadLine();
                try
                {
                    ncc.XoaNCC(ma);
                    Console.WriteLine("Nhà cung cấp có mã {0} đã được xóa", ma);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("\n\nNhấn Enter để thoát, nếu xóa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

            }
        }

        public void DisplayListNCC(List<Nhacungcap> ds)
        {
            Console.WriteLine($@"  {"Mã",-10}{"Tên",-20}{"Địa chỉ",-30}{"Số điện thoại"}");
            foreach (Nhacungcap a in ds)
            {
                Console.WriteLine($@"  {a.Ma,-10}{a.Ten,-20}{a.Diachi,-30}{a.Sdt}");
            }
        }

        public void Hien()
        {
            List<Nhacungcap> list = ncc.GetListNCC();
            DisplayListNCC(list);          
        }

        public void Sua()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("                                SỬA THÔNG TIN NHÀ CUNG CẤP                                      ");
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Mã:              Tên:                  Địa chỉ:                        Số điện thoại:           ");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("THÔNG BÁO LỖI");

                Nhacungcap newncc;
                int i = 10;
                
                string ma, ten, diachi, sdt;//tạo các biến đẻ chứa thông tin mới sửa

                while (true)
                {
                    Console.SetCursorPosition(4, 4);
                    ma = Console.ReadLine();
                    try
                    {
                        newncc = ncc.GetNCC(ma);////gán đói tượng newnc bằng đối tượng có ma trong danh sách
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.SetCursorPosition(0, i);
                        Console.WriteLine(e.Message);
                    }
                }
                Tool.WriteXY(i, 0, "                                  ");

                #region hiện thông tin nhà cung cấp cũ
                Tool.WriteXY(4, 22, newncc.Ten);
                Tool.WriteXY(4, 48, newncc.Diachi);
                Tool.WriteXY(4, 85, newncc.Sdt);
                #endregion

                bool checkChange = false; //kiểm tra xem người dùng có sửa hay không

                //sửa tên nhà cung cấp
                ten = Tool.ReadInfoXY(4, 22, newncc.Ten);
                if (ten != "" && ten != newncc.Ten)
                {
                    newncc.Ten = ten;
                    checkChange = true;
                }

                //sửa địa chỉ
                Console.SetCursorPosition(48, 4);
                diachi = Tool.ReadInfoXY(4, 48, newncc.Diachi);
                if (diachi != "" && diachi != newncc.Diachi)
                {
                    newncc.Diachi = diachi;
                    checkChange = true;

                }

                //sửa số ddienj thoại
                while (true)
                {
                    sdt = Tool.ReadInfoXY(4,85, newncc.Sdt);
                    if(sdt != "")
                    {
                        if (Tool.DuyetChuoiSo(sdt) == false)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập sai định dạng      ");
                        }
                        else if (sdt.Length != 10 && sdt.Length != 9)
                        {
                            Tool.WriteXY(i, 0, "Bạn nhập thiếu hoặc thừa số     ");
                        }
                        else
                            break;
                    }
                    else
                    {
                        break;
                    }
                }
                Tool.WriteXY(i, 0, "                                             ");
                if (sdt != "" && sdt != newncc.Sdt)
                {
                    newncc.Sdt = sdt;
                    checkChange = true;

                }

                //sửa đối tượng nhà cung cấp chỉ định
                if (checkChange)
                {
                    ncc.SuaNCC(newncc);
                }

                Tool.WriteXY(i+2,0,"Nhấn Enter để thoát, nếu sửa tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        }

        public void Tim()
        {
            Nhacungcap n = new Nhacungcap();
            char c;
            while (true)
            {
                while (true)
                {
                    Console.Write("\nNếu tìm mã nhấn (m), nếu tìm tên nhấn (t), nếu tìm số điện thoại nhấn (s), nếu tìm địa chỉ nhấn (d): ");
                    try
                    {
                        c = Char.ToLower(char.Parse(Console.ReadLine()));
                        if (c == 'm' || c == 't' || c == 's' || c == 'd')
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
                        Console.Write("Mời nhập mã nhà cung cấp muốn tìm: ");
                        n.Ma = Console.ReadLine();
                        break;
                    case 't':
                        Console.Write("Mời nhập tên nhà cung cấp muốn tìm: ");
                        n.Ten = Console.ReadLine();
                        break;
                    case 's':
                        Console.Write("Mời nhập số điện thoại của nhà cung cấp muốn tìm: ");
                        n.Sdt = Console.ReadLine();
                        break;
                    case 'd':
                        Console.Write("Mời nhập địa chỉ nhà cung cấp muốn tìm: ");
                        n.Diachi = Console.ReadLine();
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
                List<Nhacungcap> nhacungcaps = ncc.TimNCC(n);
                if (nhacungcaps.Count > 0)
                {
                    DisplayListNCC(nhacungcaps);
                }
                else
                { Console.WriteLine("Thông tin nhà cung cấp không tồn tại"); }

                Console.Write("\n\nNhấn Enter để thoát, nếu tìm tiếp nhấn bất kì: ");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }

            
        }
            
    }
}
