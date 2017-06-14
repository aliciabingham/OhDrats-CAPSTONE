using OhDrats.DAL;
using OhDrats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OhDrats.Controllers
{
    [RoutePrefix ("api/gun")]
    public class GunController : ApiController
    {
        readonly IGunRepository _gunRepository;

        public GunController(IGunRepository gunRepository)
        {
            _gunRepository = gunRepository;
        }

        [HttpPost, Route]
        public HttpResponseMessage RegisterGun(Gun gun)
        {
            if (string.IsNullOrWhiteSpace(gun.GunName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            }

            _gunRepository.Save(gun);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
