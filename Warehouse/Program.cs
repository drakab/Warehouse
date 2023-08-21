using System;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            ItemService itemService = new ItemService();

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
                        var keyInfo = itemService.AddNewItemView(actionService);
                        var id = itemService.AddNewItem(keyInfo.KeyChar);
                        break;
                    case '2':
                        var idToRemove = itemService.RemoveItemView();
                        var idRemoved = itemService.RemoveItem(idToRemove);
                        Console.WriteLine($"Item with id = {idRemoved} has been deleted.");
                        break;
                    case '3':
                        var detailId = itemService.ItemDetailSelectionView();
                        itemService.ItemDetailView(detailId);
                        break;
                    case '4':
                        var categoryId = itemService.CategoryDetailSelectionView();
                        itemService.CategoryDetailView(categoryId);
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist.");
                        break;
                }
            }
            
        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add item", "Main");
            actionService.AddNewAction(2, "Remove item", "Main");
            actionService.AddNewAction(3, "Show details", "Main");
            actionService.AddNewAction(4, "List of items", "Main");

            actionService.AddNewAction(1, "Clothing", "CategoryItemMenu");
            actionService.AddNewAction(2, "Electronics", "CategoryItemMenu");
            actionService.AddNewAction(3, "Grocery", "CategoryItemMenu");

            return actionService;
        }
    }
}