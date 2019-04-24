namespace Qualysoft.Evaluation.Application.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Qualysoft.Evaluation.Domain;

    public class RequestStringXmlSerializer : BaseRequestXmlSerializer<string>
    {
        public RequestStringXmlSerializer(IClassMapper<Request, CT_XSD_Request> mapper) 
            : base (mapper)
        {
        }

        public override object InternalPersist(Request request)
        {
            using (var utf8StringWriter = new Utf8StringWriter())
            {
                //Create the serializer
                XmlSerializer srlz = new XmlSerializer(typeof(CT_XSD_Request), defaultNamespace: string.Empty);

                var o = mapper.Map(request);

                //Serialize the object with our own namespaces (notice the overload)
                srlz.Serialize(utf8StringWriter, o, Namespaces);

                // string output
                string s = utf8StringWriter.ToString();
                return s;
            }
        }
    }
}
