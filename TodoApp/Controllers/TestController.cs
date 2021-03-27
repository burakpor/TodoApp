using Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TodoApp;
using TodoApp.Commands.SigningCommands;
using TodoApp.Models.BusinessModels;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : BaseApiController
    {
        public TestController(IComponentContext icocontext): base(icocontext)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            try
            {
                var command = new RegisterUserCommand();
                command.Data = new RegisterUserRequest { UserName = "burakpo",Password ="password",Email = "email@email.com" };
                var response = await Go(command);
                return response;
                //return Ok(context.TestTable.FirstOrDefault(a => a.Id == 1)?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
