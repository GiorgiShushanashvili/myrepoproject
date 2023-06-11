using System;
using Myproject.Models;
using Myproject.Repositories;

namespace Myproject.Services
{
    public class ContactPersonService : IContactPersonInterface
    {
        private readonly ContactPersonRepository _repository;
        public ContactPersonService(ContactPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContactPerson> AddContactPerson(ContactPerson person)
        {
            var newperson = await _repository.Add(person);
            if (newperson == null)
                return null;
            return newperson;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<ContactPerson> Find(int id)
        {
           var person = await _repository.GetById(id);
            if (person == null)
                return null;
            return person;
        }

        public async Task<List<ContactPerson>> GetAll()
        {
            var persons = (List<ContactPerson>)await _repository.GetAll();
            if (persons == null)
                return null;
            return persons;
        }

        public async Task Update(ContactPerson person, int id)
        {
            await _repository.Update(person, id);
        }
    }
}

