namespace Formatters.Protobuf
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Net.Http.Headers;
    using ProtoBuf.Meta;

    public class ProtobufNetOutputFormatter : OutputFormatter
    {
        // private readonly ProtobufFormatterOptions _options;

        public ProtobufNetOutputFormatter(ProtobufFormatterOptions protobufFormatterOptions)
        {
            ContentType = "application/x-protobuf";
            var _options = protobufFormatterOptions ?? throw new ArgumentNullException(nameof(protobufFormatterOptions));
            foreach (var contentType in _options.SupportedContentTypes)
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue(contentType));
            }
        }

        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public string ContentType { get; private set; }

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;

            Model.Serialize(response.Body, context.Object);
            return Task.FromResult(response);
        }
    }
}
