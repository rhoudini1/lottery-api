using LottoManager.Domain.Enums;

namespace LottoManager.Contracts.Requests.Lottery;

public class CreateLotteryRequest
{
    public required string Name { get; init; }

    public byte MinNumber { get; init; } = 1;

    public required byte MaxNumber { get; init; }

    public required byte NumbersToDraw { get; init; }
    
    public required ushort SingleBetPrice { get; init; }
    
    public required byte MaxBetNumberAmount  { get; init; }

    public List<PrizeHit> PrizeHits { get; init; } = [];
}

public record PrizeHit(byte HitNumbers, LotteryPrizeType Type, decimal Amount);