using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.App.Common;
using Warehouse.Domain.Entity;

namespace Warehouse.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService() 
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> resoult = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    resoult.Add(menuAction);
                }
            }
            return resoult;
        }
        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add item", "Main"));
            AddItem(new MenuAction(2, "Remove item", "Main"));
            AddItem(new MenuAction(3, "Show details", "Main"));
            AddItem(new MenuAction(4, "List of items", "Main"));

            AddItem(new MenuAction(1, "Clothing", "CategoryItemMenu"));
            AddItem(new MenuAction(2, "Electronics", "CategoryItemMenu"));
            AddItem(new MenuAction(3, "Grocery", "CategoryItemMenu"));
        }
    }
}