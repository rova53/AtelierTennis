using Atelier.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Model
{
    public class StatisticsModel
    {
        public Country CountryGreatersRatio { get; set; }
        public string ImcMedianPlayers { get; set; }
        public string MedianSizePlayers { get; set; }
    }
}
