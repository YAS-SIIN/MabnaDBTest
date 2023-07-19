

using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.CoreContext;
using MabnaDBTest.Infra.Data.UnitOfWork;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace MabnaDBTest.IoC;

public static class APIConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MAIN_MabnaDbContext>(options => options.UseSqlServer(configuration["ApplicationOptions:MAIN_MabnaDBConnectionString"]));
        services.AddDbContext<READ_MabnaDbContext>(options => options.UseSqlServer(configuration["ApplicationOptions:READ_MabnaDBConnectionString"]));
        services.AddDbContext<WRITE_MabnaDbContext>(options => options.UseSqlServer(configuration["ApplicationOptions:WRTIE_MabnaDBConnectionString"]));

        //services.AddDbContext<MAIN_MabnaDbContext>(options => options.UseInMemoryDatabase("MabnaDbContext"));
        //services.AddDbContext<READ_MabnaDbContext>(options => options.UseInMemoryDatabase("MabnaDbContext"));
        //services.AddDbContext<WRITE_MabnaDbContext>(options => options.UseInMemoryDatabase("MabnaDbContext")); 

        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<CoreDBContextInjection>();
    }

}
