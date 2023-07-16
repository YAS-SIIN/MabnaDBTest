

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
        services.AddDbContext<MAIN_MabnaDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:MAIN_ERPConnectionString"]));
        services.AddDbContext<READ_MabnaDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:READ_ERPConnectionString"]));
        services.AddDbContext<WRITE_MabnaDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:WRTIE_ERPConnectionString"]));
        //builder.Services.AddDbContext<MyDataBase>(options => options.UseInMemoryDatabase("MyDB"));           
        //services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<CoreDBContextInjection>();
    }

}
