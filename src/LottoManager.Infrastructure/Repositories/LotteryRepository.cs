using LottoManager.Domain.Interfaces;
using LottoManager.Domain.Models;
using LottoManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LottoManager.Infrastructure.Repositories;

public class LotteryRepository : ILotteryRepository
{
    private ApplicationDbContext _context;
    
    public LotteryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Lottery> CreateAsync(Lottery lottery, CancellationToken token = default)
    {
        await _context.Lottery.AddAsync(lottery, token);
        await _context.SaveChangesAsync(token);
        return lottery;
    }

    public async Task<Lottery?> GetBySlugAsync(string slug, CancellationToken token = default)
    {
        var lottery = await _context.Lottery.FirstOrDefaultAsync(lotto => lotto.Slug == slug, cancellationToken: token);
        return lottery;
    }
}