using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TodoApp;

namespace TodoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppcentTodoContext context;

        public TestController(AppcentTodoContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.TestTable.FirstOrDefault(a => a.Id == 1)?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
