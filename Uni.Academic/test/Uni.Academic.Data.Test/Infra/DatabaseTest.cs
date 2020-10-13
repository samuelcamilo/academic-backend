using System;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.Test.Infra
{
    public abstract class DatabaseTest<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : Entity
    {
        protected AcademicContext _context;
        protected TRepository _repository;

        public DatabaseTest(DatabaseFixture fixture)
        {
            _repository = (TRepository)Activator.CreateInstance(typeof(TRepository), fixture.Context);
            _context = fixture.Context;
        }
    }
}
