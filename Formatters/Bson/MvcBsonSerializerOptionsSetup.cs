
namespace Formatters.Bson
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.ObjectPool;
    using Microsoft.Extensions.Options;

    public class MvcBsonSerializerOptionsSetup : ConfigureOptions<MvcOptions>
    {
        public MvcBsonSerializerOptionsSetup()
            : base(ConfigureMvc)
        {
        }

        public static void ConfigureMvc(MvcOptions options)
        {
            options.OutputFormatters.Add(new NewtonsoftBsonOutputFormatter(BsonSerializerSettingsProvider.CreateSerializerSettings()));
            options.InputFormatters.Add(new NewtonsoftBsonInputFormatter(BsonSerializerSettingsProvider.CreateSerializerSettings(), new DefaultObjectPoolProvider()));
        }
    }
}
