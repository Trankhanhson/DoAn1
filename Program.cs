using System;
using System.Text;
using Project.Presentation;
using Project.Utility;
namespace Project
{
    class Program
    {
        static void Main()
        {
            LogIn logIn = new LogIn();
            int count = logIn.CheckLogIn("ĐỒ ÁN 1", "125202");
            if (count <= 4)
            {
                Hien();
            }
            else
                Console.Clear();
                Environment.Exit(0);
        }
        
        static void Hien()
        {
            Menu menu=new Menu();   
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                int check;
                do
                {
                    Console.SetCursorPosition(37, 2);
                    Console.WriteLine(@$"╔════════════════════════════════════════════════════════╗
                                     ║                       TỔNG QUAN                        ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 1. BÁN HÀNG                                            ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 2. NHẬP HÀNG                                           ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 3. QUẢN LÝ VẬT LIỆU                                    ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 4. QUẢN LÝ PHIẾU CHI                                   ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 5. NHÀ CUNG CẤP                                        ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 6. QUẢN LÝ KHÁCH HÀNG                                  ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 7. QUẢN LÝ NHÂN VIÊN                                   ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 8. BÁO CÁO                                             ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ 9. DỪNG CHƯƠNG TRÌNH                                   ║
                                     ║════════════════════════════════════════════════════════║
                                     ║ MỜI CHỌN CHỨC NĂNG:                                    ║
                                     ╚════════════════════════════════════════════════════════╝");
                    while(true)
                    {
                        try
                        {
                            Console.SetCursorPosition(60, 23);
                            check = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                    }                  
                    Console.Clear();

                    switch (check)
                    {
                        case 1:

                            menu.ChonMenuHD();
                            break;
                        case 2:
                            menu.ChonMenuNhapHang();
                            break;
                        case 3:
                            
                            menu.ChonMenuVL();
                            break;
                        case 4:
                            menu.ChonMenuPhieuChi();
                            break;
                        case 5:
                            menu.ChonMenuNCC();
                            break;
                        case 6:
                            menu.ChonMenuKH();

                            break;
                        case 7:
                            menu.ChonMenuNV();

                            break;
                        case 8:
                            menu.ChonMenuBaocao();
                            break;
                        case 9:
                            Environment.Exit(0);
                            break;

                    }
                } while (check < 1 || check > 9);
            }

        }

    }
}

