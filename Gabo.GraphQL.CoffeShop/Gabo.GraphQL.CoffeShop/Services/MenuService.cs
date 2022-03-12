using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.Learn.GraphQL.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Gabo.GraphQL.CoffeShop.Services
{
    public class MenuService : IMenu
    {

        private CoffeShopContext _context;
        public MenuService(CoffeShopContext context)
        {
            _context = context;
        }

        public Menu AddMenu(Menu newMenu)
        {
            _context.Menus.Add(newMenu);
            _context.SaveChanges();
            return newMenu;
        }

        public List<Menu> GetMenus()
        {
            return _context.Menus.ToList();
        }
    }
}
