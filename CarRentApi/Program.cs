using Autofac.Extensions.DependencyInjection;
using Autofac;
using BusinessLayer.DependencyResolvers.Autofac;
using DataAccessLayer.Mappers.AutoMapper;
using CoreLayer.Utilities.IoC;
using CoreLayer.DependencyResolvers;
using CoreLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(DtoMapper));

builder.Services.AddDependencyResolvers(new ICoreModule[] // Burada ÝcoreModule edirik ki sabahsý gün baþqa module yarada bil?rik
{
    new CoreModule()
}); ;

var app = builder.Build();

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
