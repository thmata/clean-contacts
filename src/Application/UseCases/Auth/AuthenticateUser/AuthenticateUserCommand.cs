using Application.UseCases.Auth.AuthenticateUser;
using MediatR;

public record AuthenticateUserCommand(string Username, string Password) : IRequest<AuthenticateUserResponse>;
