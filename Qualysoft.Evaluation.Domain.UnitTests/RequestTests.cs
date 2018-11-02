namespace Qualysoft.Evaluation.Domain.UnitTests
{
using System;
using System.Linq;
using Xunit;

    public class RequestTests
    {
        [Fact]
        public void GetDateStringTest()
        {
            var r = new Request() { Date = new DateTime(2000, 1, 1) };
            Assert.Equal("2000-01-01", r.GetDateString());
        }

        [Fact]
        public void UpdateAttributesTest()
        {
            const string name = "name";
            DateTime dt = new DateTime(2000, 1, 1);

            var r = new Request();
            r.UpdateAttributes(name, dt, null);

            Assert.Equal(dt, r.Date);
            Assert.Equal(name, r.Name);
            Assert.Null(r.Visits);
        }
    }
}
