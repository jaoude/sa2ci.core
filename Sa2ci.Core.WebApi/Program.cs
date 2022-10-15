using Microsoft.EntityFrameworkCore;
using Sa2ci.Core.Dal.Data;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Sa2ci.Core.Bll;
using AutoMapper;
using Sa2ci.Core.WebApi.Controllers;
using Sa2ci.Core.Bll.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connecntionString = builder.Configuration.GetConnectionString("DefaultConnection");
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddDbContext<Sa2ciCoreContext>(options => options.UseSqlServer(connecntionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(BLLEntryPoint).Assembly);
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddMediatR(typeof(BLLEntryPoint).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080", "http://localhost:8081", "http://10.0.0.245:8080/");
                      });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Use the default property (Pascal) casing.
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
