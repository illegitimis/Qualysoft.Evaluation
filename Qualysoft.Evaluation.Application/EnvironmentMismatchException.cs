namespace Qualysoft.Evaluation.Application
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public sealed class EnvironmentMismatchException : Exception
    {
        public EnvironmentMismatchException()
            : base()
        {
        }

        public EnvironmentMismatchException(string message)
            : base(message)
        {
        }

        public EnvironmentMismatchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        private EnvironmentMismatchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
