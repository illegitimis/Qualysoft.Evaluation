using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Qualysoft.Evaluation.Application.UnitTests
{
    public class BackgroundJobRunnerTest
    {
        readonly IBackgroundJobRunner backgroundJobRunner = new BackgroundJobRunner();

        [Fact]
        public void PositiveTest()
        {
            int i = 0;
            var queued = backgroundJobRunner.Enqueue(() => i = 5);
            queued.ContinueWith(t => 
            {
                Assert.Equal(5, i);
                Assert.True(t.IsCompletedSuccessfully);
                Assert.Equal(TaskStatus.RanToCompletion, t.Status);
            });
        }

        [Fact]
        public void OperationCancelledExceptionCaught()
        {
            var queued = backgroundJobRunner.Enqueue(() => throw new OperationCanceledException(""));
            queued.ContinueWith(t =>
            {
                Assert.True(t.IsCanceled);
                Assert.Equal(TaskStatus.Canceled, t.Status);
            });
        }

        [Fact]
        public void OtherExceptionsPromoted()
        {
            var queued = backgroundJobRunner.Enqueue(() => throw new Exception(""));
            queued.ContinueWith(t =>
            {
                Assert.True(t.IsFaulted);
                Assert.Equal(TaskStatus.Faulted, t.Status);
            });
        }
    }
}
