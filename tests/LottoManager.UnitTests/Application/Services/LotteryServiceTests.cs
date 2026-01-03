using Moq;
using Xunit;
using FluentValidation;
using LottoManager.Application.Services;
using LottoManager.Domain.Interfaces;
using LottoManager.Domain.Models;
using FluentValidation.Results;

namespace LottoManager.UnitTests.Application.Services;

public class LotteryServiceTests
{
    private readonly Mock<ILotteryRepository> _repositoryMock;
    private readonly Mock<IValidator<Lottery>> _validatorMock;
    private readonly LotteryService _service;
    
    public LotteryServiceTests()
    {
        _repositoryMock = new Mock<ILotteryRepository>();
        _validatorMock = new Mock<IValidator<Lottery>>();
        
        _service = new LotteryService(_repositoryMock.Object, _validatorMock.Object);
    }
    
    [Fact]
    public async Task CreateAsync_WhenValidationPasses_ShouldCallRepositoryAndReturnLottery()
    {
        var lottery = new Lottery
        {
            Name = "Mega-Sena",
            Id = 0
        };
        
        _validatorMock.Setup(v => v.ValidateAsync(
                It.IsAny<ValidationContext<Lottery>>(), 
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        _repositoryMock.Setup(r => r.CreateAsync(lottery, It.IsAny<CancellationToken>()))
            .ReturnsAsync(lottery);
        
        var result = await _service.CreateAsync(lottery);
        
        Assert.NotNull(result);
        Assert.Equal(lottery.Name, result.Name);
        
        _repositoryMock.Verify(r => r.CreateAsync(lottery, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task CreateAsync_WhenValidationFails_ShouldThrowValidationException()
    {
        var lottery = new Lottery
        {
            Name = "",
            Id = 0
        }; 
        var failures = new List<ValidationFailure> 
        { 
            new ValidationFailure("Name", "Name is required") 
        };
        
        _validatorMock.Setup(v => v.ValidateAsync(
                It.IsAny<ValidationContext<Lottery>>(), 
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new ValidationException(failures));
        
        await Assert.ThrowsAsync<ValidationException>(() => _service.CreateAsync(lottery));
        
        _repositoryMock.Verify(r => r.CreateAsync(
                It.IsAny<Lottery>(), 
                It.IsAny<CancellationToken>()), 
            Times.Never);
    }
}