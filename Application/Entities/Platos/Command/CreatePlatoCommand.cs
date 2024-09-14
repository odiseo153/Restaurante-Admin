using Core.Entities;
using Infraestructure.Repository;
using MediatR;

namespace Application.Entities.PLatos.Command
{
    public class CreatePlatoCommand : IRequest<Plato>
    {
        public Guid? RestauranteId { get; set; }
        public string Imagen { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

    }

    public class CreatePlatosHandler(BaseRepositry<Plato> repositry) : IRequestHandler<CreatePlatoCommand, Plato>
    {
        public async Task<Plato> Handle(CreatePlatoCommand request, CancellationToken cancellationToken)
        {
           var plato  = MapperControl.mapper.Map<Plato>(request);
            var response = await repositry.Create(plato);

       
            return response;
        }
    }


}
