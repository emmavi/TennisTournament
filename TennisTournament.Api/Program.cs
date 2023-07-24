using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TennisTournament.Infra;
using TennisTournament.Infra.Repositories;
using TennisTournament.Infra.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<ITournamentRepository, TournamentRepository>();

builder.Services.AddDbContext<TournamentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
//builder.Services.AddDbContext<TournamentContext>(options => options.UseInMemoryDatabase("TournamentDb"));

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
