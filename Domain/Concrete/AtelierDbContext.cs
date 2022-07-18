using Atelier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Domain.Concrete
{
    public class AtelierDbContext : DbContext
    {
        public AtelierDbContext(DbContextOptions<AtelierDbContext> options) : base(options)
        {
        }
        public DbSet<Players> Players { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Data> Data { get; set; }
    }
}
