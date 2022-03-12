using Gabo.Learn.GraphQL.DataAccess;
using Gabo.Learn.GraphQL.Interfaces;
using Gabo.Learn.GraphQL.Mutations;
using Gabo.Learn.GraphQL.Query;
using Gabo.Learn.GraphQL.Schemas;
using Gabo.Learn.GraphQL.Services;
using Gabo.Learn.GraphQL.Type;
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

            services.AddDbContext<GraphQLDBContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))    
            );

            //Esto se llama injeccion de dependencias y es un patron de diseño
            services.AddTransient<IProduct, ProductService>();
            //Configuración de GraphQL
            services.AddTransient<ProductType>();
            services.AddTransient<ProductQuery>();
            services.AddTransient<ProductMutation>();
            services.AddTransient<ISchema,ProductSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDBContext dbContext)
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
