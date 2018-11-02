namespace Qualysoft.Evaluation.Application
{
    using Qualysoft.Evaluation.Domain;

    public interface ISerializeXml
    {
        void Persist(Request request);
    }
}
