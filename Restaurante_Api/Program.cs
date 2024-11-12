using Microsoft.EntityFrameworkCore;
using Restaurante_Api.Configurations;
using Restaurante_Api.Extensions;
using Restaurante_Api.Middlewares;
using Restaurante_Repositories.DataContext;
using System.Net;
using System.Net.Security;
using System.Text.Json.Serialization;
using static Microsoft.AspNetCore.Http.StatusCodes;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.LoadConfiguration();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }).ConfigureApiBehaviorOptions(options => options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.CreateResponse);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Restaurante_Repositories"));
});

builder.Services.AddSingleton(appConfig);
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddUseCases();
builder.Services.AddRepositories();
builder.Services.AddHttpClientBuilder();
builder.Services.AddScoped<IActionResultConverter, ActionResultConverter>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = Status308PermanentRedirect;
    options.HttpsPort = 4001;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var application = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

    //Utilizando o migration a execução do container docker não é necessario as linhas abaixo
    var pendingMigrations = await application.Database.GetPendingMigrationsAsync();
    if (pendingMigrations != null)
        await application.Database.MigrateAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.UseAuthentication();

app.Run();
