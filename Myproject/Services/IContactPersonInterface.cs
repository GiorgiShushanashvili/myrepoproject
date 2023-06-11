using System;
using Myproject.Models;

namespace Myproject.Services
{
	public interface IContactPersonInterface
	{
		Task<ContactPerson> Find(int id);
		Task<List<ContactPerson>> GetAll();
		Task<ContactPerson> AddContactPerson(ContactPerson person);
		Task Update(ContactPerson person, int id);
		Task Delete(int id);
	}
}

