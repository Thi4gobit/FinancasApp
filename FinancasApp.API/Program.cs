using FinancasApp.Domain.Interfaces.Messages;
using FinancasApp.Domain.Interfaces.Repositories;
using FinancasApp.Domain.Interfaces.Services;
using FinancasApp.Domain.Services;
using FinancasApp.Infra.Data.Contexts;
using FinancasApp.Infra.Data.Repositories;
using FinancasApp.Infra.Data.Settings;
using FinancasApp.Infra.Messages.Producers;
using FinancasApp.Infra.Messages.Settings;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuração do CORS (Politica de acesso da API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWeb", policy =>
    {
        policy.WithOrigins("http://localhost:5250") //Endereço da aplicação Blazor
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//Ler as configurações do appsettings.json para connectionstring do banco de dados
builder.Services.AddSingleton(builder.Configuration.GetSection("MongoDbSettings")
       .Get<MongoDbSettings>());

//Ler as configurações do appsettings.json para a mensageria do RabbitMQ
builder.Services.AddSingleton(builder.Configuration.GetSection("RabbitMQSettings")
       .Get<RabbitMQSettings>());

//Configurações para injeção de dependência
builder.Services.AddTransient<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddTransient<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddTransient<IMessageProducer, MessageProducer>();
builder.Services.AddTransient<MongoDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

//Habilitar a politica de acesso da API
app.UseCors("AllowBlazorWeb");

app.UseAuthorization();
app.MapControllers();
app.Run();



