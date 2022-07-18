using Atelier.Domain.Abstract;
using Atelier.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Domain.Concrete
{
    public class AtelierRepos : IRepository
    {
        private readonly AtelierDbContext _context;

        public AtelierRepos(AtelierDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Players> GetAllPlayers()
        {
            return _context.Players.Include(p => p.COUNTRY).Include(p=>p.DATA).OrderBy( p => p.DATA.RANK);
        }
        public IEnumerable<Data> GetAllData() => _context.Data;

        public IEnumerable<Country> GetAllCountry() => _context.Country;

        public Players GetPlayerById(int Id) => _context.Players.Include(p => p.COUNTRY).Include(p => p.DATA).FirstOrDefault(p=>p.ID ==Id);
        
    }
}
