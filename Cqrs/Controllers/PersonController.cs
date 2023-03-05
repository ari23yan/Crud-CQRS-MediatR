using Cqrs.PersonFeatures.Command.Add.CreatePersonCommand;
using Cqrs.PersonFeatures.Command.Delete.DeletePersonByIdCommand;
using Cqrs.PersonFeatures.Command.Edit.UpdatePersonCommand;
using Cqrs.PersonFeatures.Queries.FindPersonById;
using Cqrs.PersonFeatures.Queries.GetPersonList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddPersonCommandModel command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllPersonQueryModel()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await mediator.Send(new GetPersonByIdQueryModel { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await mediator.Send(new DeletePersonCommandModel { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, EditPersonCommandModel command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await mediator.Send(command));
        }

    }
}
