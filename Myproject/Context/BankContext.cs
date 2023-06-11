using System;
using Microsoft.EntityFrameworkCore;
using Myproject.Models;

namespace Myproject.Context
{
	public class BankContext:DbContext
	{
        public BankContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
  => options.UseSqlServer("Server=.;Database=Freshdatabase;User=sa;Password=Giorgi1999;TrustServerCertificate=True");

        public BankContext(DbContextOptions<BankContext> option)
              : base(option)
        {

        }

        public DbSet<Banks> Banks { get; set; }
        public DbSet<ContactPerson> ContactPerson { get; set; }
        public DbSet<Director> Directors { get; set; }

    }
}

