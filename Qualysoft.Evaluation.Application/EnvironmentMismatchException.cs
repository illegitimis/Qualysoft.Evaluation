namespace Qualysoft.Evaluation.Application
{
    using System;
    using System.Runtime.Serialization;

    public class EnvironmentMismatchException : Exception
    {
        public EnvironmentMismatchException()
            : base()
        {
        }

        protected EnvironmentMismatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public EnvironmentMismatchException(string message) : base(message)
        {
        }

        public EnvironmentMismatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
