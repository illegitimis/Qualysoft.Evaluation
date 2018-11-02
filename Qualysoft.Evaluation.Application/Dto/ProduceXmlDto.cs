namespace Qualysoft.Evaluation.Application.Dto
{
    public class ProduceXmlDto
    {
        public string FileName { get; private set; }
        public long StreamLength { get; private set; }

        public ProduceXmlDto(string name, long length)
        {
            FileName = name;
            StreamLength = length;
        }
    }
}
