using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.BusinessLayer;
using DOAN1.Entities;
namespace DOAN1.Presenation
{
    public class frmSanPham
    {
        private ISanPhamBLL spBLL = new SanPhamBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHẬP THÔNG TIN SẢN PHẨM");
            Sanpham sp = new Sanpham();
            string nhapthem;
            do { 
                do
                {
                    Console.Write("Nhap ma san pham:"); sp.Masp = Console.ReadLine();
                } while (string.IsNullOrEmpty(sp.Masp));
                do {
                    Console.Write("Nhap ma loai:"); sp.Maloai = (Console.ReadLine());
                } while (string.IsNullOrEmpty(sp.Maloai));
                do {
                    Console.Write("Nhap ten san pham :"); sp.Tensp = Console.ReadLine();
                } while (string.IsNullOrEmpty(sp.Tensp));
                do {
                    Console.Write("Nhap so luong san pham:"); sp.Soluong = int.Parse(Console.ReadLine());
                } while (sp.Soluong<0);
                do {
                    Console.Write("Nhap gia ban san pham :"); sp.Giaban = int.Parse(Console.ReadLine());
                } while (sp.Giaban<10000);
                do {
                    Console.Write("Nhap Nha san xuat :"); sp.Nhasx = Console.ReadLine();
                } while (string.IsNullOrEmpty(sp.Nhasx));
                spBLL.ThemSanPham(sp);
                Console.Write("Bạn có muốn nhập tiếp không ?(Y or y để nhập tiếp,nhấn bất kì để thoát )");
                do
                {
                    nhapthem = Console.ReadLine();
                } while (nhapthem == "");
            } while (nhapthem == "Y" || nhapthem == "y");
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t║                                              DANH SÁCH SẢN PHẨM                                                ║");
            Console.WriteLine("\t\t╠═════════════╦═══════════════╦════════════════════════╦══════════════╦═════════════╦════════════════════════════╣");
            Console.WriteLine("\t\t║    Mã SP    ║    Mã Loại    ║      Tên Sản Phẩm      ║   Số Lượng   ║     Gía Bán ║    Nhà Sản Xuất            ║");                   
            Console.WriteLine("\t\t╠═════════════╬═══════════════╬════════════════════════╬══════════════╬═════════════╬════════════════════════════╣");
            List<Sanpham> list = spBLL.GetAllSanPham();
            foreach (var sp in list)
            Console.WriteLine("\t\t║    {0,-5}    ║   {1,-10}  ║   {2,-20} ║     {3,-5}    ║  {4,-10} ║ {5,-20}       ║", sp.Masp, sp.Maloai, sp.Tensp, sp.Soluong, sp.Giaban, sp.Nhasx);
            
            Console.WriteLine("\t\t╚═════════════╩═══════════════╩════════════════════════╩══════════════╩═════════════╩════════════════════════════╝");
           
        }
        public void Sua()
        {
            Hien();
            Console.WriteLine("SUA THONG TIN SAN PHAM");
            List<Sanpham> list = spBLL.GetAllSanPham();
            string masanpham;
            Console.Write("Nhap ma san pham can sua:");
            masanpham = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == masanpham) break;

            if (i < list.Count)
            {
                Sanpham sp = new Sanpham(list[i]);
                Console.Write("Nhap ma san pham moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) sp.Masp = ma;
                Console.Write("Nhap ma loai san pham moi :");
                string loai = Console.ReadLine();
                if (!string.IsNullOrEmpty(loai)) sp.Maloai = loai;
                Console.Write("Nhap ten san pham moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) sp.Tensp = ten;
                Console.Write("Gia so luong san pham moi:");
                int sl = int.Parse(Console.ReadLine());
                if (sl > 0) sp.Soluong = sl;
                Console.Write("Nhap gia ban san pham moi:");
                int giamoi = int.Parse(Console.ReadLine());
                if (giamoi > 0) sp.Giaban = giamoi;
                Console.Write("Nhap nha san xuat moi:");
                string nsx = Console.ReadLine();
                if (!string.IsNullOrEmpty(nsx)) sp.Nhasx = nsx;
                spBLL.SuaSanPham(sp,masanpham);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma san pham nay");
            }
        }

        public void Tim()
        {
            Console.Clear();
            ISanPhamBLL Sanpham = new SanPhamBLL();
            List<Sanpham> list = Sanpham.TimSanPham(new Sanpham());
            string masanpham1;
            Console.Write("Nhap ma san pham can tim:");
            masanpham1 = Console.ReadLine();
            for (int i = 0; i < list.Count; ++i)
            {
                if (masanpham1 == list[i].Masp)
                    Console.WriteLine(list[i].Masp + "\t" + list[i].Tensp + "\t" + list[i].Maloai + "\t" + list[i].Soluong + "\t" + list[i].Giaban + "\t" + list[i].Nhasx);
            }
        }
        public void Xoa()
        {
            Console.Clear();
            Console.WriteLine("XOA THONG TIN NHAN VIEN");
            List<Sanpham> list = spBLL.GetAllSanPham();
            string masanpham;
            Console.Write("Nhap ma san pham can xoa:");
            masanpham = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].Masp == masanpham) break;

            if (i < list.Count)
            {
                list.RemoveAt(i);
                spBLL.XoaSanPham(masanpham);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma san pham nay");
            }
        }
        public void Menu()
        {
            do
            {
                
                Console.SetCursorPosition(47, 1); Console.WriteLine("QUAN LY SAN PHAM");
                Console.SetCursorPosition(25, 6); Console.WriteLine( "███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 7); Console.WriteLine( "█░                                                                   ░█");
                Console.SetCursorPosition(25, 8); Console.WriteLine( "█░                                                                   ░█");
                Console.SetCursorPosition(25, 9); Console.WriteLine( "█░                                                                   ░█");
                Console.SetCursorPosition(25, 10); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(25, 11); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 12); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 13); Console.WriteLine("█░              F1. Nhap thong tin san pham.                         ░█");
                Console.SetCursorPosition(25, 14); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 15); Console.WriteLine("█░              F2. Sua thong tin san pham.                          ░█");
                Console.SetCursorPosition(25, 16); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 17); Console.WriteLine("█░              F3. Tim kiem thong tin san pham.                     ░█");
                Console.SetCursorPosition(25, 18); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 19); Console.WriteLine("█░              F4. Hien thi danh sach san pham.                     ░█");
                Console.SetCursorPosition(25, 20); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 21); Console.WriteLine("█░              F5. Xoa thong tin san pham.                          ░█");
                Console.SetCursorPosition(25, 22); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 23); Console.WriteLine("█░              F6. Thoat.                                           ░█");
                Console.SetCursorPosition(25, 24); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 25); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 26); Console.WriteLine("█░                                                                   ░█");
                Console.SetCursorPosition(25, 27); Console.WriteLine("███████████████████████████████████████████████████████████████████████");
                Console.SetCursorPosition(50, 8); Console.WriteLine("MENU QUAN LY SAN PHAM");
                ConsoleKeyInfo kt = Console.ReadKey();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        Nhap();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        Sua();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F3:
                        Tim();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        Xoa();
                        Hien();
                        Console.WriteLine("Nhap phim bat ky de tiep tuc...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        Program.Menu();
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
