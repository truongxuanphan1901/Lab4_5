using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class SanPhamService
    {
        private readonly List<SanPham> sanPhams = new List<SanPham>();


        public void ThemSanPham(SanPham sanPham)
        {
            if (sanPham.SoLuong <= 0 || sanPham.SoLuong >= 100)
            {
                throw new ArgumentException("Số lượng phải là số nguyên dương và nhỏ hơn 100.");
            }

            if (sanPhams.Any(sp => sp.MaSanPham == sanPham.MaSanPham))
            {
                throw new ArgumentException("Mã sản phẩm đã tồn tại.");
            }

            sanPhams.Add(sanPham);
        }


        public void SuaSanPham(string id, string newMaSanPham)
        {
            if (!newMaSanPham.StartsWith("SP"))
            {
                throw new ArgumentException("Mã sản phẩm phải bắt đầu bằng 'SP'.");
            }

            if (sanPhams.Any(sp => sp.MaSanPham == newMaSanPham))
            {
                throw new ArgumentException("Mã sản phẩm phải là duy nhất.");
            }

            var sanPham = sanPhams.FirstOrDefault(sp => sp.Id == id);
            if (sanPham == null)
            {
                throw new ArgumentException("Sản phẩm không tồn tại.");
            }

            sanPham.MaSanPham = newMaSanPham;
        }


        public void XoaSanPham(string id)
        {
            sanPhams.RemoveAll(sp => sp.Id == id);
        }

        public List<SanPham> GetSanPhams()
        {
            return sanPhams;
        }
    }
}
