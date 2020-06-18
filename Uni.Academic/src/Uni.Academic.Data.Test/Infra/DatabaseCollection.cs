using Xunit;

namespace Uni.Academic.Data.Test.Infra
{
    [CollectionDefinition("DatabaseCollection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {

    }
}
