namespace Qualysoft.Evaluation.Application.Xml
{
    using Qualysoft.Evaluation.Application.Dto;
    using Qualysoft.Evaluation.Domain;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class AppDataFileRequestXmlSerializer : BaseRequestXmlSerializer
    {
        const string DIR = "App_Data/xml";

        private readonly XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
        {
            Indent = true,
            OmitXmlDeclaration = false,
            Encoding = Encoding.UTF8
        };

        static AppDataFileRequestXmlSerializer()
        {
            if (!Directory.Exists(DIR))
            {
                Directory.CreateDirectory(DIR);
            }
        }

        public AppDataFileRequestXmlSerializer(IClassMapper<Request, CT_XSD_Request> classMapper)
            : base(classMapper)
        {            
        }

        /// <remarks>https://stackoverflow.com/questions/4928323/xml-serialization-encoding</remarks>
        public override object InternalPersist(Request request)
        {
            // create or overwrite file
            using (var fs = File.Create($"{DIR}/{request.GetDateString()}.xml"))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(fs, xmlWriterSettings))
                {
                    //Create the serializer
                    XmlSerializer srlz = new XmlSerializer(typeof(CT_XSD_Request), defaultNamespace: string.Empty);

                    // map
                    CT_XSD_Request xsdRequest = mapper.Map(request);

                    //Serialize the object with our own namespaces (notice the overload)
                    srlz.Serialize(xmlWriter, xsdRequest, Namespaces);
                }

                return new ProduceXmlDto(fs.Name, fs.Length);
            }
        }       
    }
}