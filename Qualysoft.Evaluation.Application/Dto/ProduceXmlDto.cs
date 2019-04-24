namespace Qualysoft.Evaluation.Application.Dto
{
using ProtoBuf;
using System;

    [Serializable]
    [ProtoContract]
    public class ProduceXmlDto
    {
        [ProtoMember(1)]
        public string FileName { get; private set; }
        [ProtoMember(2)]
        public long StreamLength { get; private set; }

        public ProduceXmlDto(string name, long length)
        {
            FileName = name;
            StreamLength = length;
        }
    }
}
