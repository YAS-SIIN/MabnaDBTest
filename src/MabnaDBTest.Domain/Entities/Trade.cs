using MabnaDBTest.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MabnaDBTest.Domain.Entities;

public class Trade : BaseEntity<int>
{
    public DateTime DateEn { get; set; }    
    public Decimal Open { get; set; }    
    public Decimal High { get; set; }    
    public Decimal Low { get; set; }    
    public Decimal Close { get; set; }    
}

public class TradeEntityTypeConfiguration : IEntityTypeConfiguration<Trade>
{
    public void Configure(EntityTypeBuilder<Trade> builder)
    {
        builder.Property(b => b.Open).IsRequired().HasPrecision(19, 4);
        builder.Property(b => b.High).IsRequired().HasPrecision(19, 4);    
        builder.Property(b => b.Low).IsRequired().HasPrecision(19, 4);
        builder.Property(b => b.Close).IsRequired().HasPrecision(19, 4);   
    }
}