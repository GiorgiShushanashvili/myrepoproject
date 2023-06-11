using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Myproject.Models;
using Myproject.Repositories;

namespace Myproject.Services
{
    public class BankService : IBanksInterface
    {
        private readonly BanksRepository _repository;
        public BankService(BanksRepository repository)
        {
            _repository = repository;
        }

        public async Task<Banks> AddBank(Banks bank)
        {
            var newbank = await _repository.Add(bank);
            if (newbank == null)
                return null;
            return newbank;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Banks> Find(int id)
        {
            var bank = await _repository.GetById(id);
            if (bank == null)
                return null;
            return bank;
        }

        public async Task<List<Banks>> GetAll()
        {
            var banks = (List<Banks>) await _repository.GetAll();
            if (banks == null)
                return null;
            return banks;
        }

        public async Task Update(Banks bank, int id)
        {
           await _repository.Update(bank, id);
        }
    }
}

