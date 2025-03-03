using Infrastructure;
using WEB.Middleware;
using Microsoft.OpenApi.Models;
using Application.Repositories;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IRequestRepository, RequestRepository>();
builder.Services.AddTransient<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddDbContext<DBData>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("DataBase"));
});

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Geological Research API", Version = "v1" }); });

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
app.UseExceptionHandlingMiddleware();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geological Research API v1"));
app.UseRouting().UseEndpoints(e => e.MapControllers());
app.Run();
