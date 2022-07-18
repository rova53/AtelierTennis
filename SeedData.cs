using Atelier.Domain.Concrete;
using Atelier.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier
{
    public static class SeedData
    {
        public static void InitData(AtelierDbContext context, string data) 
        {
            PlayersModel player = JsonConvert.DeserializeObject<PlayersModel>(data);

            if (!context.Players.Any() && player != null) 
            {
                player.players.ForEach((pl)=> 
                {
                    pl.ID_COUNTRY = pl.COUNTRY.ID;
                    pl.ID_DATA = pl.DATA.ID;
                });
                context.Players.AddRange(player.players);
                context.SaveChanges();
            }
        }
    }
}
