using System;
using Myproject.Models;

namespace Myproject.Services
{
	public interface IDirectorInterface
	{
		Task<Director> Find(int id);
		Task<List<Director>> GetAll();
		Task<Director> AddDirector(Director director);
		Task Update(Director director, int id);
		Task Delete(int id);
	}
}

