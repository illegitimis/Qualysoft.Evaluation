namespace Qualysoft.Evaluation.Application.UnitTests
{
using Qualysoft.Evaluation.Domain;
using NSubstitute;
using Xunit;
using System.Linq;
using System;
using System.Collections.Generic;

    public class RequestServiceTests
    {
        private readonly IRequestService sut;
        readonly IAsyncRepository<Request, int> requestRepository;

        public RequestServiceTests()
        {
            requestRepository = Substitute.For<IAsyncRepository<Request, int>>();
            sut = new RequestService(requestRepository);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void AllUpdatesAndAggregatesResults(int no)
        {
            // arrange
            requestRepository
               .GetByIdAsync(Arg.Any<int>())
               .ReturnsForAnyArgs(Defines.FullRequest());

            // act
            RequestPostResponse response = sut.Upsert(RequestDtos(no));

            // assert
            Assert.NotNull(response);
            Assert.Equal(no, response.Updated);
            Assert.Equal(0, response.Added);

            requestRepository.Received(0).AddAsync(Arg.Any<Request>());
            requestRepository.Received(no).UpdateAsync(Arg.Any<Request>());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void InsertOnlyAndAggregatesResults(int no)
        {
            // arrange
            requestRepository
               .GetByIdAsync(Arg.Any<int>())
               .ReturnsForAnyArgs(default(Request));

            // act
            RequestPostResponse response = sut.Upsert(RequestDtos(no));

            // assert
            Assert.NotNull(response);
            Assert.Equal(0, response.Updated);
            Assert.Equal(no, response.Added);

            requestRepository.Received(no).AddAsync(Arg.Any<Request>());
            requestRepository.Received(0).UpdateAsync(Arg.Any<Request>());
        }

        IReadOnlyCollection<RequestModel> RequestDtos(int no) =>
            Enumerable
                .Range(1, no)
                .Select(i => new RequestModel()
                {
                    Index = i,
                    Date = DateTime.UtcNow,
                    Name = "name"
                }).ToList()
                .AsReadOnly();

    }
}
