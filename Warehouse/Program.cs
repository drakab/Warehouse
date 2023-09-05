using System;
using Warehouse.App.Abstract;
using Warehouse.App.Concrete;
using Warehouse.App.Managers;
using Warehouse.Domain.Entity;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            ItemManager itemManager = new ItemManager(actionService);

            Console.WriteLine("Welcome to warehouse app!");
            while (true)
            {
                Console.WriteLine("Please let me know what you want to do:");
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                foreach (var item in mainMenu)
                {
                    Console.WriteLine($"{item.Id}. {item.Name}");
                }

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var newId = itemManager.AddNewItem();
                        break;
                    case '2':
                        var removedId = itemManager.RemoveItem();
                        Console.WriteLine($"Item with id = {removedId} has been deleted.");
                        break;
                    case '3':
                        var item = itemManager.ShowItem();
                        //var detailId = itemService.ItemDetailSelectionView();
                        //itemService.ItemDetailView(detailId);
                        Console.WriteLine($"Item id: {item.Id} name: {item.Name} category: {item.TypeId}");
                        break;
                    case '4':
                        //var categoryId = itemService.CategoryDetailSelectionView();
                        //itemService.CategoryDetailView(categoryId);

                        Console.WriteLine("You choosen 4 :)");
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist.");
                        break;
                }
            }
            
        }
    }
}