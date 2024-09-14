using Core.Entities;
using Infraestructure.Repository;
using MediatR;


namespace Application.Entities.Generics.Command
{
    public class UpdateEntityCommand<T>(T entidad) : IRequest<T>
    {
        public T Entity = entidad;
    }

    public class UpdateEntityHandler<T>(BaseRepositry<T> repositry) : IRequestHandler<UpdateEntityCommand<T>, T> where T : BaseEntity
    {
        public async Task<T> Handle(UpdateEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var response = await repositry.Update(request.Entity);

            return response;
        }
    }
}
