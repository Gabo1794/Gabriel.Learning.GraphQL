using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.GraphQL.CoffeShop.Type;
using GraphQL;
using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Mutations
{
    public class ReservationMutation : ObjectGraphType
    {
        public ReservationMutation(IReservation reservationService)
        {
            Field<ReservationType>("createReservation", 
                    arguments: new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation"}),
                    resolve: context =>
                    {
                        return reservationService.AddReservation(context.GetArgument<Reservation>("reservation"));
                    }
                );
        }
    }
}
