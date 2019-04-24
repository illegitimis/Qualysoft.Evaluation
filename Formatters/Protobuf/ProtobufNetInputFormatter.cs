namespace Formatters.Protobuf
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Formatters;
    using Microsoft.Net.Http.Headers;
    using ProtoBuf.Meta;

    public class ProtobufNetInputFormatter : InputFormatter
    {
        public ProtobufNetInputFormatter(ProtobufFormatterOptions protobufFormatterOptions)
        {
            var _options = protobufFormatterOptions ?? throw new ArgumentNullException(nameof(protobufFormatterOptions));
            foreach (var contentType in _options.SupportedContentTypes)
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue(contentType));
            }
        }

        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }

        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var type = context.ModelType;
            var request = context.HttpContext.Request;
            MediaTypeHeaderValue requestContentType = null;
            MediaTypeHeaderValue.TryParse(request.ContentType, out requestContentType);


            object result = Model.Deserialize(context.HttpContext.Request.Body, null, type);
            return InputFormatterResult.SuccessAsync(result);
        }

        protected override bool CanReadType(Type type)
        {
            return true;
        }

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}
