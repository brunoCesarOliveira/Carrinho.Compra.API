using Carrinho.Compra.Domain.Interface;
using Carrinho.Compra.Domain.Interface.Repository;
using Carrinho.Compra.Domain.Interface.Service;
using Carrinho.Compra.Domain.Mappings;
using Carrinho.Compra.Domain.Models;
using Carrinho.Compra.Repository;
using Carrinho.Compra.Repository.Context;
using Carrinho.Compra.Repository.Ioc;
using Carrinho.Compra.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//Configurando o banco de dados
builder.Services.AddControllers().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
    );

builder.Services.AddAutoMapper(typeof(MappingProfile));

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{

    options.UseNpgsql(connectionString);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();

});

//Respository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ICupomRepository, CupomRepository>();
builder.Services.AddScoped<IItemCarrinhoRepository, ItemCarrinhoRepository>();  

//Serices
builder.Services.AddScoped<ICarrinhoService, CarrinhoService>();
builder.Services.AddScoped<IService<ProdutoModel>, ProdutoService>();
builder.Services.AddScoped<IService<CupomModel>, CupomService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VuePolicy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:8080",
                "http://localhost:8081"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("VuePolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
