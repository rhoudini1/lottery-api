using FluentValidation;
using LottoManager.Domain.Interfaces;
using LottoManager.Domain.Models;

namespace LottoManager.Application.Validators;

public class LotteryValidator : AbstractValidator<Lottery>
{
    private readonly ILotteryRepository _lotteryRepository;

    public LotteryValidator(ILotteryRepository lotteryRepository)
    {
        _lotteryRepository = lotteryRepository;

        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.MinNumber).GreaterThan((byte)0);
        RuleFor(x => x.MaxNumber).InclusiveBetween((byte)1, (byte)100);
        RuleFor(x => x.NumbersToDraw).GreaterThan((byte)0);
        RuleFor(x => x.MaxBetNumberAmount).InclusiveBetween((byte)1, (byte)100).GreaterThan(x => x.NumbersToDraw);
        RuleFor(x => x.Slug).MustAsync(CheckExistingSlug).WithMessage("This lottery already exists.");
        RuleFor(x => x.SingleBetPrice).GreaterThan((ushort)0);
    }

    private async Task<bool> CheckExistingSlug(string slug, CancellationToken token = default)
    {
        var existingLottery = await _lotteryRepository.GetBySlugAsync(slug, token);

        return existingLottery is null;
    }
}