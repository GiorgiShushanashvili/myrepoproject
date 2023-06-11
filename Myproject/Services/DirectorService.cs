using System;
using Myproject.Models;
using Myproject.Repositories;

namespace Myproject.Services
{
    public class DirectorService : IDirectorInterface
    {
        private readonly DirectorRepository _repository;
        public DirectorService(DirectorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Director> AddDirector(Director director)
        {
            var newdirector = await _repository.Add(director);
            if (newdirector == null)
                return null;
            return newdirector;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Director> Find(int id)
        {
            var director = await _repository.GetById(id);
            if (director == null)
                return null;
            return director;
        }

        public async Task<List<Director>> GetAll()
        {
           var directors = (List<Director>)await _repository.GetAll();
            if (directors == null)
                return null;
            return directors;
        }

        public async Task Update(Director director, int id)
        {
            await _repository.Update(director, id);
        }
    }
}

