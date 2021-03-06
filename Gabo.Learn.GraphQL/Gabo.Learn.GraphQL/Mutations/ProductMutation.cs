using Gabo.Learn.GraphQL.Interfaces;
using Gabo.Learn.GraphQL.Models;
using Gabo.Learn.GraphQL.Type;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct",
                 arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                 resolve: context =>
                 {
                     return productService.AddProduct(context.GetArgument<Product>("product"));
                 });

            Field<ProductType>("updateProduct",
                 arguments: new QueryArguments(
                     new QueryArgument<IntGraphType> { Name = "id" },
                     new QueryArgument<ProductInputType> { Name = "product" }
                     ),
                 resolve: context =>
                 {
                     Product product = context.GetArgument<Product>("product");
                     int productId = context.GetArgument<int>("id");
                     return productService.UpdateProduct(productId, product);
                 });

            Field<StringGraphType>("deleteProduct",
                 arguments: new QueryArguments(
                     new QueryArgument<IntGraphType> { Name = "id" }),
                 resolve: context =>
                 {
                     int productId = context.GetArgument<int>("id");
                     productService.DeleteProduct(productId);
                     return $"The product against the {productId} has been deleted";
                 });
        }
    }
}
