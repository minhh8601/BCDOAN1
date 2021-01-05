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
        private string manv;
        private string tennv;
        private string diachinv;
        private string sdtnv;
        private string gmail;
        private double hsl;
        private int luongcb;
        #endregion
        #region Các thuộc tính
        public string MaNhanVien
        {
            get { return manv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    manv = value;
            }
        }
        public string TenNhanVien
        {
            get { return tennv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    tennv = value;
            }
        }
        public string DiaChiNV
        {
            get { return diachinv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    diachinv = value;
            }
        }
        public string SoDienThoaiNV
        {
            get { return sdtnv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    sdtnv = value;
            }
        }
        public string Gmail
        {
            get { return gmail; }
            set
            {
                if (!string.IsNullOrEmpty(value))
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
        public int LuongCoBan
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
        public NhanVien(string manv, string tennv, string diachinv, string sdtnv, string gmail, double hsl, int luongcb)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.diachinv = diachinv;
            this.sdtnv = sdtnv;
            this.gmail = gmail;
            this.hsl = hsl;
            this.luongcb = luongcb;
        }
        public NhanVien(NhanVien nv)
        {
            this.manv = nv.manv;
            this.tennv = nv.tennv;
            this.diachinv = nv.diachinv;
            this.sdtnv = nv.sdtnv;
            this.gmail = nv.gmail;
            this.hsl = nv.hsl;
            this.luongcb = nv.luongcb;

        }
        #endregion
    }
}
