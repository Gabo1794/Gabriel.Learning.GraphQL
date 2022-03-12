using Gabo.Learn.GraphQL.Interfaces;
using Gabo.Learn.GraphQL.Type;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });
            
            Field<ProductType>("product", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => 
                { 
                    return productService.GetProductById(context.GetArgument<int>("id")); 
                });
        }
    }
}
