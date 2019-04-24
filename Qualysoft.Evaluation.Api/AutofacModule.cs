namespace Qualysoft.Evaluation.Api
{
    using Autofac;
    using Microsoft.AspNetCore.Http;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Application.Xml;
    using Qualysoft.Evaluation.Data;
    using Qualysoft.Evaluation.Domain;

    /// <summary>
    /// User defined set of registrations to add to an Autofac container
    /// </summary>
    /// <remarks>
    /// https://autofaccn.readthedocs.io/en/latest/integration/aspnetcore.html
    /// 
    /// </remarks>
    internal class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<DomainToXmlSerializedRequestMapper>().As<IClassMapper<Request, CT_XSD_Request>>().SingleInstance();
            builder.RegisterType<BackgroundJobRunner>().As<IBackgroundJobRunner>().SingleInstance();

            builder.RegisterType<AppDataFileRequestXmlSerializer>().As<ISerializeXml<ProduceXmlDto>>().InstancePerLifetimeScope();
            builder.RegisterType<RequestService>().As<IRequestService>().InstancePerLifetimeScope();
            builder.RegisterType<EFRepository<EvaluationContext, Request, int>>().As<IAsyncRepository<Request, int>>().InstancePerLifetimeScope();
        }
    }
}