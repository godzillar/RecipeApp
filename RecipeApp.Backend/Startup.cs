using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecipeApp.Backend.Configurations;
using RecipeApp.Repository.Configurations;
using RecipeApp.Repository.Database;
using RecipeApp.Repository.Interfaces;
using RecipeApp.Repository.Respositories;
using RecipeApp.Service.Dispatchers;
using RecipeApp.Service.Interfaces.Dispatchers;
using RecipeApp.Service;

namespace RecipeApp.Backend
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
            // Enable Mapper
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<ApiMapperProfile>();
                cfg.AddProfile<RepositoryMapperProfile>();
            });
            var mapper = mapperConfig.CreateMapper();

            // Add Mapper DI
            services.AddSingleton(mapper);

            // Add Query/Command DI
            services.AddQueryHandlers();
            services.AddCommandHandlers();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            // Add repository DI
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            // Add database context
            var connectionString = Configuration.GetConnectionString("RecipeDbConnectionString");
            services.AddDbContext<RecipeListDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRecipeListDbContext>(provider => provider.GetService<RecipeListDbContext>());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
