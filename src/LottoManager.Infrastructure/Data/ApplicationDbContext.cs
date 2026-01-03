using System.Reflection;
using LottoManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LottoManager.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }
    
    public DbSet<Lottery> Lottery => Set<Lottery>();
    public DbSet<LotteryPrizeHit> LotteryPrizeHit => Set<LotteryPrizeHit>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}