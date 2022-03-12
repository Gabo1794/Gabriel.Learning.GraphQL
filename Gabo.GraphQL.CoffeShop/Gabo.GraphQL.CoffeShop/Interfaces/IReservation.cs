using Gabo.GraphQL.CoffeShop.Models;
using System.Collections.Generic;

namespace Gabo.GraphQL.CoffeShop.Interfaces
{
    public interface IReservation
    {
        List<Reservation> GetReservations();
        Reservation AddReservation(Reservation newReservation);
    }
}
