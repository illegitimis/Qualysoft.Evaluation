namespace Qualysoft.Evaluation.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;


    /// <summary>Asynchronous repository</summary>
    /// <remarks>Provide repositories only for aggregate roots that actually need direct access</remarks>
    public interface IAsyncRepository<TAggregateRootType, TKeyType> 
        where TAggregateRootType : BaseEntity<TKeyType>, IAggregateRoot
    {
        Task<TAggregateRootType> GetByIdAsync(TKeyType id);

        Task<IEnumerable<TAggregateRootType>> GetAllAsync();

        Task<TAggregateRootType> GetBySpecificationAsync(ISpecification<TAggregateRootType> spec);

        Task<IEnumerable<TAggregateRootType>> GetAllBySpecificationAsync(ISpecification<TAggregateRootType> spec);

        Task<TAggregateRootType> AddAsync(TAggregateRootType entity);

        Task UpdateAsync(TAggregateRootType entity);

        Task DeleteAsync(TAggregateRootType entity);
    }
}