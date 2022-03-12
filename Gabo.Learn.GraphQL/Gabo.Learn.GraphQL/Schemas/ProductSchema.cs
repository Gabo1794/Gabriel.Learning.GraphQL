using Gabo.Learn.GraphQL.Mutations;
using Gabo.Learn.GraphQL.Query;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
