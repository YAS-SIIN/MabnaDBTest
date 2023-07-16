using MabnaDBTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MabnaDBTest.Infra.Data.Context;

public class MabnaDBContext : DbContext
{
    public MabnaDBContext(DbContextOptions options) : base(options)
    {
    }
    #region Trade    
    public DbSet<Trade> Trades { get; set; }
    #endregion
               
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {          
        #region Trade 
        new TradeEntityTypeConfiguration().Configure(modelBuilder.Entity<Trade>());
        #endregion
        modelBuilder.Entity<Trade>().Property(x => x.Id).UseHiLo("Trade_Hilo");
                         
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MabnaDBContext).Assembly); base.OnModelCreating(modelBuilder);
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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