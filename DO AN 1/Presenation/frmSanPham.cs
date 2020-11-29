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
            Console.WriteLine("NHAP THONG TIN SAN PHAM");
            Sanpham sp = new Sanpham();
            Console.Write("Nhap ma san pham:"); sp.Masp = Console.ReadLine();
            Console.Write("Nhap ma loai:"); sp.Maloai = (Console.ReadLine());
            Console.Write("Nhap ten san pham :"); sp.Tensp = Console.ReadLine();
            Console.Write("Nhap so luong san pham:"); sp.Soluong = int.Parse(Console.ReadLine());
            Console.Write("Nhap gia ban san pham :"); sp.Giaban = int.Parse(Console.ReadLine());
            Console.Write("Nhap Nha san xuat :"); sp.Nhasx = Console.ReadLine();
            spBLL.ThemSanPham(sp);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN SAN PHAM");
            List<Sanpham> list = spBLL.GetAllSanPham();
            foreach (var sp in list)
                Console.WriteLine(sp.Masp + "\t" + sp.Maloai + "\t" + sp.Tensp  + "\t" + sp.Soluong + "\t" + sp.Giaban + "\t" + sp.Nhasx);
        }
        public void Sua()
        {
            Console.Clear();
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
                Console.Write("Nhap ten san pham moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) sp.Tensp = ten;
                Console.Write("Nhap ma loai san pham moi :");
                string loai = Console.ReadLine();
                if (!string.IsNullOrEmpty(loai)) sp.Maloai = loai;
                Console.Write("Gia so luong san pham moi:");
                int sl = int.Parse(Console.ReadLine());
                if (sl > 0) sp.Soluong = sl;
                Console.Write("Nhap gia ban san pham moi:");
                int giamoi = int.Parse(Console.ReadLine());
                if (giamoi>0) sp.Giaban  = giamoi;
                Console.Write("Nhap nha san xuat moi:");
                string nsx = Console.ReadLine();
                if (!string.IsNullOrEmpty(nsx)) sp.Nhasx = nsx;
                spBLL.SuaSanPham(sp);
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
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN SAN PHAM");
                Console.WriteLine(" F1.Nhap san pham ");
                Console.WriteLine(" F2.Sua san pham ");
                Console.WriteLine(" F3.Tim san pham ");
                Console.WriteLine(" F4.Hien danh sach ");
                Console.WriteLine(" F5.Xoa san pham ");
                Console.WriteLine(" F6.Back ");
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
                    case ConsoleKey.F6:
                        Program.Menu();
                        Console.ReadKey();
                        break;
                }
            } while (true);
        }
    }
}
