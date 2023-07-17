using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabnaDBTest.Infra.Data.CoreContext;

public class CoreDBContextInjection
{
    public MAIN_MabnaDbContext _main_MabnaDBContext { get; }
    public READ_MabnaDbContext _read_MabnaDBContext { get; }
    public WRITE_MabnaDbContext _write_MabnaDBContext { get; }
    public CoreDBContextInjection(MAIN_MabnaDbContext main_MabnaDBContext, READ_MabnaDbContext read_MabnaDBContext,
        WRITE_MabnaDbContext write_MabnaDBContext)
    {
        _main_MabnaDBContext = main_MabnaDBContext;
        _read_MabnaDBContext = read_MabnaDBContext;
        _write_MabnaDBContext = write_MabnaDBContext;
    }
}

