using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.App.Common;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Concrete
{
    public class ItemService : BaseService<Item>
    {
        public ItemService() 
        {   
            ItemInitialiize();
        }

        private void ItemInitialiize()
        {
            AddItem(new Item((GetLastId() + 1), "T-shirt", 1));
            AddItem(new Item((GetLastId() + 1), "Dress", 1));
            AddItem(new Item((GetLastId() + 1), "Hat", 1));
        }
        //    public void ItemDetailView(int detailId)
        //    {
        //        Item productToShow = new Item();
        //        foreach (var item in Items)
        //        {
        //            if (item.Id == detailId)
        //            {
        //                productToShow = item;
        //                break;
        //            }
        //        }
        //        Console.WriteLine($"\r\nItem id: {productToShow.Id}");
        //        Console.WriteLine($"Item name: {productToShow.Name}");
        //        Console.WriteLine($"Item type id: {productToShow.TypeId}");
        //    }

        //    public int ItemDetailSelectionView()
        //    {
        //        Console.WriteLine("\r\nPlease enter id of item to show: ");
        //        var itemId = Console.ReadKey();
        //        int id;
        //        Int32.TryParse(itemId.KeyChar.ToString(), out id);

        //        return id;
        //    }

        //    public void CategoryDetailView(int categoryId)
        //    {
        //        Item productToShow = new Item();
        //        foreach (var item in Items)
        //        {
        //            if (item.TypeId == categoryId)
        //            {
        //                productToShow = item;
        //                Console.WriteLine($"\r\nItem id: {productToShow.Id}, name: {productToShow.Name}, type id: {productToShow.TypeId}");
        //            }
        //        }
        //    }

        //    public int CategoryDetailSelectionView()
        //    {
        //        Console.WriteLine("\r\nPlease enter id of category to show: ");
        //        var itemId = Console.ReadKey();
        //        int id;
        //        Int32.TryParse(itemId.KeyChar.ToString(), out id);

        //        return id;
        //    }
    }
}
