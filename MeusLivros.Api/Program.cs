using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Contexts;
using MeusLivros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//DI - Injecao de Dependencias
//Ele � otimizado
//builder.Services.AddDbContext<DataContext>(x => x.UseInMemoryDatabase("Banco"));
builder.Services.AddDbContext<DataContext>(
    x => x.UseSqlServer(
        builder.Configuration.GetConnectionString("conexao"),
        sqlOptions => sqlOptions.MigrationsAssembly("MeusLivros.Infra")
        )
    );

builder.Services.AddScoped<IEditoraRepository, EditoraRepository>();
builder.Services.AddScoped<EditoraHandler, EditoraHandler>();
builder.Services.AddScoped<ILivroRepository, LivrosRepository>();
builder.Services.AddScoped<LivroHandler, LivroHandler>();   
//DI - Injecao de Dependencias


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
