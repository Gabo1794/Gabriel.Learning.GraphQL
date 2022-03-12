using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Mutations
{
    public class SubMenuMutation : ObjectGraphType
    {
        public SubMenuMutation(ISubMenu subMenuService)
        {
            Field<SubMenuType>("createSubMenu", 
                    arguments: new QueryArguments(new QueryArgument<SubMenuInputType> { Name = "subMenu"}),
                    resolve: context =>
                    {
                        return subMenuService.AddSubMenu(context.GetArgument<SubMenu>("subMenu"));
                    }
                );
        }
    }
}
