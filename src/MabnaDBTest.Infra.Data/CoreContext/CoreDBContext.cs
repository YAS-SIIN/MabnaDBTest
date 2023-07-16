using MabnaDBTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace MabnaDBTest.Infra.Data.CoreContext;

public class MAIN_MabnaDBContext : MabnaDBContext
{
    public MAIN_MabnaDBContext(DbContextOptions<MAIN_MabnaDBContext> options) : base(options)
    {
    }
}

public class READ_MabnaDBContext : MabnaDBContext
{
    public READ_MabnaDBContext(DbContextOptions<READ_MabnaDBContext> options) : base(options)
    {
    }
}

public class WRITE_MabnaDBContext : MabnaDBContext
{
    public WRITE_MabnaDBContext(DbContextOptions<WRITE_MabnaDBContext> options) : base(options)
    {
    }
}
