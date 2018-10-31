namespace Qualysoft.Evaluation.Data
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Domain;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// https://www.learnentityframeworkcore.com/migrations/seeding
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Request>()
                .HasData(
                    new Request(1, "William Shakespeare", DateTime.UtcNow, 13),
                    new Request(2, "io", DateTime.Now)
                );
        }

    }
}
