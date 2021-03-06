﻿namespace Qualysoft.Evaluation.Application.Xml
{
    using Qualysoft.Evaluation.Domain;
    using System.Xml.Serialization;

    public abstract class BaseRequestXmlSerializer : ISerializeXml
    {
        protected readonly IClassMapper<Request, CT_XSD_Request> mapper;

        protected BaseRequestXmlSerializer(IClassMapper<Request, CT_XSD_Request> classMapper)
        {
            mapper = classMapper;
        }

        protected XmlSerializerNamespaces Namespaces
        {
            get
            {
                //Create our own namespaces for the output
                var ns = new XmlSerializerNamespaces();
                //Add an empty namespace and empty value
                ns.Add("", "");
                return ns;
            }
        }

        public void Persist(Request request) => InternalPersist(request);

        public abstract object InternalPersist(Request request);
    }
}
