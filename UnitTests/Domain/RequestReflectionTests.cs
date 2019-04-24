namespace Qualysoft.Evaluation.Domain.UnitTests
{
    using System;
    using System.Reflection;
    using Xunit;

    public class RequestReflectionTests
    {
        /// <summary>
        /// Message: `System.MissingMethodException` : No parameterless constructor defined for this `Request` object.
        /// </summary>
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

        [Fact]
        public void RequestShouldHaveCtorWithParameters()
        {
            Type requestType = typeof(Request);
            ConstructorInfo ctorInfo = requestType.GetConstructor(
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                callConvention: CallingConventions.HasThis,
                types: new Type[] { typeof(int), typeof(string), typeof(DateTime), typeof(int?) },
                modifiers: null);
            Assert.NotNull(ctorInfo);
        }
    }
}
