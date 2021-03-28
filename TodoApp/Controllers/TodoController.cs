using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApp.Commands;
using TodoApp.Commands.SigningCommands;
using TodoApp.Commands.TodoCommands;
using TodoApp.Helpers;
using TodoApp.Models.BusinessModels;
using TodoApp.Models.Dtos;

namespace TodoApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : BaseApiController
    {
        private readonly IMapper _mapper;
        public TodoController(IComponentContext icocontext, IMapper mapper) : base(icocontext)
        {
            _mapper = mapper;
        }

        [HttpPost(nameof(AddTodo))]
        public async Task<ActionResult> AddTodo([FromBody] AddTodoDto viewRequest)
        {
            if (!TryValidateModel(viewRequest))
            {
                return BadRequest(ValidationHelper.GetModelErrors(ModelState));
            }

            var request = this._mapper.Map<AddTodoRequest>(viewRequest);
            request.UserName = HttpContext.User.Identity.Name;
            var command = new AddTodoCommand {
                Data = request
            };
            return await Go(command);
        }
    }
}
