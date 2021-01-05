using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN1.Entities
{
     public class Sanpham
    {
        private string  masp, maloai, tensp;
        private int soluong, giaban;
        private string nhasx;
        public string Masp
        {
            get { return masp; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    masp = value;
            }
        }
        public string Maloai
        {
            get { return maloai; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    maloai = value;
            }
        }
        public string Tensp
        {
            get { return tensp; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tensp = value;
            }
        }
        public int Soluong
        {
            get { return soluong; }
            set
            {
                if (value > 0)
                    soluong = value;
            }
        }
        public int Giaban
        {
            get { return giaban; }
            set
            {
                if (value > 0)
                    giaban = value;
            }
        }
        public string Nhasx
        {
            get { return nhasx; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    nhasx = value;
            }
        }
        //Phương thức thiết lập 
        public Sanpham() { }
        public Sanpham(Sanpham sp)
        {
            this.masp = sp.masp;
            this.maloai = sp.maloai;
            this.tensp = sp.tensp;
            this.soluong = sp.soluong;
            this.giaban = sp.giaban;
            this.nhasx = sp.nhasx;
        }
        public Sanpham(string masp, string maloai, string tensp, int soluong, int giaban, string nhasx)
        {
            this.masp = masp;
            this.maloai = maloai;
            this.tensp = tensp;
            this.soluong = soluong;
            this.giaban = giaban;
            this.nhasx = nhasx;
        }
    }
}
