using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Uni.Academic.Data.Repositories;

namespace Uni.Academic.Data.Test.Infra
{
    public class DatabaseFixture
    {
        public AcademicContext Context { get; }
        public IMapper Mapper { get; }

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

            Mapper = GetMapper();
        }

        public static IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(Activator.CreateInstance);

            var profileType = typeof(Profile);
            var profiles = typeof(Repository<>).Assembly.ExportedTypes
                .Where(type => !type.IsAbstract && profileType.IsAssignableFrom(type))
                .Select(Activator.CreateInstance)
                .Cast<Profile>()
                .ToArray();

            mce.AddProfiles(profiles);
            mce.AddExpressionMapping();

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            return new Mapper(mc);
        }
    }
}