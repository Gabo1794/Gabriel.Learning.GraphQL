using Gabo.GraphQL.CoffeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL.DataAccess
{
    public class CoffeShopContext : DbContext
    {
        public CoffeShopContext(DbContextOptions<CoffeShopContext> options) : base(options) { }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
