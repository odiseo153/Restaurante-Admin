using Core.Entities;
using Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infraestructure.Repository
{
    public class BaseRepositry<T>(ApplicationContext context) where T : BaseEntity
    {
        public async Task<T> Create(T Entity)
        {
            await context.Set<T>().AddAsync(Entity);
            await context.SaveChangesAsync();

            return Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        int? page = null,
        int? pageSize = null,
        object id = null
        )
        {
            try
            {
                var _dbSet = context.Set<T>();
                IQueryable<T> query = _dbSet;

                // Obtener por ID si se proporciona
                if (id != null)
                {
                    var entity = await _dbSet.FindAsync(id);
                    return entity != null ? new List<T> { entity } : new List<T>();
                }

                // Aplicar filtro
                if (filter != null)
                {
                    query = query.Where(filter);
                }


                // Aplicar ordenación
                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                // Aplicar paginación si está presente
                if (page.HasValue && pageSize.HasValue)
                {
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
                }

                return await query.ToListAsync();
            }
            catch( Exception ex )
            {

                Console.WriteLine(ex.Message);
                return null;

            }
        }


        public bool Delete(Guid Id)
        {
            var entity = context.Set<T>().Find(Id);

            if (entity == null)
            {
                return false;
            }

            context.Remove(entity);
            context.SaveChanges();

            return true;
        }



        public async Task<T> Update(T entidad)
        {
            var entida = await context.Set<T>().FindAsync(entidad.Id);

            foreach (var propiedad in entidad.GetType().GetProperties())
            {
                var valorEntidad = propiedad.GetValue(entidad);
                var valorFinal = valorEntidad ?? propiedad.GetValue(entida);

                propiedad.SetValue(entida, valorFinal);
            }

            await context.SaveChangesAsync();

            return entida;
        }

    }
}






