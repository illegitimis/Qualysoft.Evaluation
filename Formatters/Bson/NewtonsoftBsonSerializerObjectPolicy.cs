
namespace Formatters.Bson
{
    using Microsoft.Extensions.ObjectPool;
    using Newtonsoft.Json;

    public class NewtonsoftBsonSerializerObjectPolicy : IPooledObjectPolicy<JsonSerializer>
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public NewtonsoftBsonSerializerObjectPolicy(JsonSerializerSettings serializerSettings)
        {
            _serializerSettings = serializerSettings;
        }

        public JsonSerializer Create() => JsonSerializer.Create(_serializerSettings);

        public bool Return(JsonSerializer obj) => true;
    }
}
