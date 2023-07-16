using MabnaDBTest.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MabnaDBTest.Domain.Entities;

public class Instrument : BaseEntity<int>
{                                           
    public string Name { get; set; }
}

public class InstrumentEntityTypeConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.Property(b => b.Name).IsRequired().HasMaxLength(255);    

    }
}