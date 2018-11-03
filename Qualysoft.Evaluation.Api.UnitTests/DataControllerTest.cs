namespace Qualysoft.Evaluation.Api.UnitTests
{
    using Microsoft.AspNetCore.Mvc;
    using NSubstitute;
    using Qualysoft.Evaluation.Api.Controllers;
using Qualysoft.Evaluation.Application;
using System;
    using System.Collections.Generic;
    using Xunit;

    public class DataControllerTest
    {
        // system under test
        private readonly DataController _sut;

        // mocked dependencies
        private readonly IRequestService _requestService;

        public DataControllerTest()
        {
            _requestService = Substitute.For<IRequestService>();
            _sut = new DataController(_requestService);
        }

        [Fact]
        public void PostNullCollectionShouldReturnBadRequest()
        {
            IActionResult result = _sut.Post(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void PostEmptyCollectionShouldReturnBadRequest()
        {
            IActionResult result = _sut.Post(new List<RequestModel>().AsReadOnly());
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(13, 20)]
        public void PostReadonlyCollectionShouldReturnOkAndExpectedNumberOfAddedAndUpdatedItems(int added, int updated)
        {
            _requestService
                .Upsert(Arg.Is<IReadOnlyCollection<RequestModel>>(x => x.Count > 0))
                .Returns(new RequestPostResponse(added, updated));

            IActionResult result = _sut.Post(new List<RequestModel>(new[] { new RequestModel() }).AsReadOnly());

            var ok = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<RequestPostResponse>(ok.Value);
            Assert.Equal(added, response.Added);
            Assert.Equal(updated, response.Updated);
        }

        [Fact]
        public void SitePing()
        {
            Assert.IsType<OkResult>(_sut.Ping());
        }
    }
}
