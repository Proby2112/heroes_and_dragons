using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HeroesAndDragons.Core.Entities;
using HeroesAndDragons.Core.Interfaces.Repositories;
using HeroesAndDragons.Core.Interfaces.Services;
using HeroesAndDragons.DL;
using HeroesAndDragons.DL.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HeroesAndDragons.BL.Services;
using HeroesAndDragons.DL.Repositories;
using HeroesAndDragons.Core.Interfaces;
using HeroesAndDragons.Mapper;

namespace HeroesAndDragons
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
            // Set connection to database.
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalDbConnection"));
            });

            // Adds and configures the identity system for the specified User and Role types.
            services.AddIdentity<HeroEntity, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Add authentication services.
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = JwtTokenService.ISSUER,
            //            ValidAudience = JwtTokenService.AUDIENCE,
            //            IssuerSigningKey = JwtTokenService.GetSymmetricSecurityKey(),
            //        };
            //    });

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #region Dependency registration.

            // Repositories
            services.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddTransient<IDragonRepository, DragonRepository>();
            services.AddTransient<IHeroRepository, HeroRepository>();
            services.AddTransient<IHitRepository, HitRepository>();

            // Services
            services.AddTransient<IDragonService, DragonService>();
            services.AddTransient<IHeroService, HeroService>();
            services.AddTransient<IHitService, HitService>();


            // Other services
            services.AddSingleton<IDataAdapter, DataAdapter>();
            //services.AddTransient(typeof(JwtTokenService));

            #endregion


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enabling middleware to use Authentication services.
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
