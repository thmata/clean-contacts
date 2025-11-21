using Api.Dtos;
using Application.Contacts.Commands.CreateContact;
using Application.Contacts.Commands.DeleteContact;
using Application.Contacts.Commands.UpdateContact;
using Application.Contacts.Queries.GetContactById;
using Application.Contacts.Queries.GetContacts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
public class ContactsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts(CancellationToken cancellationToken)
    {
        var query = new GetContactsQuery(UserId);
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetContactByIdQuery(id, UserId);
        var response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateContactCommand(UserId, request.Name, request.Email, request.Phone);
        var response = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetContactById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(Guid id, [FromBody] UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateContactCommand(id, UserId, request.Name, request.Email, request.Phone);
        var response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteContactCommand(id, UserId);
        await _mediator.Send(command, cancellationToken);
        return NoContent();
    }
}
