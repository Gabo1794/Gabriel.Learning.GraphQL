using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Query
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenu menuService)
        {
            Field<ListGraphType<MenuType>>("menu", resolve: context => { return menuService.GetMenus(); });
        }
    }
}
