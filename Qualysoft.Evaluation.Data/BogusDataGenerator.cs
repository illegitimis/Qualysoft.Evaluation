
namespace Qualysoft.Evaluation.Data
{
    using Bogus;
    using Bogus.Extensions;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Collections.Generic;

    public static class BogusDataGenerator
    {
        public static IEnumerable<Request> Requests(int count)
        {
            var faker = new Faker<Request>()
                //Ensure all properties have rules. 
                .StrictMode(true)
                // PK f => f.IndexFaker
                .RuleFor(x => x.Index, f => f.UniqueIndex)
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Date, f => f.Date.Recent(1000))
                .RuleFor(x => x.Visits, f => f.Random.Int().OrNull(f, nullWeight: 0.4f));

            return faker.GenerateLazy(count);
        }

        public static IEnumerable<RequestModel> RequestDtos(int count)
        {
            var faker = new Faker<RequestModel>()
                //Ensure all properties have rules. 
                .StrictMode(true)
                .RuleFor(x => x.Index, f => f.IndexFaker)
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Date, f => f.Date.Recent(1000))
                .RuleFor(x => x.Visits, f => f.Random.Int().OrNull(f, nullWeight: 0.4f));

            return faker.GenerateLazy(count);
        }
    }
}
