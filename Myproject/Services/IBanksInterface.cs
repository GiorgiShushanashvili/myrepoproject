using System;
using System.Collections.Generic;
using Myproject.Models;
namespace Myproject.Services
{
	public interface IBanksInterface
	{
		Task<Banks> Find(int id);
		Task<List<Banks>> GetAll();
		Task<Banks> AddBank(Banks bank);
		Task Update(Banks bank, int id);
		Task Delete(int id);
	}
}

