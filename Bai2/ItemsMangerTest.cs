using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    internal class ItemsMangerTest
    {
        static void Main(string[] args)
        {
        }
        [TestFixture]
        public class ItemsManagerTest
        {
            private ItemsManger _itemManager;

            [SetUp]
            public void Setup()
            {
                _itemManager = new ItemsManger();
            }

            [Test]
            [TestCase(1, "ValidName", 1)]
            [TestCase(2, "AnotherName", 1)]
            public void AddItem_Test1(int id, string name, int expected)
            {
                var item = new Items(id, name);
                _itemManager.AddItem(item);
                Assert.That(_itemManager.Items.Count, Is.EqualTo(expected));
                Assert.That(_itemManager.Items[0].Name, Is.EqualTo(name));
            }




            [TestCase(1, "123456", "Tên không được chứa số.")]
            public void AddItem_Test2(int id, string name, string expected)
            {
                var item = new Items(id, name);
                var ex = Assert.Throws<ArgumentException>(() => _itemManager.AddItem(item));
                Assert.That(ex.Message, Is.EqualTo(expected));
            }


            [TestCase(1, "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Tên không qus 50 kí tự.")]
            public void AddItem_NameExceedsLength_ThrowsException(int id, string name, string expected)
            {
                var item = new Items(id, name);
                var ex = Assert.Throws<ArgumentException>(() => _itemManager.AddItem(item));
                Assert.That(ex.Message, Is.EqualTo(expected));
            }


            [TestCase(1, "Trường", "Trường Mới")]
            public void UpdateItem_Test1(int id, string oldName, string newName)
            {
                var item = new Items(id, oldName);
                _itemManager.AddItem(item);
                _itemManager.UpdateItem(id, newName);
                Assert.That(_itemManager.Items.Any(i => i.Id == id && i.Name == newName), Is.True);
            }


            [TestCase(1, "ValidName", "1234", "Tên không được chứa số.")]
            public void UpdateItem_Test2(int id, string oldName, string newName, string expectedMessage)
            {
                var item = new Items(id, oldName);
                _itemManager.AddItem(item);

                var ex = Assert.Throws<ArgumentException>(() => _itemManager.UpdateItem(id, newName));
                Assert.That(ex.Message, Is.EqualTo(expectedMessage));
            }




            [TestCase(1, "ValidName")]
            public void DeleteItem_Test1(int id, string name)
            {
                var item = new Items(id, name);
                _itemManager.AddItem(item);
                _itemManager.DeleteItem(id);
                Assert.That(_itemManager.Items, Is.Empty);
            }



            [TestCase(1)]
            [TestCase(2)]
            public void DeleteItem_Test2(int id)
            {
                Assert.DoesNotThrow(() => _itemManager.DeleteItem(id));
            }

        }
    }
}
