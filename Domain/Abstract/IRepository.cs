using Atelier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Domain.Abstract
{
    public interface IRepository
    {
        IEnumerable<Players> GetAllPlayers();
        Players GetPlayerById(int Id);
        IEnumerable<Data> GetAllData();
        IEnumerable<Country> GetAllCountry();
    }
}
