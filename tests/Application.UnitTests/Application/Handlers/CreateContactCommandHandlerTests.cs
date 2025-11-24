using Application.Interfaces;
using Application.UseCases.Contacts.CreateContact;
using DomainEntities = Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace Application.UnitTests.Application.Handlers;

public class CreateContactCommandHandlerTests
{
    private readonly Mock<IContactRepository> _contactRepositoryMock;
    private readonly CreateContactCommandHandler _handler;

    public CreateContactCommandHandlerTests()
    {
        _contactRepositoryMock = new Mock<IContactRepository>();
        _handler = new CreateContactCommandHandler(_contactRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_WithValidCommand_ShouldCreateContactAndReturnResponse()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var command = new CreateContactCommand(
            UserId: userId,
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        _contactRepositoryMock
            .Setup(x => x.AddAsync(It.IsAny<DomainEntities.Contact>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((DomainEntities.Contact contact, CancellationToken _) => contact);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.UserId.Should().Be(userId);
        result.Name.Should().Be("João Silva");
        result.Email.Should().Be("joao@email.com");
        result.Phone.Should().Be("11987654321");
        result.Id.Should().NotBeEmpty();
        result.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));

        _contactRepositoryMock.Verify(
            x => x.AddAsync(It.Is<DomainEntities.Contact>(c =>
                c.UserId == userId &&
                c.Name == "João Silva" &&
                c.Email == "joao@email.com" &&
                c.Phone == "11987654321"
            ), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }

    [Fact]
    public async Task Handle_WithInvalidName_ShouldThrowArgumentException()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "",
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*Nome*");

        _contactRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<DomainEntities.Contact>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task Handle_WithInvalidEmail_ShouldThrowArgumentException()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "invalidemail",
            Phone: "11987654321"
        );

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*Email*");

        _contactRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<DomainEntities.Contact>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task Handle_WithInvalidPhone_ShouldThrowArgumentException()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: "123"
        );

        // Act
        var act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ArgumentException>()
            .WithMessage("*Telefone*");

        _contactRepositoryMock.Verify(
            x => x.AddAsync(It.IsAny<DomainEntities.Contact>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }
}
