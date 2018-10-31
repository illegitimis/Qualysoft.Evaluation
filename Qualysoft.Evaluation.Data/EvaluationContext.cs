namespace Qualysoft.Evaluation.Data
{
    using Microsoft.EntityFrameworkCore;
    using Qualysoft.Evaluation.Domain;
    using System;
using System.Collections.Generic;
using System.Text;

    public class EvaluationContext : DbContext
    {
        public EvaluationContext(DbContextOptions<EvaluationContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
    }
}
