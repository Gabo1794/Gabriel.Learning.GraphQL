using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Query
{
    //Esta clase es para poder enrutar los querys a utilizar en plataforma ya que graphQl de manera natural solo puede retonrar un query en el squema
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery", resolve: context => new { });
            Field<SubMenuQuery>("subMenuQuery", resolve: context => new { });
            Field<ReservationQuery>("reservationQuery", resolve: context => new { });
        }
    }
}
