
using Cinema.Business.Managers;
using Cinema.Business.Services;
using Cinema.Data.Context;
using Cinema.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CinemaContext>(options => options.UseInMemoryDatabase("CinemaDb"));

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddScoped<IMovieService, MovieManager>();

builder.Services.AddSwaggerGen();
 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

                                                      

app.Run();
