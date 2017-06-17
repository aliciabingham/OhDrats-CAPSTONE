using Microsoft.AspNet.Identity;
using OhDrats.DAL;
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

            gun.UserId = HttpContext.Current.User.Identity.GetUserId();

            if (string.IsNullOrWhiteSpace(gun.GunName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            }

            _gunRepository.Save(gun);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("gunhistory")]
        public IHttpActionResult GetUserGuns()
        {
            var user = HttpContext.Current.User.Identity.GetUserId();

            if (string.IsNullOrWhiteSpace(user))
            {
                return BadRequest("Invalid User ID");

            }

            var allUserGuns = _gunRepository.GetAll(user);

            return Ok(allUserGuns);
        }
    }
}
