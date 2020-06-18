using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Uni.Academic.Data.Test.Infra
{
    public class DatabaseFixture
    {
        public AcademicContext Context;

        public DatabaseFixture()
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\..\src\Uni.Academic.Web\appsettings.Development.json");

            var options = new DbContextOptionsBuilder<AcademicContext>();
            var cfg = new ConfigurationBuilder().AddInMemoryCollection()
                .AddJsonFile(path)
                .Build();

            var connectionString = cfg[$"ConnectionStringTest:DefaultConnection@{Environment.MachineName}"];
            connectionString ??= cfg["ConnectionStringTest:DefaultConnection"];

            options.UseSqlServer(connectionString);
            Context = new AcademicContext(options.Options);

            Context.Database.EnsureDeleted();
            Context.Database.Migrate();
        }
    }
}