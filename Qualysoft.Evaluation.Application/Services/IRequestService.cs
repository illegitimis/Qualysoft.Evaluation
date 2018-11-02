namespace Qualysoft.Evaluation.Application
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRequestService
    {
        RequestPostResponse Upsert(IReadOnlyCollection<RequestModel> requestDtos);
    }
}
