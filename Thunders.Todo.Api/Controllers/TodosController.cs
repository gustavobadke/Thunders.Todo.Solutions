using Microsoft.AspNetCore.Mvc;
using Thunders.Todo.Core.UseCases;
using Thunders.Todo.Core.UseCases.Dtos;

namespace Thunders.Todo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> ListAsync([FromServices] ListTodoUseCase useCase)
        {
            try
            {
                var todos = await useCase.ExecuteAsync();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromServices] CreateTodoUseCase useCase, [FromBody] CreateTodoItemInput dto)
        {
            try
            {
                await useCase.ExecuteAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAsync([FromServices] UpdateTodoUseCase useCase, UpdateTodoItemInput dto)
        {
            try
            {
                await useCase.ExecuteAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromServices] DeleteTodoUseCase useCase, long id)
        {
            try
            {
                await useCase.ExecuteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}