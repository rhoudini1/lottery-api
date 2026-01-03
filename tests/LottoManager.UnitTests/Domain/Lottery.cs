using LottoManager.Domain.Models;
using Xunit;

namespace LottoManager.UnitTests.Domain;

public class LotteryTest
{
    [Fact]
    public void Name_Set_ShouldGenerateCorrectSlug()
    {
        var lottery = new Lottery
        {
            Name = "Mega-Sena",
            MaxNumber = 60,
            NumbersToDraw = 6,
            Id = 0
        };
        
        Assert.Equal("mega-sena", lottery.Slug);
    }

    [Theory]
    [InlineData("Lotofácil", "lotofacil")]
    [InlineData("Quina 5/80", "quina-580")]
    [InlineData("  Space  and  Dashes  ", "space-and-dashes")]
    [InlineData("Special@#Characters!", "specialcharacters")]
    [InlineData("Multiple---Dashes", "multiple-dashes")]
    [InlineData("Áéíóú Çãõ", "aeiou-cao")]
    public void Name_Set_WithComplexInputs_ShouldNormalizeSlug(string inputName, string expectedSlug)
    {
        var lottery = new Lottery
        {
            Name = inputName,
            MaxNumber = 10,
            NumbersToDraw = 1,
            Id = 0
        };
        
        Assert.Equal(expectedSlug, lottery.Slug);
    }

    [Fact]
    public void Name_Change_ShouldUpdateSlug()
    {
        var lottery = new Lottery
        {
            Name = "Old Name",
            MaxNumber = 10,
            NumbersToDraw = 1,
            Id = 0
        };
        
        lottery.Name = "New Name";
        
        Assert.Equal("new-name", lottery.Slug);
    }

    [Fact]
    public void Lottery_InitialState_ShouldHaveDefaultValues()
    {
        var lottery = new Lottery
        {
            Name = "Test",
            Id = 0
        };
        
        Assert.Equal(1, lottery.MinNumber);
        Assert.Empty(lottery.PrizeHits);
        Assert.NotNull(lottery.PrizeHits);
    }
}