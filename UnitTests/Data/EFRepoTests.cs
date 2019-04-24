namespace Qualysoft.Evaluation.Data.UnitTests
{
    using System.Linq;
    using System.Reflection;
    using Xunit;

    public class EFRepoTests
    {
        [Fact]
        public void RepositoryHasOnlyBasicCRUDOperations()
        {
            var m = typeof(EFRepository<,,>).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            Assert.NotNull(m);
            Assert.Equal(7, m.Length);

            var names = m.Select(x => x.Name).OrderBy(x => x).ToArray();
            Assert.Equal(new string[]
            {
                "AddAsync",
                "DeleteAsync",
                "GetAllAsync",
                "GetAllBySpecificationAsync",
                "GetByIdAsync",
                "GetBySpecificationAsync",
                "UpdateAsync"
            }, names);

        }
    }
}
