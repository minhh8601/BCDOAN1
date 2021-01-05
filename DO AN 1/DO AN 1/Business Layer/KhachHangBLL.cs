using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;
using DOAN1.DataAccessLayer;

namespace DOAN1.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại KHACHHANG BLL
    public class KhachHangBLL : IKhachHangBLL
    {
        private IKhachHangDAL khDA = new KhachHangDAL();
        //Thực thi các yêu cầu
        public List<Khachhang> GetAllKhachHang()
        {
            return khDA.GetAllKhachHang();
        }
        public void ThemKhachHang(Khachhang kh)
        {
            if (!string.IsNullOrEmpty(kh.MaKhach))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                khDA.ThemKhachHang(kh);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaKhachHang(string makhachhang)
        {
            int i;
            List<Khachhang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makhachhang) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaKhachHang(Khachhang kh, string makh)
        {
            int i;
            List<Khachhang> list = GetAllKhachHang();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaKhach == makh) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(kh);
                khDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai hs nay");
        }
        public List<Khachhang> TimKhachHang(Khachhang kh)
        {
            List<Khachhang> list = GetAllKhachHang();
            List<Khachhang> kq = new List<Khachhang>();
            if (string.IsNullOrEmpty(kh.MaKhach) &&
                string.IsNullOrEmpty(kh.Hoten) &&
                string.IsNullOrEmpty(kh.QueQuan) &&
                string.IsNullOrEmpty(kh.DiaChi) &&
                string.IsNullOrEmpty(kh.SodienThoai))
            {
                kq = list;
            }
            //Tim theo ho ten khach hang
            if (!string.IsNullOrEmpty(kh.Hoten))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].Hoten.IndexOf(kh.Hoten) >= 0)
                    {
                        kq.Add(new Khachhang(list[i]));
                    }
            }

            //Tim theo ma khach hang
            else if (kh.MaKhach != "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].MaKhach == kh.MaKhach)
                    {
                        kq.Add(new Khachhang(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}

