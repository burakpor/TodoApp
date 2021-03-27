using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models.BusinessModels;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        public UserController(IComponentContext icocontext) : base(icocontext)
        {
        }

        [HttpPost]
        public ActionResult Register([FromBody]RegisterUserRequest request)
        {

            return Ok();
        }
    }
}
