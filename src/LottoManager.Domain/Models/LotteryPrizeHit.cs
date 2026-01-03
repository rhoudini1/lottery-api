using LottoManager.Domain.Common;
using LottoManager.Domain.Enums;

namespace LottoManager.Domain.Models;

public class LotteryPrizeHit : BaseEntity
{
    public byte HitNumbers { get; set; }
    
    public LotteryPrizeType Type { get; set; }
    
    public decimal Amount { get; set; }
    
    public Lottery Lottery { get; set; }
}

