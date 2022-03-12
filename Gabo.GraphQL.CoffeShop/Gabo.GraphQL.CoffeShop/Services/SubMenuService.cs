using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.Learn.GraphQL.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Gabo.GraphQL.CoffeShop.Services
{
    public class SubMenuService : ISubMenu
    {
        private CoffeShopContext _context;
        public SubMenuService(CoffeShopContext context)
        {
            _context = context;
        }
        public SubMenu AddSubMenu(SubMenu newSubMenu)
        {
            _context.SubMenus.Add(newSubMenu);
            _context.SaveChanges();
            return newSubMenu;
        }

        public List<SubMenu> GetSubMenus()
        {
            return _context.SubMenus.ToList();
        }

        public List<SubMenu> GetSubMenus(int menuId)
        {
            return _context.SubMenus.Where(subMenu => subMenu.MenuId == menuId).ToList();
        }
    }
}
