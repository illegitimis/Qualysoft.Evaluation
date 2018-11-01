namespace Qualysoft.Evaluation.Application
{
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RequestService : IRequestService
    {
        private readonly IAsyncRepository<Request, int> requestRepository;

        /// <summary>ctor</summary>
        /// <param name="requestRepository">request repository</param>
        public RequestService(IAsyncRepository<Request, int> requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public RequestPostResponse Upsert(IReadOnlyCollection<RequestModel> requestDtos) =>
            requestDtos
                .Select(async requestDto => await UpsertAsync(requestDto))
                .Aggregate(RequestPostResponse.None, (x, tuple) => x.AddTuple(tuple.Result));

        private async Task<(int, int)> UpsertAsync(RequestModel requestDto)
        {
            int added = 0, updated = 0;

            var existingRequest = await requestRepository.GetByIdAsync(requestDto.Index);

            if (existingRequest == default(Request))
            {
                var mappedRequest = new Request(requestDto.Index, requestDto.Name, requestDto.Date, requestDto.Visits);
                await requestRepository.AddAsync(mappedRequest);
                added++;
            }
            else
            {
                existingRequest.UpdateAttributes(requestDto.Name, requestDto.Date, requestDto.Visits);
                await requestRepository.UpdateAsync(existingRequest);
                updated++;
            }

            return (added, updated);
        }
    }
}
