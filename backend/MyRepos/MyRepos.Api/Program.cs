using MyRepos.Api;
using MyRepos.Api.Common.Mapping;
using MyRepos.Application;
using MyRepos.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

app.UseCors("AllowFrontend");
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
