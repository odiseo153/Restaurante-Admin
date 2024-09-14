using Application.Entities.Generics.Command;
using Application.Entities.Generics.Query;
using Application.Entities.PLatos.Command;
using Application.Entities.Restaurantes.Command;
using Core.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Infraestructure
{
    public static class ServiceRegistation
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<CreateRestaurantCommand, Restaurants>, CreateRestaurantHandler>();
            services.AddScoped<IRequestHandler<CreatePlatoCommand, Plato>, CreatePlatosHandler>();


            services.AddScoped<IRequestHandler<GetEntityQuery<Plato>, IEnumerable<Plato>>, GetEntityHandler<Plato>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Cliente>, IEnumerable<Cliente>>, GetEntityHandler<Cliente>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<TiposPlato>, IEnumerable<TiposPlato>>, GetEntityHandler<TiposPlato>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Restaurants>, IEnumerable<Restaurants>>, GetEntityHandler<Restaurants>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Pedido>, IEnumerable<Pedido>>, GetEntityHandler<Pedido>>();
            services.AddScoped<IRequestHandler<GetEntityQuery<Social>, IEnumerable<Social>>, GetEntityHandler<Social>>();


            services.AddScoped<IRequestHandler<CreateEntityCommand<Plato>, Plato>, CreateEntityHandler<Plato>>();
            services.AddScoped<IRequestHandler<CreateEntityCommand<Cliente>, Cliente>, CreateEntityHandler<Cliente>>();
            services.AddScoped<IRequestHandler<CreateEntityCommand<TiposPlato>, TiposPlato>, CreateEntityHandler<TiposPlato>>();
            services.AddScoped<IRequestHandler<CreateEntityCommand<Restaurants>, Restaurants>, CreateEntityHandler<Restaurants>>();
            services.AddScoped<IRequestHandler<CreateEntityCommand<Pedido>, Pedido>, CreateEntityHandler<Pedido>>();
            services.AddScoped<IRequestHandler<CreateEntityCommand<Social>, Social>, CreateEntityHandler<Social>>();


            services.AddScoped<IRequestHandler<UpdateEntityCommand<Plato>, Plato>, UpdateEntityHandler<Plato>>();
            services.AddScoped<IRequestHandler<UpdateEntityCommand<Cliente>, Cliente>, UpdateEntityHandler<Cliente>>();
            services.AddScoped<IRequestHandler<UpdateEntityCommand<TiposPlato>, TiposPlato>, UpdateEntityHandler<TiposPlato>>();
            services.AddScoped<IRequestHandler<UpdateEntityCommand<Restaurants>, Restaurants>, UpdateEntityHandler<Restaurants>>();
            services.AddScoped<IRequestHandler<UpdateEntityCommand<Pedido>, Pedido>, UpdateEntityHandler<Pedido>>();
            services.AddScoped<IRequestHandler<UpdateEntityCommand<Social>, Social>, UpdateEntityHandler<Social>>();


            services.AddScoped<IRequestHandler<DeleteEntityCommand<Plato>, bool>, DeleteEntityHandler<Plato>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Cliente>, bool>, DeleteEntityHandler<Cliente>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<TiposPlato>, bool>, DeleteEntityHandler<TiposPlato>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Restaurants>, bool>, DeleteEntityHandler<Restaurants>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Pedido>, bool>, DeleteEntityHandler<Pedido>>();
            services.AddScoped<IRequestHandler<DeleteEntityCommand<Social>, bool>, DeleteEntityHandler<Social>>();


            // services.AddScoped<IRequestHandler<GetEntityQuery<Plato>, IEnumerable<Plato>>, GetEntityHandler<Plato>>();

        }

    }

}
