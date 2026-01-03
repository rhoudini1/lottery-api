using LottoManager.Contracts.Requests.Lottery;
using LottoManager.Contracts.Responses.Lottery;
using LottoManager.Domain.Models;

namespace LottoManager.Api.Mapping;

public static class LotteryContractMapping
{
    public static Lottery MapToLottery(this CreateLotteryRequest request)
    {
        return new Lottery
        {
            Id = 0,
            Name = request.Name,
            MinNumber = request.MinNumber,
            MaxNumber = request.MaxNumber,
            NumbersToDraw = request.NumbersToDraw,
            SingleBetPrice = request.SingleBetPrice,
            MaxBetNumberAmount = request.MaxBetNumberAmount,
            PrizeHits = request.PrizeHits.Select(x => new LotteryPrizeHit
                {
                    HitNumbers = x.HitNumbers,
                    Type = x.Type,
                    Amount = x.Amount,
                    Id = 0,
                })
                .ToList()
        };
    }

    public static CreateLotteryResponse MapToCreateResponse(this Lottery lottery)
    {
        return new CreateLotteryResponse
        {
            Id = lottery.Id,
            Name = lottery.Name,
            Slug = lottery.Slug,
        };
    }
}