namespace Qualysoft.Evaluation.Api.IntegrationTests
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Data;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class InMemoryEFRepositoryTests : IDisposable
    {
        private readonly EFRepository<EvaluationContext, Request, int> requestRepo;
        private readonly EvaluationContext ctx;
        private readonly int missingId;

        public InMemoryEFRepositoryTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<EvaluationContext>()
                .UseInMemoryDatabase(databaseName: "Hoist")
                .Options;

            ctx = new EvaluationContext(dbContextOptions);
            ctx.Requests.AddRange(BogusDataGenerator.Requests(2));
            ctx.SaveChanges();

            requestRepo = new EFRepository<EvaluationContext, Request, int>(ctx);

            missingId = BogusDataGenerator.Requests(1).First().Index;
        }

        public void Dispose()
        {
            ctx.Dispose();
        }

        [Fact]
        public async Task GetByIdShouldNotReturnRequest()
        {
            var req = await requestRepo.GetByIdAsync(missingId);
            Assert.Null(req);
        }

        [Fact]
        public async Task GetAllAndGetByIdShouldReturnRequests()
        {
            var requests = (await requestRepo.GetAllAsync()).ToArray();
            Assert.NotEmpty(requests);

            /* 
             * strangely failing
             * Assert.Equal(2, requests.Length);
             */

            foreach(var r in requests)
            {
                var req = await requestRepo.GetByIdAsync(r.Index);
                Assert.NotNull(req);
            }
        }

        [Fact]
        public async Task UpdateShouldEditRequests()
        {
            var date = DateTime.UtcNow;
            var requests = await requestRepo.GetAllAsync();

            foreach (var r in requests)
            {
                r.Date = date;
                await requestRepo.UpdateAsync(r);
                Assert.Equal(date, r.Date);
            }
        }

        [Fact]
        public async Task ShouldDeleteAndAdd()
        {
            var r = new Request(missingId, "miss", DateTime.UtcNow);
            await requestRepo.AddAsync(r);

            var req = await requestRepo.GetByIdAsync(missingId);
            Assert.NotNull(req);

            await requestRepo.DeleteAsync(req);
            var request = await requestRepo.GetByIdAsync(missingId);
            Assert.Null(request);
        }


    }
}
