using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flipkart.Models
{
    public class Store
    {
        private List<Item> items = new List<Item>();

        public List<Item> GetAllItems()
        {
            return items;
        }

        public Item FindItem(int id)
        {
            return items.Find((ele) => ele.Id == id);
        }
        public bool InsertItem(Item item)
        {
            bool status = false;
            items.Add(item);
            status = true;
            return status;
        }

        public bool UpdateItem(int id, int quantity)
        {
            bool status = false;
            Item it = items.Find((theItem) => theItem.Id == id);
            it.Quantity = quantity;
            status = true;
            return status;
        }

        public bool DeleteItem(int id)
        {
            bool status = false;
            Item it = items.Find((theItem) => theItem.Id == id);
            items.Remove(it);
            status = true;
            return status;
        }

    }
}