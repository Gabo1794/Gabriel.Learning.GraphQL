using Gabo.Learn.GraphQL.DataAccess;
using Gabo.Learn.GraphQL.Interfaces;
using Gabo.Learn.GraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.Services
{
    public class ProductService : IProduct
    {

        private GraphQLDBContext _dbcontext;

        public ProductService(GraphQLDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Product AddProduct(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            Product product = _dbcontext.Products.Find(id);
            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbcontext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbcontext.Products.Find(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            Product prod = _dbcontext.Products.Find(id);
            prod.Name = product.Name;
            prod.Price = product.Price;
            _dbcontext.SaveChanges();
            return product;
        }
    }
}
