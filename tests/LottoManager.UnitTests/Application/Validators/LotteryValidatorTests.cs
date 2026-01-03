using Moq;
using FluentValidation.TestHelper;
using LottoManager.Application.Validators;
using LottoManager.Domain.Interfaces;
using LottoManager.Domain.Models;

namespace LottoManager.UnitTests.Application.Validators;

public class LotteryValidatorTests
{
    private readonly Mock<ILotteryRepository> _repositoryMock;
    private readonly LotteryValidator _validator;

    public LotteryValidatorTests()
    {
        _repositoryMock = new Mock<ILotteryRepository>();
        _validator = new LotteryValidator(_repositoryMock.Object);
    }

    [Fact]
    public async Task Should_Have_Error_When_Name_Is_Empty()
    {
        var model = new Lottery
        {
            Name = "",
            Id = 0
        };
        
        var result = await _validator.TestValidateAsync(model);
        
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_Have_Error_When_MaxBetNumberAmount_Is_Less_Than_NumbersToDraw()
    {
        var model = new Lottery
        {
            Name = "Mega-Sena",
            NumbersToDraw = 10,
            MaxBetNumberAmount = 6,
            Id = 0
        };
        
        var result = await _validator.TestValidateAsync(model);
        
        result.ShouldHaveValidationErrorFor(x => x.MaxBetNumberAmount);
    }

    [Fact]
    public async Task Should_Have_Error_When_Slug_Already_Exists()
    {
        var model = new Lottery
        {
            Name = "Existing Game",
            Id = 0
        };
        
        // Mock the repository to return an existing lottery (simulating a duplicate)
        _repositoryMock.Setup(r => r.GetBySlugAsync(It.IsAny<string>(), default))
            .ReturnsAsync(new Lottery
            {
                Name = "Existing Game",
                Id = 0
            });
        
        var result = await _validator.TestValidateAsync(model);
        
        result.ShouldHaveValidationErrorFor(x => x.Slug)
              .WithErrorMessage("This lottery already exists.");
    }

    [Fact]
    public async Task Should_Not_Have_Any_Errors_When_Model_Is_Valid()
    {
        var model = new Lottery
        {
            Name = "Valid Game",
            MinNumber = 1,
            MaxNumber = 60,
            NumbersToDraw = 6,
            MaxBetNumberAmount = 15,
            SingleBetPrice = 500,
            Id = 0
        };

        _repositoryMock.Setup(r => r.GetBySlugAsync(It.IsAny<string>(), default))
            .ReturnsAsync((Lottery?)null);
        
        var result = await _validator.TestValidateAsync(model);
        
        result.ShouldNotHaveAnyValidationErrors();
    }
}