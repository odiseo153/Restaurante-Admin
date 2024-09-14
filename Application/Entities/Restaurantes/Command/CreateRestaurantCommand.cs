using Core.Entities;
using Infraestructure.Repository;
using MediatR;

namespace Application.Entities.Restaurantes.Command
{
    public class CreateRestaurantCommand : IRequest<Restaurants>
    {
        public string Nombre { get; set; } = null!;

        public string? NumeroTelefono { get; set; }

        public string Correo { get; set; }
        public string clave { get; set; }

        public string? Imagen { get; set; }
        public string? Instagram { get; set; } = "no tiene";
        public string? Facebook { get; set; } = "no tiene";

    }

    public class CreateRestaurantHandler(BaseRepositry<Restaurants> repositry) : IRequestHandler<CreateRestaurantCommand, Restaurants>
    {
        public async Task<Restaurants> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant  = MapperControl.mapper.Map<Restaurants>(request);

            var response = await repositry.Create(restaurant);

       
            return response;
        }
    }


}
