using Microsoft.EntityFrameworkCore;
using ProductGallery.Domain.Commom;
using ProductGallery.Domain.Contracts;

namespace ProductGallery.SharedKernel
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext dbContext;

        protected RepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Add(entity);

            await SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Remove(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await dbContext.Set<T>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
        }

        public async Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            var query = specification.Includes
                .Aggregate(dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // Aplica Skip si esta en la especificación
            if (specification.Skip != null && specification.Skip != 0)
            {
                query = query.Skip(specification.Skip.Value);
            }

            // Aplica Take si esta en la especificación
            if (specification.Take != null)
            {
                query = query.Take(specification.Take.Value);
            }

            return await query.Where(specification.Criteria)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbContext.Set<T>().Update(entity);

            await SaveChangesAsync(cancellationToken);
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}