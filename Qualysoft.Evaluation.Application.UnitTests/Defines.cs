namespace Qualysoft.Evaluation.Application.UnitTests
{
    using Qualysoft.Evaluation.Domain;
    using System;
using System.Collections.Generic;
using System.Text;

    public static class Defines
    {
        internal const string VISITS_NOT_SPECIFIED = "visits not specified";

        internal static Request NullVisitsRequest() => new Request
        {
            Index = 13,
            Name = VISITS_NOT_SPECIFIED,
            Date = new DateTime(2000, 1, 1)
        };

        internal static Request FullRequest() => new Request
        {
            Index = 17,
            Name = "name",
            Date = new DateTime(2018, 5, 22),
            Visits = 13
        };
    }
}
