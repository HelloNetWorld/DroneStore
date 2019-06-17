using System.Collections.Generic;

namespace DroneStore.Data
{
    public interface IRepository<T> where T : class
	{
		IEnumerable<T> Entities { get; }
		IEnumerable<T> EntitiesReadOnly { get; }
		T GetById(object id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}