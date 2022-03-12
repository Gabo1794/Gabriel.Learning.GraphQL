using Gabo.Learn.GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.DataAccess
{
    public class GraphQLDBContext : DbContext
    {
        public GraphQLDBContext(DbContextOptions<GraphQLDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
