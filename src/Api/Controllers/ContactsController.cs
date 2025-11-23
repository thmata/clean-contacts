using Api.Dtos;
using Application.UseCases.Contacts.CreateContact;
using Application.UseCases.Contacts.DeleteContact;
using Application.UseCases.Contacts.GetContacts;
using Application.UseCases.Contacts.UpdateContact;
using Application.UseCases.Contacts.GetContactById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/contacts")]
public class ContactsController : BaseApiController
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var query = new GetContactsQuery(UserId, page, pageSize);
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
