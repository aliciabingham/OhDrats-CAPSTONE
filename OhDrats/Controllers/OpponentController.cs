using OhDrats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OhDrats.Controllers
{
    [RoutePrefix("api/opponent")]
    public class OpponentController : ApiController
    {
    
            readonly IOpponentRepository _opponentRepository;

            public OpponentController(IOpponentRepository opponentRepository)
            {
                _opponentRepository = opponentRepository;
            }

            [HttpPost, Route]
            public HttpResponseMessage RegisterOpponent(Opponent opponent)
            {
                if (string.IsNullOrWhiteSpace(opponent.Name))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
                }

                _opponentRepository.Save(opponent);

                return Request.CreateResponse(HttpStatusCode.OK);
            }

        [HttpGet, Route]
        public HttpResponseMessage GetOpponent(Opponent existentOpponent)
        {
            _opponentRepository.Get(existentOpponent);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

            //[HttpGet, Route]
            //public HttpResponseMessage GetAll()
            //{
            //    var customers = _opponentRepository.GetAll();

            //    return Request.CreateResponse(HttpStatusCode.OK, customers);
            //}
        }
    }
