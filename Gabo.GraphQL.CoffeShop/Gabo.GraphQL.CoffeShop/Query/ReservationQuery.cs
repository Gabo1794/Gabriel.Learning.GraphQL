using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Query
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservation reservationService)
        {
            Field<ListGraphType<ReservationType>>("reservations", resolve: context => { return reservationService.GetReservations(); });
        }
    }
}
