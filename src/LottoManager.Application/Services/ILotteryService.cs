using LottoManager.Domain.Models;

namespace LottoManager.Application.Services;

public interface ILotteryService
{
    Task<Lottery> CreateAsync(Lottery lottery, CancellationToken token = default);
}