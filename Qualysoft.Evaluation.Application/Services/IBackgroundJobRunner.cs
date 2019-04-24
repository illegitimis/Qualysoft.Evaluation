namespace Qualysoft.Evaluation.Application
{
    using System;
    using System.Threading.Tasks;

    public interface IBackgroundJobRunner
    {
        Task Enqueue(Action action);
        Task<T> Enqueue<T>(Func<T> funcOfT);
    }
}
