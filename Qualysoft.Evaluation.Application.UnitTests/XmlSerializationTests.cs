using System;
using System.IO;
using System.Xml.Serialization;
using Xunit;

namespace Qualysoft.Evaluation.Application.UnitTests
{
    public class XmlSerializationTests
    {
        [Fact]
        public void Test1()
        {
            CT_XSD_Request r = new CT_XSD_Request
            {
                Index = 13,
                Content = new CT_XSD_Request_Content
                {
                    Name = "name",
                    DateRequested = new DateTime(2000, 1, 1)
                }
            };

            using (var writer = new StringWriter())
            {
                XmlSerializer srlz = new XmlSerializer(typeof(CT_XSD_Request), string.Empty);
                srlz.Serialize(writer, r);
                string s = writer.ToString();
                Assert.NotNull(s);
            }
        }

        [Fact]
        public void Test2()
        {
            CT_XSD_Request r = new CT_XSD_Request
            {
                Index = 17,
                Content = new CT_XSD_Request_Content
                {
                    Name = "name",
                    DateRequested = new DateTime(2018, 5, 22),
                    visits = 13
                }
            };

            using (var writer = new StringWriter())
            {
                XmlSerializer srlz = new XmlSerializer(typeof(CT_XSD_Request));
                srlz.Serialize(writer, r);
                string s = writer.ToString();
                Assert.NotNull(s);
            }
        }
    }
}
