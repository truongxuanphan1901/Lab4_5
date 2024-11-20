using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    public class ItemsManger
    {
        private List<Items> items = new List<Items>();


        public IReadOnlyList<Items> Items => items.AsReadOnly();

        public void AddItem(Items item)
        {
            ValidateItemName(item.Name);
            items.Add(item);
        }

        public void UpdateItem(int id, string newName)
        {
            ValidateItemName(newName);
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Name = newName;
            }
        }

        public void DeleteItem(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }

        private void ValidateItemName(string name)
        {
            if (name.Any(char.IsDigit))
            {
                throw new ArgumentException("Tên không được chứa số.");
            }

            if (name.Length > 50)
            {
                throw new ArgumentException("Tên không quá 50 kí tự.");
            }
        }
    }
}
