using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MabnaDBTest.Infra.Data.CoreContext;

public class CoreDBContextInjection
{
    public MAIN_MabnaDBContext _main_MabnaDBContext { get; }
    public READ_MabnaDBContext _read_MabnaDBContext { get; }
    public WRITE_MabnaDBContext _write_MabnaDBContext { get; }
    public CoreDBContextInjection(MAIN_MabnaDBContext main_MabnaDBContext, READ_MabnaDBContext read_MabnaDBContext,
        WRITE_MabnaDBContext write_MabnaDBContext)
    {
        _main_MabnaDBContext = main_MabnaDBContext;
        _read_MabnaDBContext = read_MabnaDBContext;
        _write_MabnaDBContext = write_MabnaDBContext;
    }
}

