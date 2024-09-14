using Core.Entities;
using Infraestructure.Repository;
using MediatR;


namespace Application.Entities.Generics.Command
{
    public class CreateEntityCommand<T>(T entidad) : IRequest<T> 
    {
        public T Entity = entidad;
    }

    public class CreateEntityHandler<T>(BaseRepositry<T> repositry) : IRequestHandler<CreateEntityCommand<T>, T> where T : BaseEntity
    {
        public async Task<T> Handle(CreateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var response = await repositry.Create(request.Entity);

            return response;
        }
    }
}
