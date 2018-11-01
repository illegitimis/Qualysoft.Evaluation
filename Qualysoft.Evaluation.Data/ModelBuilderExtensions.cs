namespace Qualysoft.Evaluation.Data
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>Extensions methods for <see cref="ModelBuilder"/></summary>
    /// <remarks>https://www.learnentityframeworkcore.com/migrations/seeding</remarks>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Generate fake data with Bogus
        /// </summary>
        /// <param name="modelBuilder"></param>        

        public static void BogusFakerSeed(this ModelBuilder modelBuilder, int count)
        {
            modelBuilder
               .Entity<Request>()
               .HasData(BogusDataGenerator.Requests(count).ToArray());
        }

    }
}
