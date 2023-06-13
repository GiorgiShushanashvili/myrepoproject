using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Myproject.Context;
using Myproject.Models;

namespace Myproject.Repositories
{
    public class BanksRepository : IRepositoryInterface<Banks, int>
    {
        private readonly BankContext _context;
        public BanksRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Banks> Add(Banks entity)
        {
            await _context.Banks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var bank = await _context.Banks.FirstOrDefaultAsync(b=>b.Id==id);
            if (bank == null)
            {
                return;
            }
            else { _context.Remove(bank); }
        }

        public async Task<IEnumerable<Banks>> GetAll()
        {
            return await _context.Banks.Include(a => a.ContactPersons)
                .Include(a => a.GeneralDirector).ToListAsync();
        }

        public async Task<Banks> GetById(int id)
        {
            return await _context.Banks.FindAsync(id);
        }

        public async Task Update(Banks updated,int id)
        {
            var existingBank = await _context.Banks.FindAsync(id);
            if (existingBank != null)
            {
                existingBank.Name = updated.Name;
                existingBank.Acronym = updated.Acronym;
                existingBank.UrlAddress = updated.UrlAddress;
                existingBank.GeneralDirector = updated.GeneralDirector;
                existingBank.ContactPersons = updated.ContactPersons;
            }
            await _context.SaveChangesAsync();

        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}

