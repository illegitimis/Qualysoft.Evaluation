namespace Qualysoft.Evaluation.Data.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class BogusDataGeneratorTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        public void ShouldGenerateRequests(int count)
        {
            var timeSpan1000Days = TimeSpan.FromDays(1000);
            var requests = BogusDataGenerator.Requests(count).ToArray();

            Assert.NotNull(requests);
            Assert.Equal(count, requests.Length);
            Assert.All(requests, x => {
                Assert.NotNull(x);
                Assert.NotNull(x.Name);
                Assert.InRange(x.Date, DateTime.UtcNow.Subtract(timeSpan1000Days), DateTime.UtcNow.Add(timeSpan1000Days));
            });

            // assert generated indices are unique
            var indicesSet = new HashSet<int>(requests.Select(r => r.Index));
            Assert.Equal(count, indicesSet.Count);
        }
    }
}
