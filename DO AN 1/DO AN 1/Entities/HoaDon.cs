using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DOAN1.Entities
{
    public class HoaDon
    {
        #region Các thành phần dữ liệu
        private string mahoadon;
        private string manhanvienban;
        private string masanpham;
        private int soluong;
        private string ngaynhap;
        #endregion

        #region Các thuộc tính
        public string MaHoaDon
        {
            get { return mahoadon; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    mahoadon = value;
            }
        }
        public string Manhanvienban
        {
            get { return manhanvienban; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    manhanvienban = value;
            }
        }
        public string Masanpham
        {
            get { return masanpham; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    masanpham = value;
            }
        }
        public int Soluong
        {
            get { return soluong; }
            set
            {
                if (soluong>0)
                    soluong = value;
            }
        }
        public string NgayNhap
        {
            get { return NgayNhap; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    NgayNhap = value;
            }
        }
        #endregion

        #region Các thương thức             
        public HoaDon() { }
        //Phương thức thiết lập sao chép
        public HoaDon(HoaDon hd)
        {
            this.mahoadon = hd.mahoadon;
            this.manhanvienban = hd.manhanvienban;
            this.masanpham = hd.manhanvienban;
            this.soluong = hd.soluong;
            this.ngaynhap = hd.ngaynhap;
        }
        public HoaDon(string mahoadon, string manhanvienban,string masanpham, int soluong, string ngaynhap)
        {
            this.mahoadon = mahoadon;
            this.manhanvienban = manhanvienban;
            this.masanpham = manhanvienban;
            this.soluong = soluong;
            this.ngaynhap = ngaynhap;
        }
    }
        #endregion
}