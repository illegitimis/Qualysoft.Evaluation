namespace Qualysoft.Evaluation.Domain.UnitTests
{
using System;
using System.Linq;
    using System.Reflection;
    using Xunit;

    public class BaseEntityReflectionTests
    {
        static readonly Type baseEntityOfIntType = typeof(BaseEntity<int>);

        [Fact]
        public void BaseEntityShouldHaveParameterlessProtectedCtorNeededByEFCore()
        {
            ConstructorInfo ctorInfo = baseEntityOfIntType.GetConstructor(
                bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                callConvention: CallingConventions.HasThis,
                types: new Type[0],
                modifiers: null);
            Assert.NotNull(ctorInfo);
        }

        [Fact]
        public void BaseEntityOfIntShouldHaveCtorWithOneIntParameter()
        {
            ConstructorInfo ctorInfo = baseEntityOfIntType.GetConstructor(
                bindingAttr: BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                callConvention: CallingConventions.HasThis,
                types: new Type[] { typeof(int) },
                modifiers: null);
            Assert.NotNull(ctorInfo);
        }
    }
}
