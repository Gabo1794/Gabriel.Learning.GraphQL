using Gabo.GraphQL.CoffeShop.Models;
using System.Collections.Generic;

namespace Gabo.GraphQL.CoffeShop.Interfaces
{
    public interface ISubMenu
    {
        List<SubMenu> GetSubMenus();
        List<SubMenu> GetSubMenus(int menuId);
        SubMenu AddSubMenu(SubMenu newSubMenu);
        
    }
}
