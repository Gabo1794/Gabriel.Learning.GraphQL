using Gabo.Learn.GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.Interfaces
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
        Product GetProductById(int id);
    }
}
