using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests.Domain.Entities;

public class ContactTests
{
    private readonly Guid _userId = Guid.NewGuid();

    [Fact]
    public void Constructor_WithValidParameters_ShouldCreateContact()
    {
        // Arrange
        var name = "João Silva";
        var email = "joao@email.com";
        var phone = "11987654321";

        // Act
        var contact = new Contact(_userId, name, email, phone);

        // Assert
        contact.UserId.Should().Be(_userId);
        contact.Name.Should().Be(name);
        contact.Email.Should().Be(email);
        contact.Phone.Should().Be(phone);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("A")]
    public void Constructor_WithInvalidName_ShouldThrowArgumentException(string invalidName)
    {
        // Arrange
        var email = "joao@email.com";
        var phone = "11987654321";

        // Act
        var act = () => new Contact(_userId, invalidName, email, phone);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Nome*");
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("invalidemail")]
    public void Constructor_WithInvalidEmail_ShouldThrowArgumentException(string invalidEmail)
    {
        // Arrange
        var name = "João Silva";
        var phone = "11987654321";

        // Act
        var act = () => new Contact(_userId, name, invalidEmail, phone);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Email*");
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("123456789")]
    [InlineData("123456789012")]
    public void Constructor_WithInvalidPhone_ShouldThrowArgumentException(string invalidPhone)
    {
        // Arrange
        var name = "João Silva";
        var email = "joao@email.com";

        // Act
        var act = () => new Contact(_userId, name, email, invalidPhone);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("11987654321")]
    [InlineData("1198765432")]
    [InlineData("21987654321")]
    [InlineData("85987654321")]
    public void Constructor_WithValidPhones_ShouldCreateContact(string validPhone)
    {
        // Arrange
        var name = "João Silva";
        var email = "joao@email.com";

        // Act
        var contact = new Contact(_userId, name, email, validPhone);

        // Assert
        contact.Phone.Should().Be(validPhone);
    }

    [Fact]
    public void UpdateName_WithValidName_ShouldUpdateName()
    {
        // Arrange
        var contact = new Contact(_userId, "Nome Original", "email@email.com", "11987654321");
        var newName = "Nome Atualizado";

        // Act
        contact.UpdateName(newName);

        // Assert
        contact.Name.Should().Be(newName);
    }

    [Fact]
    public void UpdateEmail_WithValidEmail_ShouldUpdateEmail()
    {
        // Arrange
        var contact = new Contact(_userId, "João Silva", "original@email.com", "11987654321");
        var newEmail = "novo@email.com";

        // Act
        contact.UpdateEmail(newEmail);

        // Assert
        contact.Email.Should().Be(newEmail);
    }

    [Fact]
    public void UpdatePhone_WithValidPhone_ShouldUpdatePhone()
    {
        // Arrange
        var contact = new Contact(_userId, "João Silva", "email@email.com", "11987654321");
        var newPhone = "21987654321";

        // Act
        contact.UpdatePhone(newPhone);

        // Assert
        contact.Phone.Should().Be(newPhone);
    }

    [Fact]
    public void Update_WithValidParameters_ShouldUpdateAllFields()
    {
        // Arrange
        var contact = new Contact(_userId, "Nome Original", "original@email.com", "11987654321");
        var newName = "Nome Atualizado";
        var newEmail = "novo@email.com";
        var newPhone = "21987654321";

        // Act
        contact.Update(newName, newEmail, newPhone);

        // Assert
        contact.Name.Should().Be(newName);
        contact.Email.Should().Be(newEmail);
        contact.Phone.Should().Be(newPhone);
    }
}
