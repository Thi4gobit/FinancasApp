using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configura��o do CORS (Politica de acesso da API)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorWeb", policy =>
    {
        policy.WithOrigins("http://localhost:5250") //Endere�o da aplica��o Blazor
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

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



