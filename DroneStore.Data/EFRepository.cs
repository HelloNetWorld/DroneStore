using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Ardalis.GuardClauses;

namespace DroneStore.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
	{
        private readonly DbContext _context;

		public EfRepository(DbContext context)
		{
			_context = context;
            DbSet = _context.Set<TEntity>();
		}

        public virtual IEnumerable<TEntity> Entities => DbSet.AsEnumerable();

        public virtual IEnumerable<TEntity> EntitiesReadOnly => DbSet.AsNoTracking().AsEnumerable();

        public virtual TEntity GetById(object id)
		{
			return DbSet.Find(id);
		}

        public virtual void Insert(TEntity entity)
		{
			Guard.Against.Null(entity, nameof(entity));

			DbSet.Add(entity);
            _context.SaveChanges();
		}

        public virtual void Update(TEntity entity)
		{
			Guard.Against.Null(entity, nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
		{
			Guard.Against.Null(entity, nameof(entity));

			_context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
		}

        public DbSet<TEntity> DbSet { get; }
    }
}
