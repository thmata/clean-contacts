using MediatR;

namespace Application.Auth.Commands.AuthenticateUser;

public record AuthenticateUserCommand(string Username, string Password) : IRequest<AuthenticateUserResponse>;
