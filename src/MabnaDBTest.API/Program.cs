using MabnaDBTest.API;
using MabnaDBTest.Application;
using MabnaDBTest.Application.UseCases.Instrument.Queries;
using MabnaDBTest.Common.Common.Behaviours;
using MabnaDBTest.Domain.DTOs;
using MabnaDBTest.Domain.DTOs.Instrument;
using MabnaDBTest.Domain.Interfaces.UnitOfWork;
using MabnaDBTest.Infra.Data.UnitOfWork;
using MabnaDBTest.IoC;
using MediatR;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Register(builder.Configuration);
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MabnaDBTest.Application.InjectMediatR).GetTypeInfo().Assembly)); 
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UnhandledExceptionBehaviour<,>).GetTypeInfo().Assembly)); 
var assembly = AppDomain.CurrentDomain.Load("MabnaDBTest.Application");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTradeResponse).GetTypeInfo().Assembly));  
 
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
 
var app = builder.Build();


//ایجاد داده های فرضی در جدول نماد ها
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IUnitOfWork>();
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
