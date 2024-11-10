using ItemService_Api.Configurations;
using ItemService_Api.Extensions;
using ItemService_Api.Middlewares;
using ItemService_Api.Models;
using ItemService_Repositories.DataContext;
using Microsoft.EntityFrameworkCore;
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
        b => b.MigrationsAssembly("ItemService_Repositories"));
});

builder.Services.AddSingleton(appConfig);
builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddUseCases();
builder.Services.AddRepositories();
builder.Services.AddScoped<IActionResultConverter, ActionResultConverter>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = Status308PermanentRedirect;
    options.HttpsPort = 5001;
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
