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
            do
            {
                Console.Clear();
                Console.WriteLine(" F1.Quan ly san pham ");
                Console.WriteLine(" F2.Quan ly khach hang ");
                Console.WriteLine(" F3.Quan ly hoa don ");
                Console.WriteLine(" F4.Bao cao/Thong ke ");
                Console.WriteLine(" F5.Ket thuc ");
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
                    case ConsoleKey.F5:
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
