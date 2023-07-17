using MabnaDBTest.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MabnaDBTest.Domain.Entities;

/// <summary>
/// نماد های معاملاتی
/// </summary>
public class Instrument : BaseEntity<int>
{                
    /// <summary>
    /// عنوان
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// معاملات
    /// </summary>
    public List<Trade> Trade { get; set; }
}

public class InstrumentEntityTypeConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(255);

    }
}