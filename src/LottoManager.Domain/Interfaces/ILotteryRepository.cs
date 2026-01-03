using LottoManager.Domain.Models;

namespace LottoManager.Domain.Interfaces;

public interface ILotteryRepository
{
    Task<Lottery> CreateAsync(Lottery lottery, CancellationToken token = default);
    
    Task<Lottery?> GetBySlugAsync(string slug, CancellationToken token = default);
}