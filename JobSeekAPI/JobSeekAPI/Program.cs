using JobSeekAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connetionstring = builder.Configuration.GetConnectionString("Myconnection");
var serverVersion = new MariaDbServerVersion(new Version(8, 0, 29));
// Add services to the container.
builder.Services.AddDbContext<db_a8b602_jobseekContext>(options => options.UseMySql(connetionstring, serverVersion));

builder.Services.AddTransient<DbService>();

builder.Services.AddControllers();

builder.Services.AddControllersWithViews();

builder.Services.AddCors();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

/// <summary>
/// ////////////
/// </summary>
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{


}*/

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
