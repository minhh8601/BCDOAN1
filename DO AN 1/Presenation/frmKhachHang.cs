using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.BusinessLayer;
using DOAN1.Entities;
namespace DOAN1.Presenation
{
    class frmKhachHang
    {
        private IKhachHangBLL khBLL = new KhachHangBLL();
        public void Nhap()
        {
            Console.Clear();
            Console.WriteLine("NHAP THONG TIN KHACH HANG");
            Khachhang kh = new Khachhang();
            Console.Write("Nhap ma khach hang:"); kh.MaKhach = Console.ReadLine();
            Console.Write("Nhap ten khach hang:"); kh.Hoten = (Console.ReadLine());
            Console.Write("Nhap que quan khac hang :"); kh.QueQuan = Console.ReadLine();
            Console.Write("Nhap dia chi khach hang:"); kh.DiaChi = Console.ReadLine();
            Console.Write("Nhap so dien thoai :"); kh.SodienThoai = Console.ReadLine();
            khBLL.ThemKhachHang(kh);
        }
        public void Hien()
        {
            Console.Clear();
            Console.WriteLine("HIEN THI THONG TIN SAN PHAM");
            List<Khachhang> list = khBLL.GetAllKhachHang();
            foreach (var kh in list)
                Console.WriteLine(kh.MaKhach + "\t" + kh.Hoten + "\t" + kh.QueQuan + "\t" + kh.DiaChi + "\t" + kh.SodienThoai);
        }
        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("SUA THONG TIN KHACH HANG");
            List<Khachhang> list = khBLL.GetAllKhachHang();
            string makhachhang;
            Console.Write("Nhap ma khach hang can sua:");
            makhachhang = Console.ReadLine();
            int i = 0;
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang) break;

            if (i < list.Count)
            {
                Khachhang kh = new Khachhang(list[i]);
                Console.Write("Nhap ma khach hang moi:");
                string ma = Console.ReadLine();
                if (!string.IsNullOrEmpty(ma)) kh.MaKhach = ma;
                Console.Write("Nhap ho ten khach hang moi:");
                string ten = Console.ReadLine();
                if (!string.IsNullOrEmpty(ten)) kh.MaKhach = ten;
                Console.Write("Nhap que quan moi :");
                string que = Console.ReadLine();
                if (!string.IsNullOrEmpty(que)) kh.QueQuan = que;
                Console.Write("Nhap dia chi moi:");
                string dc = Console.ReadLine();
                if (!string.IsNullOrEmpty(dc)) kh.DiaChi = dc;
                Console.Write("Nhap so dien thoai moi:");
                string sdt = Console.ReadLine();
                if (!string.IsNullOrEmpty(sdt)) kh.SodienThoai = sdt;
                khBLL.SuaKhachHang(kh);
            }
            else
            {
                Console.WriteLine("Khong ton tai ma khach hang nay");
            }
        }
        public void Tim()
        {
            Console.Clear();
            IKhachHangBLL Khachhang = new KhachHangBLL();
            List<Khachhang> list = Khachhang.TimKhachHang(new Khachhang());
            string makhach;
            Console.Write("Nhap ma khach hang can tim:");
            makhach = Console.ReadLine();
            for(int i = 0; i < list.Count; ++i)
            {
                if(makhach== list[i].MaKhach )
                    Console.WriteLine(list[i].MaKhach + "\t" + list[i].Hoten + "\t" + list[i].QueQuan + "\t" + list[i].DiaChi + "\t" + list[i].SodienThoai);
            }
        }
        public void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("QUAN LY THONG TIN KHACH HANG");
                Console.WriteLine(" F1.Nhap thong tin khach hang ");
                Console.WriteLine(" F2.Sua thong tin khach hang ");
                Console.WriteLine(" F3.Tim thong tin khach hang ");
                Console.WriteLine(" F4.Hien danh sach khach hang ");
                Console.WriteLine(" F5.Xoa thong tin khach hang ");
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
