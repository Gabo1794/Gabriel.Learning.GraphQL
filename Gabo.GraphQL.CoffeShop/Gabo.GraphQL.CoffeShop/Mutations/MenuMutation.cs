using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Mutations
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenu menuService)
        {
            Field<MenuType>("createMenu", 
                    arguments: new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu"}),
                    resolve: context =>
                    {
                        return menuService.AddMenu(context.GetArgument<Menu>("menu"));
                    }
                );
        }
    }
}
