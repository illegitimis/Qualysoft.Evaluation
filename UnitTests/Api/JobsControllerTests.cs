namespace Qualysoft.Evaluation.Api.UnitTests
{
    using NSubstitute;
    using Qualysoft.Evaluation.Api.Controllers;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class JobsControllerTests
    {
        readonly JobsController sut;
        private readonly IAsyncRepository<Request, int> requestRepo;
        private readonly ISerializeXml<ProduceXmlDto> serializer;
        private readonly IBackgroundJobRunner backgroundJobRunner;

        public JobsControllerTests()
        {
            requestRepo = Substitute.For<IAsyncRepository<Request, int>>();
            serializer = Substitute.For<ISerializeXml<ProduceXmlDto>>();
            backgroundJobRunner = Substitute.For<IBackgroundJobRunner>();
            sut = new JobsController(requestRepo, serializer, backgroundJobRunner);
        }

        [Fact]
        public async Task SaveFilesShouldPersistXmlAndRunInTheBackground()
        {
            var req = new Request();
            requestRepo
                .GetAllAsync()
                .Returns(new[] { req });

            backgroundJobRunner
                .Enqueue(Arg.Any<Action>())
                .Returns(Task.Factory.StartNew(() => serializer.Persist(req)));

            await sut.SaveFiles();

            await backgroundJobRunner
                .Received(1)
                .Enqueue<ProduceXmlDto>(Arg.Any<Func<ProduceXmlDto>>());
            serializer
                .Received(1)
                .Persist(req);
        }
    }
}
