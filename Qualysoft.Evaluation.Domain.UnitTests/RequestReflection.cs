namespace Qualysoft.Evaluation.Domain.UnitTests
{
using System;
    using System.Reflection;
    using Xunit;

    public class RequestReflection
    {
        [Fact]
        public void RequestShouldHaveParameterlessCtorNeededByBogusFaker()
        {
            Type requestType = typeof(Request);
            ConstructorInfo ctorInfo = requestType.GetConstructor(
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                callConvention: CallingConventions.HasThis,
                types: new Type[] { },
                modifiers: null);
            Assert.NotNull(ctorInfo);
        }
    }
}
