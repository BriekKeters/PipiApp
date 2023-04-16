using System;
using MediatR;
using PipiApp;
using PipiApp.Models;
using PipiApp.Repositories;
using PipiApp.Repositories.Base;

namespace PipiApp
{
    public static class IOCExtentions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
            });
            services.AddTransient<IRepository<Toilet>, Repository<Toilet>>();
            services.AddTransient<IRepository<Comment>, Repository<Comment>>();
            services.AddTransient<IRepository<Person>, Repository<Person>>();

            services.AddMediatR(System.Reflection.Assembly.GetAssembly(typeof(IOCExtentions)));
        }
    }
}

