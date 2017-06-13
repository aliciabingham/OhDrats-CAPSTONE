
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OhDrats.DAL;
using OhDrats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApplication3;

namespace OhDrats.Controllers
{
    [RoutePrefix("api/battle")]
    public class BattleController : ApiController
    {
            readonly IBattleRepository _battleRepository;

            public BattleController(IBattleRepository battleRepository)
            {
                _battleRepository = battleRepository;
            }

            [HttpPost, Route]
            public HttpResponseMessage RegisterBattle(Battle battle)
            {

             battle.UserId = HttpContext.Current.User.Identity.GetUserId();


            if (string.IsNullOrWhiteSpace(battle.OpponentName))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Opponent Name");
                }

                _battleRepository.Save(battle);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
        
        [HttpGet]
        [Route("battlehistory")]
        public IHttpActionResult GetUserBattles()
        {
            var user = HttpContext.Current.User.Identity.GetUserId();

            if (string.IsNullOrWhiteSpace(user))
            {
                return BadRequest("Invalid User ID");
                
            }

            var allUserBattles = _battleRepository.GetAll(user);

            return Ok(allUserBattles);
        }


    }
}
