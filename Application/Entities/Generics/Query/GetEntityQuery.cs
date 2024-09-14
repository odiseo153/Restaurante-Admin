using Core.Entities;
using Infraestructure.Repository;
using MediatR;
using System.Linq.Expressions;

namespace Application.Entities.Generics.Query
{
    public class GetEntityQuery<T>(
        Expression<Func<T, bool>> Filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
        int? Page = null,
        int? PageSize = null,
        object Id = null
        ) : IRequest<IEnumerable<T>>
    {

        public Expression<Func<T, bool>> filter = Filter;
        public Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = OrderBy;
        public int? page = Page;
        public int? pageSize = PageSize;
        public object id = Id;

    }

    public class GetEntityHandler<T>(BaseRepositry<T> repositry) : IRequestHandler<GetEntityQuery<T>, IEnumerable<T>> where T : BaseEntity
    {
        public async Task<IEnumerable<T>> Handle(GetEntityQuery<T> request, CancellationToken cancellationToken)
        {
            var response = await repositry.GetAllAsync(
                request.filter
                ,request.orderBy,
                request.page,
                request.pageSize,
                request.id
                );

            return response;
        }
    }
}
