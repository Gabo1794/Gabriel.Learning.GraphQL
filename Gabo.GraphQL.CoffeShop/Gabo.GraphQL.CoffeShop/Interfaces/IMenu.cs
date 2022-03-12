using Gabo.GraphQL.CoffeShop.Models;
using System.Collections.Generic;

namespace Gabo.GraphQL.CoffeShop.Interfaces
{
    public interface IMenu
    {
        List<Menu> GetMenus();
        Menu AddMenu(Menu newMenu);
    }
}
