namespace Qualysoft.Evaluation.Application
{
    using Qualysoft.Evaluation.Domain;


    public class DomainToXmlSerializedRequestMapper :
        IClassMapper<Request, CT_XSD_Request>
    {
        public CT_XSD_Request Map(Request input) =>
            new CT_XSD_Request()
            {
                Index = input.Index,
                Content = new CT_XSD_Request_Content()
                {
                    Date = input.Date,
                    Name = input.Name,
                    Visits = input.Visits.GetValueOrDefault(),
                    VisitsSpecified = input.Visits.HasValue
                }
            };
    }
}
