using MabnaDBTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace MabnaDBTest.Infra.Data.CoreContext;

public class MAIN_MabnaDbContext : MabnaDbContext
{
    public MAIN_MabnaDbContext(DbContextOptions<MAIN_MabnaDbContext> options) : base(options)
    {
    }
}

public class READ_MabnaDbContext : MabnaDbContext
{
    public READ_MabnaDbContext(DbContextOptions<READ_MabnaDbContext> options) : base(options)
    {
    }
}

public class WRITE_MabnaDbContext : MabnaDbContext
{
    public WRITE_MabnaDbContext(DbContextOptions<WRITE_MabnaDbContext> options) : base(options)
    {
    }
}
