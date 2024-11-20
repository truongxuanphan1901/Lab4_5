using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class SanPhamServiceTest
    {
        static void Main(string[] args)
        {
        }
        [TestFixture]
        public class SanPhamServiceTests
        {

            private SanPhamService _service;

            [SetUp]
            public void Setup()
            {
                _service = new SanPhamService();
            }

            [Test]
            public void ThemSanPham_SoLuongTest1()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                _service.ThemSanPham(sanPham);

                Assert.That(_service.GetSanPhams().Count, Is.EqualTo(1));

            }

            [Test]
            public void ThemSanPham_SoLuongTest2()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 0);
                Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
            }

            [Test]
            public void ThemSanPham_SoLuongTest3()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 100);
                Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
            }

            [Test]
            public void ThemSanPham_SoLuongTest4()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", -5);
                Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sanPham));
            }

            [Test]
            public void ThemSanPham_MaSanPhamTest()
            {
                var sp1 = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                var sp2 = new SanPham("2", "SP01", "SanPham2", 1500, "Xanh", "L", 20);

                _service.ThemSanPham(sp1);

                Assert.Throws<ArgumentException>(() => _service.ThemSanPham(sp2));
            }
            [Test]
            public void SuaSanPham_MaSanPhamTest1()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                _service.ThemSanPham(sanPham);

                _service.SuaSanPham("1", "SP02");

                Assert.That(_service.GetSanPhams().Count, Is.EqualTo(1));

            }

            [Test]
            public void SuaSanPham_MaSanPhamTest2()
            {
                var sp1 = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                var sp2 = new SanPham("2", "SP02", "SanPham2", 1500, "Xanh", "L", 20);

                _service.ThemSanPham(sp1);
                _service.ThemSanPham(sp2);

                Assert.Throws<ArgumentException>(() => _service.SuaSanPham("1", "SP02"));
            }

            [Test]
            public void SuaSanPham_MaSanPhamTest3()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                _service.ThemSanPham(sanPham);

                Assert.Throws<ArgumentException>(() => _service.SuaSanPham("1", "INVALID01"));
            }

            [Test]
            public void SuaSanPham_IDTest()
            {
                var sanPham = new SanPham("1", "SP01", "SanPham1", 1000, "Do", "M", 10);
                _service.ThemSanPham(sanPham);

                Assert.Throws<ArgumentException>(() => _service.SuaSanPham("2", "SP03"));
            }

            [Test]
            public void SuaSanPham_IDTest1()
            {
                Assert.Throws<ArgumentException>(() => _service.SuaSanPham(null, "SP03"));
            }
        }
    }
}
