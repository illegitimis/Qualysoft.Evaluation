namespace Qualysoft.Evaluation.Api
{
    using System.Collections.Generic;
    using System.Linq;

    public class JsonErrorResponse
    {
        public JsonErrorResponse(IEnumerable<string> messages)
        {
            Messages = messages.ToArray();
        }

        public JsonErrorResponse(string message)
        {
            Messages = new[] { message };
        }

        public object DeveloperMessage { get; set; }

        public string[] Messages { get; private set; }
    }
}