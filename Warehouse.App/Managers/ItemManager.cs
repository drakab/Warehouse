using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.App.Concrete;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Managers
{
    public class ItemManager
    {
        private readonly MenuActionService _actionService;
        private ItemService _itemService;
        public ItemManager(MenuActionService actionService)
        {
            _itemService = new ItemService();
            _actionService = actionService;
        }

        public int AddNewItem()
        {
            var addNewItemMenu = _actionService.GetMenuActionsByMenuName("CategoryItemMenu");
            Console.WriteLine("\r\nPlease select item type: ");
            foreach (var menuItem in addNewItemMenu)
            {
                Console.WriteLine($"{menuItem.Id}. {menuItem.Name}");
            }
            var operation = Console.ReadKey();
            int typeId;
            Int32.TryParse(operation.KeyChar.ToString(), out typeId);
            Console.WriteLine("Please insert name for item: ");
            var name = Console.ReadLine();
            var lastId = _itemService.GetLastId();
            var newId = lastId + 1;
            Item item = new Item(newId, name, typeId);
            _itemService.AddItem(item);
            return item.Id;
        }
        public int RemoveItem()
        {
            Console.WriteLine("\r\nPlease enter id of item to delete: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);

            var productToRemove = GetItemById(id);
            _itemService.RemoveItem(productToRemove);
            return productToRemove.Id;
        }
        public Item GetItemById(int id)
        {
            Item itemToReturn = new Item();
            foreach (var item in _itemService.GetAllItems())
            { 
                if (item.Id.Equals(id))
                {
                    itemToReturn = item;
                    break;
                }
            }
            return itemToReturn;
        }
        public Item ShowItem()
        {
            Console.WriteLine("\r\nPlease enter id of item to delete: ");
            var itemId = Console.ReadKey();
            int id;
            Int32.TryParse(itemId.KeyChar.ToString(), out id);
            var itemToShow = GetItemById(id);
            return itemToShow;
        }
    }
}
