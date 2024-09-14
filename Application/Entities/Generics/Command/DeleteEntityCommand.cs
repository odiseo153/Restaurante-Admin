using Core.Entities;
using Infraestructure.Repository;
using MediatR;

namespace Application.Entities.Generics.Command
{
    public class DeleteEntityCommand<T>(Guid Id) : IRequest<bool>
    {
        public Guid Id = Id;
    }

    public class DeleteEntityHandler<T>(BaseRepositry<T> repositry) : IRequestHandler<DeleteEntityCommand<T>, bool> where T : BaseEntity
    {
        public async Task<bool> Handle(DeleteEntityCommand<T> request, CancellationToken cancellationToken)
        {
            var response = repositry.Delete(request.Id);

            return response;
        }
    }
}


