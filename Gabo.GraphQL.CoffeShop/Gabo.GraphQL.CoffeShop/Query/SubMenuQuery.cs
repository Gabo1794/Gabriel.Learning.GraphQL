using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Query
{
    public class SubMenuQuery : ObjectGraphType
    {
        public SubMenuQuery(ISubMenu subMenuService)
        {
            Field<ListGraphType<SubMenuType>>("submenus", resolve: context => { return subMenuService.GetSubMenus(); });

            Field<SubMenuType>("submenuById",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id"}),
                resolve: context =>
                {
                    return subMenuService.GetSubMenus(context.GetArgument<int>("id"));
                });
        }
    }
}
