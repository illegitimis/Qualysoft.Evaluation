
namespace Formatters.Bson
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Bson;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A <see cref="NewtonsoftBsonOutputFormatter"/> for BSON content
    /// </summary>
    public class NewtonsoftBsonOutputFormatter : TextOutputFormatter
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private JsonSerializer _serializer;

        public NewtonsoftBsonOutputFormatter(JsonSerializerSettings serializerSettings)
        {
            if (serializerSettings == null)
            {
                throw new ArgumentNullException(nameof(serializerSettings));
            }


            _jsonSerializerSettings = serializerSettings;
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/bson"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (selectedEncoding == null)
            {
                throw new ArgumentNullException(nameof(selectedEncoding));
            }

            return WriteResponseBodyInternalAsync(context.HttpContext.Response, context.Object);
        }

        private async Task WriteResponseBodyInternalAsync(HttpResponse response, object o)
        {
            using (var bsonWriter = new BsonDataWriter(response.Body) { CloseOutput = false })
            {
                var jsonSerializer = CreateJsonSerializer();
                jsonSerializer.Serialize(bsonWriter, o);
                await bsonWriter.FlushAsync();
            }
        }

        private JsonSerializer CreateJsonSerializer()
        {
            if (_serializer == null)
            {
                _serializer = JsonSerializer.Create(_jsonSerializerSettings);
            }

            return _serializer;
        }
    }
}
