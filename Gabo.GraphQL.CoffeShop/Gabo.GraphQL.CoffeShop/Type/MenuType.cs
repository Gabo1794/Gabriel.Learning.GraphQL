using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubMenu subMenuService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ImageUrl);
            Field<ListGraphType<SubMenuType>>("submenus", resolve: context => 
            { 
                return subMenuService.GetSubMenus(context.Source.Id); 
            });
        }
    }
}
