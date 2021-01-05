using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Presenation;

namespace DOAN1
{
    public class Program
    {
        public static void Menu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                Console.SetCursorPosition(40, 1); Console.WriteLine("CHƯƠNG TRÌNH QUẢN LÝ CỬA HÀNG MÔ HÌNH");
                Console.SetCursorPosition(25, 6); Console.WriteLine( "███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 7); Console.WriteLine( "█░                                                                   ░█");
                Console.SetCursorPosition(25, 8); Console.WriteLine( "█░                MENU QUẢN LÝ                                       ░█");
                Console.SetCursorPosition(25, 9); Console.WriteLine( "█░                                                                   ░█");
                Console.SetCursorPosition(25, 10); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 11); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 12); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 13); Console.WriteLine("█░              F1. Quản lý danh sách sản phẩm .                     ░█");
                Console.SetCursorPosition(25, 14); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 15); Console.WriteLine("█░              F2. Quản lý danh sách khách hàng.                    ░█");
                Console.SetCursorPosition(25, 16); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 17); Console.WriteLine("█░              F3. Quản lý danh sách nhân viên.                     ░█");
                Console.SetCursorPosition(25, 18); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 19); Console.WriteLine("█░              F4. Thoát.                                           ░█");
                Console.SetCursorPosition(25, 20); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 21); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 22); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 23); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(56, 8); Console.WriteLine("MENU");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        frmSanPham frm = new frmSanPham();
                        frm.Menu();
                        break;
                    case ConsoleKey.F2:
                        frmKhachHang frmkh = new frmKhachHang();
                        frmkh.Menu();
                        break;
                    case ConsoleKey.F3:
                        frmNhanVien frmnv = new frmNhanVien();
                        frmnv.Menu();
                        break;
                    case ConsoleKey.F4:
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
