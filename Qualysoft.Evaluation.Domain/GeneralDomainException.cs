namespace Qualysoft.Evaluation.Domain
{
    using System;
    using System.Runtime.Serialization;

    public class GeneralDomainException : Exception
    {
        public GeneralDomainException()
            : base()
        {
        }

        protected GeneralDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public GeneralDomainException(string message) : base(message)
        {
        }

        public GeneralDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
