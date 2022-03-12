using System;

namespace Gabo.GraphQL.CoffeShop.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int TotalPeople { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }

    }
}
