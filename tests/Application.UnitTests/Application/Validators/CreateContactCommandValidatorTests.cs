using Application.UseCases.Contacts.CreateContact;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace Application.UnitTests.Application.Validators;

public class CreateContactCommandValidatorTests
{
    private readonly CreateContactCommandValidator _validator;

    public CreateContactCommandValidatorTests()
    {
        _validator = new CreateContactCommandValidator();
    }

    [Fact]
    public void Validate_WithValidCommand_ShouldNotHaveValidationErrors()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Validate_WithInvalidName_ShouldHaveValidationError(string? invalidName)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: invalidName!,
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void Validate_WithNameTooShort_ShouldHaveValidationError()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "A",
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Nome deve ter no mínimo 2 caracteres.");
    }

    [Fact]
    public void Validate_WithNameTooLong_ShouldHaveValidationError()
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: new string('A', 101),
            Email: "joao@email.com",
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name)
            .WithErrorMessage("Nome deve ter no máximo 100 caracteres.");
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Validate_WithInvalidEmail_ShouldHaveValidationError(string? invalidEmail)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: invalidEmail!,
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("invalidemail")]
    [InlineData("invalid@")]
    [InlineData("@invalid.com")]
    public void Validate_WithInvalidEmailFormat_ShouldHaveValidationError(string invalidEmail)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: invalidEmail,
            Phone: "11987654321"
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public void Validate_WithInvalidPhone_ShouldHaveValidationError(string? invalidPhone)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: invalidPhone!
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone);
    }

    [Theory]
    [InlineData("123456789")]
    [InlineData("123456789012")]
    [InlineData("10987654321")]
    [InlineData("00987654321")]
    public void Validate_WithInvalidPhoneFormat_ShouldHaveValidationError(string invalidPhone)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: invalidPhone
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Phone);
    }

    [Theory]
    [InlineData("11987654321")]
    [InlineData("1198765432")]
    [InlineData("21987654321")]
    [InlineData("85987654321")]
    public void Validate_WithValidPhones_ShouldNotHaveValidationError(string validPhone)
    {
        // Arrange
        var command = new CreateContactCommand(
            UserId: Guid.NewGuid(),
            Name: "João Silva",
            Email: "joao@email.com",
            Phone: validPhone
        );

        // Act
        var result = _validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Phone);
    }
}
