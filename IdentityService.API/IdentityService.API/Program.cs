using Hellang.Middleware.ProblemDetails;
using IdentityService.Application.Interfaces;
using IdentityService.Application.Services;
using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.Data;
using IdentityService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var path = Directory.GetCurrentDirectory();

builder.Host.UseSerilog((ctx, Ic) => Ic.WriteTo.File($"{path}\\Logs\\Log.txt"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddProblemDetails(opt =>
{
    opt.IncludeExceptionDetails = (ctx,ex) =>
    {
        return builder.Environment.IsDevelopment() || builder.Environment.IsStaging();
    };
});

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddDbContext<UserContext>(options=> options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
