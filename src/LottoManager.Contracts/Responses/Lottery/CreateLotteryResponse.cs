using LottoManager.Domain.Enums;

namespace LottoManager.Contracts.Responses.Lottery;

public class CreateLotteryResponse
{
    public required int Id { get; init; }
    
    public required string Name { get; init; }
    
    public required string Slug { get; init; }
}