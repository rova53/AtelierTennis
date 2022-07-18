using Atelier.Domain.Abstract;
using Atelier.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IRepository repo;
        public PlayersController(IRepository repository)
        {
            repo = repository;
        }
        [HttpGet, Route("GetAll")]
        public IActionResult GetAll() 
        {
            var result = repo.GetAllPlayers()?.ToList();
            if (result != null) 
            {
                return Ok(result);
            }
            return null;
        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id) 
        {
            var result = repo.GetPlayerById(Id);
            if (result != null) 
            {
                return Ok(result);
            }

            return null;
        }
        [HttpGet, Route("GetStatistics")]
        public IActionResult GetStatistics() 
        {
            StatisticsModel statModel = new StatisticsModel();
            var playersList = repo.GetAllPlayers();
            int playerListCount = playersList?.Count()??0;
            if (playerListCount > 0)
            {
                /****************************** Greates ratio **************************************/
                statModel.CountryGreatersRatio = playersList.GroupBy( c=>c.ID_COUNTRY)
                                            .Select(s => new { ratio = s.Sum(d=>d.DATA.POINTS) / s.Count(), Country = s?.FirstOrDefault()?.COUNTRY })
                                            .OrderByDescending( o => o.ratio)
                                            .FirstOrDefault()?.Country;
                /********************************* IMC moyens de tout les joueurs ************************************/
                double sommeImc = playersList.Sum(p => { 
                    if(p.DATA != null && p.DATA.HEIGHT > 0)
                        return p.DATA.WEIGHT / p.DATA.HEIGHT;
                    return 0d;
                });
                double medianImc = sommeImc / (double)playerListCount;
                statModel.ImcMedianPlayers = medianImc.ToString();
                /******************************** Median Taille *************************************/
                double Tailles = playersList.Sum(p => p.DATA.HEIGHT);
                double MedianTaille = Tailles / (double)playerListCount;
                statModel.MedianSizePlayers = MedianTaille.ToString();
            }
            if(statModel != null)
                return Ok(statModel);
            return null;
        }
    }
}
