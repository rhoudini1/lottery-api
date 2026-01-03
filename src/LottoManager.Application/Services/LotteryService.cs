using FluentValidation;
using LottoManager.Domain.Interfaces;
using LottoManager.Domain.Models;

namespace LottoManager.Application.Services;

public class LotteryService : ILotteryService
{
    private readonly ILotteryRepository _lotteryRepository;
    private readonly IValidator<Lottery> _lotteryValidator;

    public LotteryService(ILotteryRepository lotteryRepository, IValidator<Lottery> lotteryValidator)
    {
        _lotteryRepository = lotteryRepository;
        _lotteryValidator = lotteryValidator;
    }

    public async Task<Lottery> CreateAsync(Lottery lottery, CancellationToken token = default)
    {
        await _lotteryValidator.ValidateAndThrowAsync(lottery, cancellationToken: token);
        var result = await _lotteryRepository.CreateAsync(lottery, token);
        return result;
    }
}