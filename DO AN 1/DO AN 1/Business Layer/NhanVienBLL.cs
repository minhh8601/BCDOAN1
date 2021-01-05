using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN1.Entities;
using DOAN1.DataAccessLayer;

namespace DOAN1.BusinessLayer
{
    //Thực thi các yêu cầu nghiệm vụ của bài toán đã được quy định tại NhanVien BLL
    public class NhanVienBLL : INhanVienBLL
    {
        private INhanVienDAL nvDA = new NhanVienDAL();
        //Thực thi các yêu cầu
        public List<NhanVien> GetAllNhanVien()
        {
            return nvDA.GetAllNhanVien();
        }
        public void ThemNhanVien(NhanVien nv)
        {
            if (!string.IsNullOrEmpty(nv.MaNhanVien))
            {
                //Tiến hành chuẩn hóa dữ liệu nếu cần
                nvDA.ThemNhanVien(nv);
            }
            else
                throw new Exception("Du lieu sai");
        }

        public void XoaNhanVien(string manhanvien)
        {
            int i;
            List<NhanVien> list = GetAllNhanVien();
            for (i = 0; i < list.Count; ++i)
                if (list[i].MaNhanVien == manhanvien) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                nvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai ma nay");
        }
        public void SuaNhanVien(NhanVien nv, string manhanvien)
        {
            int i;
            List<NhanVien> list = GetAllNhanVien();
            for (i = 0; i < list.Count; i++)
                if (list[i].MaNhanVien == manhanvien) break;
            if (i < list.Count)
            {
                list.RemoveAt(i);
                list.Add(nv);
                nvDA.Update(list);
            }
            else
                throw new Exception("Khong ton tai san pham nay");
        }
        public List<NhanVien> TimNhanVien(NhanVien nv)
        {
            List<NhanVien> list = GetAllNhanVien();
            List<NhanVien> kq = new List<NhanVien>();
            if (string.IsNullOrEmpty(nv.MaNhanVien) &&
                string.IsNullOrEmpty(nv.TenNhanVien) &&
                string.IsNullOrEmpty(nv.DiaChiNV) &&
                string.IsNullOrEmpty(nv.SoDienThoaiNV) &&
                string.IsNullOrEmpty(nv.Gmail) &&
                nv.HeSoLuong == 0 &&
                nv.LuongCoBan == 0)

            {
                kq = list;
            }
            //Tim theo ho ten nhan vien
            if (!string.IsNullOrEmpty(nv.TenNhanVien))
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].TenNhanVien.IndexOf(nv.TenNhanVien) >= 0)
                    {
                        kq.Add(new NhanVien(list[i]));
                    }
            }

            //Tim theo ma nhan vien
            else if (nv.MaNhanVien != "")
            {
                for (int i = 0; i < list.Count; ++i)
                    if (list[i].MaNhanVien == nv.MaNhanVien)
                    {
                        kq.Add(new NhanVien(list[i]));
                    }
            }
            else kq = null;
            return kq;
        }
    }
}

