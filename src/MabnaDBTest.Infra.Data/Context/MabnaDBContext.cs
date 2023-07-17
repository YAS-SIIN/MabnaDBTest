using MabnaDBTest.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace MabnaDBTest.Infra.Data.Context;

public class MabnaDbContext : DbContext
{
    public MabnaDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Trade> Trades { get; set; }
    public DbSet<Instrument> Instruments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new TradeEntityTypeConfiguration().Configure(modelBuilder.Entity<Trade>());
        new InstrumentEntityTypeConfiguration().Configure(modelBuilder.Entity<Instrument>());

        //modelBuilder.Entity<Trade>().Property(x => x.Id).UseHiLo("Trade_Hilo");
        //modelBuilder.Entity<Instrument>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MabnaDbContext).Assembly); base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Created") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDateTime").CurrentValue = DateTime.Now;
                continue;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDateTime").IsModified = false;
                entry.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}