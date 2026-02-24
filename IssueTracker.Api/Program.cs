using IssueTracker.Api.Data;
using IssueTracker.Api.Interfaces;
using IssueTracker.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => 
options.UseNpgsql(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IIssueService , IssueService>();


var app = builder.Build();


app.UseSwagger();  
app.UseSwaggerUI();


app.MapControllers();

app.Run();
