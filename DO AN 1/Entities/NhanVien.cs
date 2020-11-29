using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN1.Entities
{
    public class NhanVien
    {
        #region Các thành phần dữ liệu
        private int manv;
        private string tennv;
        private string diachinv;
        private string sdtnv;
        private string gmail;
        private double hsl;
        private static int luongcb;
        #endregion
        #region Các thuộc tính
        public int MaNhanVien
        {
            get { return manv; }
            set
            {
                manv = value;
            }
        }
        public string TenNhanVien
        {
            get { return tennv; }
            set
            {
                tennv = value;
            }
        }
        public string DiaChiNV
        {
            get { return diachinv; }
            set
            {
                diachinv = value;
            }
        }
        public string SoDeinThoaiNV
        {
            get { return sdtnv; }
            set
            {
                sdtnv = value;
            }
        }
        public string Gmail
        {
            get { return gmail; }
            set
            {
                gmail = value;
            }
        }
        public double HeSoLuong
        {
            get { return hsl; }
            set
            {
                if (value > 0)
                    hsl = value;
            }
        }
        public static int LuongCoBan
        {
            get { return luongcb; }
            set
            {
                if (value >= 0)
                    luongcb = value;
            }
        }
        #endregion
        #region Các phương thức
        public NhanVien() { }
        public NhanVien(int manv, string tennv, string diachinv, string sdtnv, string gmail, double hsl, int luongcb)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.diachinv = diachinv;
            this.sdtnv = sdtnv;
            this.gmail = gmail;
            this.hsl = hsl;

        }
        public NhanVien(NhanVien nv)
        {
            this.manv = nv.manv;
            this.tennv = nv.tennv;
            this.diachinv = nv.diachinv;
            this.sdtnv = nv.sdtnv;
            this.gmail = nv.gmail;
            this.hsl = nv.hsl;

        }
        public NhanVien(int manv, string tennv, string diachinv, string sdtnv, string gmail, double hsl)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.diachinv = diachinv;
            this.sdtnv = sdtnv;
            this.gmail = gmail;
            this.hsl = hsl;
        }
        public double Luong()
        {
            return luongcb * hsl;
        }
        #endregion
    }
}
