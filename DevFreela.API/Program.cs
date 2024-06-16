using DevFreela.API.Filters;
using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Validators;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add(typeof(ValidationFilter)));

builder.Services
    .AddValidatorsFromAssemblyContaining<CreateUserValidator>()
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateProjectCommand).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<HorarioFuncionamentoOption>(builder.Configuration.GetSection("HorarioFuncionamento"));

//builder.Services.AddSingleton<DevFreelaDbContext>();

string connectionString = builder.Configuration.GetConnectionString("DevFreela");
builder.Services.AddDbContext<DevFreelaDbContext>(
    options => options.UseSqlServer(connectionString)
    );

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

//builder.Services.AddSingleton<ExemploInjecaoDependencia>(e => new ExemploInjecaoDependencia { Name = "Teste 01" }); // Injeção por aplicação
//builder.Services.AddScoped<ExemploInjecaoDependencia>(e => new ExemploInjecaoDependencia { Name = "Teste Scoped" });// Injeção por requisição
//builder.Services.AddTransient<ExemploInjecaoDependencia>(e => new ExemploInjecaoDependencia { Name = "Teste Transient" }); // Injeção por classe

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
