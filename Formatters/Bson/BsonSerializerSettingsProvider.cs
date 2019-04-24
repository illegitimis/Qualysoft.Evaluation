
namespace Formatters.Bson
{
    using Newtonsoft.Json;

    public static class BsonSerializerSettingsProvider
    {
        public static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None
            };
        }
    }
}
