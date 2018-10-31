namespace Qualysoft.Evaluation.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity and to ease caching logic


    public class BaseEntity<TKeyType>
    {
        protected BaseEntity() { }

        public BaseEntity(TKeyType key)
        {
            Index = key;
        }

        /// <summary>identity, must be unique</summary>
        public TKeyType Index { get; set; }
    }

    public interface IAggregateRoot { }

    /// <summary>Provide repositories only for aggregate roots that actually need direct access</summary>
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

    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
