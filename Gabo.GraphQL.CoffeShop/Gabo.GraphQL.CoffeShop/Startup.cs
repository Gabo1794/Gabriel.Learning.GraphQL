using Gabo.GraphQL.CoffeShop.Interfaces;
using Gabo.GraphQL.CoffeShop.Mutations;
using Gabo.GraphQL.CoffeShop.Query;
using Gabo.GraphQL.CoffeShop.Schemas;
using Gabo.GraphQL.CoffeShop.Services;
using Gabo.GraphQL.CoffeShop.Type;
using Gabo.Learn.GraphQL.DataAccess;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gabo.Learn.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddDbContext<CoffeShopContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))    
            );

            //Esto se llama injeccion de dependencias y es un patron de diseño
            services.AddTransient<IMenu, MenuService>();
            services.AddTransient<ISubMenu, SubMenuService>();
            services.AddTransient<IReservation, ReservationService>();
            //Configuración de GraphQL
            #region GraphQL Types
            services.AddTransient<MenuType>();
            services.AddTransient<SubMenuType>();
            services.AddTransient<ReservationType>();

            services.AddTransient<MenuInputType>();
            services.AddTransient<SubMenuInputType>();
            services.AddTransient<ReservationInputType>();
            #endregion
            #region GraphQL Querys
            services.AddTransient<MenuQuery>();
            services.AddTransient<SubMenuQuery>();
            services.AddTransient<ReservationQuery>();
            services.AddTransient<RootQuery>();
            #endregion
            #region GraphQL Mutations
            services.AddTransient<MenuMutation>();
            services.AddTransient<SubMenuMutation>();
            services.AddTransient<ReservationMutation>();
            services.AddTransient<RootMutation>();
            #endregion
            services.AddTransient<ISchema,RootSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CoffeShopContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Si no existe el squema se crea si existe no hace nada :)
            dbContext.Database.EnsureCreated();

            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}
