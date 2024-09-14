
using Core.Entities;
using Infraestructure.Context;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class ServiceRegistration
    {
        public static void AddApplicationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<BaseRepositry<Restaurants>>();
            services.AddScoped<BaseRepositry<Plato>>();
            services.AddScoped<BaseRepositry<Pedido>>();
            services.AddScoped<BaseRepositry<TiposPlato>>();
            services.AddScoped<BaseRepositry<Cliente>>();
            services.AddScoped<BaseRepositry<Social>>();
        }
    }
}