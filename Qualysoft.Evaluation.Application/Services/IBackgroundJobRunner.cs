namespace Qualysoft.Evaluation.Application
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBackgroundJobRunner
    {
        void Enqueue(Action action);
    }
}
