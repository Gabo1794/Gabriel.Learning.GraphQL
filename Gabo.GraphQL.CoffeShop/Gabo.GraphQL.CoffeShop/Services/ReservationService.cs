using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Models;
using Gabo.Learn.GraphQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gabo.GraphQL.CoffeShop.Services
{
    public class ReservationService : IReservation
    {
        private CoffeShopContext _context;
        public ReservationService(CoffeShopContext context)
        {
            _context = context;
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            _context.Reservations.Add(newReservation);
            _context.SaveChanges();
            return newReservation;
        }

        public List<Reservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }
    }
}
