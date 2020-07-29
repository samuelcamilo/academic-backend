using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Reflection;
using Uni.Academic.Core.Interfaces.Repositories;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected readonly AcademicContext _context;
        protected readonly DbSet<T> _currentSet;

        public Repository(AcademicContext context)
        {
            this._context = context;
            this._currentSet = _context.Set<T>();
        }

        public long Insert(T entity)
        {
            _currentSet.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Update(T entity)
        {
            var entityEntry = _context.Entry(entity);
            UpdateWithoutChangeCreatedAt(entityEntry);
            _context.SaveChanges();
        }

        public void Remove(long id)
        {
            var entityEntry = _context.Entry(CreateInstance<T>());
            entityEntry.Property<long>(nameof(Entity.Id)).CurrentValue = id;

            entityEntry.State = EntityState.Deleted;

            _context.SaveChanges();
        }

        public T Get(long id)
            => _currentSet.FirstOrDefault(x => x.Id == id);

        public T GetAsNoTracking(long id)
            => _currentSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public IQueryable<T> GetAll()
            => _currentSet;

        public bool Exists(long id)
            => _currentSet.Any(x => x.Id == id);

        private static TEntity CreateInstance<TEntity>()
            => (TEntity)Activator.CreateInstance(typeof(TEntity), BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance, null, null, null);

        protected static void UpdateWithoutChangeCreatedAt<TEntity>(in EntityEntry<TEntity> entityEntry)
            where TEntity : Entity
        {
            entityEntry.State = EntityState.Modified;
            entityEntry.Property(t => t.CreateAt).IsModified = false;
        }
    }
}
