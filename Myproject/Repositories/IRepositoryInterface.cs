using System;
namespace Myproject.Repositories
{
	public interface IRepositoryInterface<T1,T2> where T1:class
	{
		Task<IEnumerable<T1>> GetAll();
		Task<T1> GetById(T2 id);
		Task<T1> Add(T1 entity);
		Task Update(T1 entity,T2 id);
		Task Delete(T2 id);
		Task Save();
	}
}

