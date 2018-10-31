namespace Qualysoft.Evaluation.Data
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Domain;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EFRepository<TDatabaseContext, TAggregateRootType, TKeyType>
        : IAsyncRepository<TAggregateRootType, TKeyType>
        where TDatabaseContext : DbContext 
        where TAggregateRootType : BaseEntity<TKeyType>, IAggregateRoot
    {
        protected readonly TDatabaseContext _dbContext;

        public EFRepository(TDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TAggregateRootType> GetByIdAsync(TKeyType id) =>
            await _dbContext.Set<TAggregateRootType>().FindAsync(id);


        public async Task<IEnumerable<TAggregateRootType>> GetAllAsync() =>
            await _dbContext.Set<TAggregateRootType>().ToListAsync();

        public async Task<TAggregateRootType> AddAsync(TAggregateRootType entity)
        {
            _dbContext.Set<TAggregateRootType>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TAggregateRootType entity)
        {
            _dbContext.Set<TAggregateRootType>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TAggregateRootType entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TAggregateRootType>> GetAllBySpecificationAsync(ISpecification<TAggregateRootType> spec) =>
            await GetAllMatchingSpecification(spec).ToListAsync();

        public async Task<TAggregateRootType> GetBySpecificationAsync(ISpecification<TAggregateRootType> spec) =>
            await GetAllMatchingSpecification(spec).FirstOrDefaultAsync();

        private IQueryable<TAggregateRootType> GetAllMatchingSpecification(ISpecification<TAggregateRootType> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<TAggregateRootType>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult.Where(spec.Criteria);
        }
    }
}
