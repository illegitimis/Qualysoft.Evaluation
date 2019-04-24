namespace Qualysoft.Evaluation.Data.UnitTests
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Reflection;
    using Xunit;

    public class EvaluationContextTest
    {
        [Fact]
        public void HasOptionsConstructor()
        {
            ConstructorInfo ctorInfo = typeof(EvaluationContext).GetConstructor(
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                callConvention: CallingConventions.HasThis,
                types: new Type[] { typeof(DbContextOptions<EvaluationContext>) },
                modifiers: null);
            Assert.NotNull(ctorInfo);
        }
    }
}
