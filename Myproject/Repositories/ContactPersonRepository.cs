using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Myproject.Context;
using Myproject.Models;

namespace Myproject.Repositories
{
    public class ContactPersonRepository : IRepositoryInterface<ContactPerson, int>
    {
        private readonly BankContext _context;
        public ContactPersonRepository(BankContext context)
        {
            _context = context;
        }
        public async Task<ContactPerson> Add(ContactPerson entity)
        {
            await _context.ContactPerson.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var person = await _context.ContactPerson.FirstOrDefaultAsync(b=>b.ContactPersonId==id);
            if (person != null)
            {
                _context.Remove(person);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactPerson>> GetAll()
        {
            return await _context.ContactPerson
                .Include(a => a.Bank).ToListAsync();
        }

        public async Task<ContactPerson> GetById(int id)
        {
            return await _context.ContactPerson.FindAsync(id);
        }

        
        public async Task Update(ContactPerson updatedperson, int id)
        {
            var existingperson = await _context.ContactPerson.FindAsync(id);
            if (existingperson != null)
            {
                existingperson.Firstname = updatedperson.Firstname;
                existingperson.Lastname = updatedperson.Lastname;
                existingperson.BirthDate = updatedperson.BirthDate;
                existingperson.Bank = updatedperson.Bank;
                existingperson.Position = updatedperson.Position;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

