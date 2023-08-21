using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class ItemService
    {
        public List<Item> Items { get; set; }
        public ItemService()
        {
            Items = new List<Item>();
        }

        public ConsoleKeyInfo AddNewItemView(MenuActionService actionService)
        {
            var mainMenu = actionService.GetMenuActionsByMenuName("CategoryItemMenu");
            Console.WriteLine("\r\nPlease select item type: ");
            foreach (var item in mainMenu)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            var operation = Console.ReadKey();
            return operation;
        }
        public int AddNewItem(char itemType)
        {
            int itemTypeId;
            Int32.TryParse(itemType.ToString(), out itemTypeId);
            Item newItem = new Item();
            newItem.TypeId = itemTypeId;
            Console.WriteLine("\r\nPlease enter id for new item: ");
            var id = Console.ReadLine();
            int itemId;
            Int32.TryParse(id, out itemId);
            Console.WriteLine("Please enter name for new item: ");
            var name = Console.ReadLine();

            newItem.Id = itemId;
            newItem.Name = name;

            Items.Add(newItem);

            return itemId;
        }
        public int RemoveItemView()
        {
            Console.WriteLine("\r\nPlease enter id of item to delete: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }
        public int RemoveItem(int removeId)
        {
            Item productToRemove = new Item();
            int removedId = 0;
            foreach (var item in Items)
            {
                if (item.Id == removeId)
                {
                    productToRemove = item;
                    removedId = item.Id;
                    break;
                }
            }
            Items.Remove(productToRemove);

            return removedId;
        }

        public void ItemDetailView(int detailId)
        {
            Item productToShow = new Item();
            foreach (var item in Items)
            {
                if (item.Id == detailId)
                {
                    productToShow = item;
                    break;
                }
            }
            Console.WriteLine($"\r\nItem id: {productToShow.Id}");
            Console.WriteLine($"Item name: {productToShow.Name}");
            Console.WriteLine($"Item type id: {productToShow.TypeId}");
        }

        public int ItemDetailSelectionView()
        {
            Console.WriteLine("\r\nPlease enter id of item to show: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }

        public void CategoryDetailView(int categoryId)
        {
            Item productToShow = new Item();
            foreach (var item in Items)
            {
                if (item.TypeId == categoryId)
                {
                    productToShow = item;
                    Console.WriteLine($"\r\nItem id: {productToShow.Id}, name: {productToShow.Name}, type id: {productToShow.TypeId}");
                }
            }
        }

        public int CategoryDetailSelectionView()
        {
            Console.WriteLine("\r\nPlease enter id of category to show: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            return id;
        }
    }
}
