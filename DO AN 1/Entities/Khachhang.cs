using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN1.Entities
{
    public class Khachhang
    {
        #region Các thành phần dữ liệu
        private string makh;
        private string hoten;
        private string quequan;
        private string diachi;
        private string sdt;
        #endregion

        #region Các thuộc tính
        public string MaKhach
        {
            get { return makh; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    makh = value;
            }
        }
        public string Hoten
        {
            get { return hoten; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    hoten = value;
            }
        }
        public string QueQuan
        {
            get { return quequan; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    quequan = value;
            }
        }
        public string DiaChi
        {
            get { return diachi; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    diachi = value;
            }
        }
        public string SodienThoai
        {
            get { return sdt; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 10)
                    sdt = value;
            }
        }
        #endregion

        #region Các thương thức             
        public Khachhang() { }
        //Phương thức thiết lập sao chép
        public Khachhang(Khachhang kh)
        {
            this.makh = kh.makh;
            this.hoten = kh.hoten;
            this.quequan = kh.quequan;
            this.diachi = kh.diachi;
            this.sdt = kh.sdt;
        }
        public Khachhang(string makh, string hoten, string quequan, string diachi, string sdt)
        {
            this.makh = makh;
            this.hoten = hoten;
            this.quequan = quequan;
            this.diachi = diachi;
            this.sdt = sdt;
        }
    }
    #endregion
}