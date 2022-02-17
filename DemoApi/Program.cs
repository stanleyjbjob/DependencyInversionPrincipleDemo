using DemoApi.Controllers;
using DependencyInversionPrincipleDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//µù¥U
//builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<ILoginService, EncyptLoginService>();
//builder.Services.AddScoped<ITransCardService, TransCardService>();
builder.Services.AddScoped<ITransCardService, AggregateTranscardService>();
builder.Services.AddScoped<ITransCardModule, AggregateTransCardModule>();

builder.Services.AddScoped<ITransCardService, AggregateTranscardServiceWithoutSave>();

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
