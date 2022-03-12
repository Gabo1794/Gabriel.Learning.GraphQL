using GraphQL.Types;

namespace Gabo.GraphQL.CoffeShop.Type
{
    public class ReservationInputType : InputObjectGraphType
    {
        public ReservationInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("phone");
            Field<IntGraphType>("totalPeople");
            Field<StringGraphType>("email");
            Field<DateTimeGraphType>("date");
            Field<StringGraphType>("time");
        }
    }
}
