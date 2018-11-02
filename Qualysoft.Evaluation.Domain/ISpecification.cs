namespace Qualysoft.Evaluation.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Specification pattern
    /// </summary>
    /// <typeparam name="T">entity type</typeparam>
    /// <remarks>pretty EF oriented</remarks>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Filter specification
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// strongly typed lambda expressions to specify related tables for navigation properties
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }
        
        /// <summary>
        /// Table names to include in queries 
        /// </summary>
        List<string> IncludeStrings { get; }
    }
}
