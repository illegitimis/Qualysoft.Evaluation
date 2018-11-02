namespace Qualysoft.Evaluation.Domain
{
    /// <summary>BaseEntity{T} that supports different key types.</summary>
    /// <typeparam name="TKeyType">entity key type</typeparam>
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
}