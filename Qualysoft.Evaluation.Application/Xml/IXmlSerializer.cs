namespace Qualysoft.Evaluation.Application
{
    using Qualysoft.Evaluation.Domain;

    public interface ISerializeXml<T>
    {
        T Persist(Request request);
    }
}
