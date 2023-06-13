using System;
using Microsoft.EntityFrameworkCore;
using Myproject.Context;
using Myproject.Models;

namespace Myproject.Repositories
{
    public class DirectorRepository : IRepositoryInterface<Director, int>
    {
        private readonly BankContext _context;

        public async Task<Director> Add(Director entity)
        {
            await _context.Directors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var director = await _context.Directors.FirstOrDefaultAsync(b=>b.DirectorId==id);
            if (director == null)
                return;
            _context.Remove(director);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task<Director> GetById(int id)
        {
            return await _context.Directors.FindAsync(id);
        }


        public async Task Update(Director updatedDirector, int id)
        {
            var existngDirector = await _context.Directors.FindAsync(id);
            if (existngDirector != null)
            {
                existngDirector.Firstname = updatedDirector.Firstname;
                existngDirector.Lastname = updatedDirector.Lastname;
                existngDirector.BirthDate = updatedDirector.BirthDate;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

