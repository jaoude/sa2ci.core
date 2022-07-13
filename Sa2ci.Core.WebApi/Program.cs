using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Dal.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Sa2ci.Core.Bll.Services;
using Sa2ci.Core.Bll;
using AutoMapper;
using Sa2ci.Core.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connecntionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Sa2ciCoreContext>(options => options.UseSqlServer(connecntionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BLLEntryPoint).Assembly);
builder.Services.AddTransient<IMembersService, MembersService>();
builder.Services.AddMediatR(typeof(BLLEntryPoint).Assembly);

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
