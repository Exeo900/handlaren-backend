using Core.Adapters.In;
using Core.Ports.In;
using Core.Ports.Out;
using handlarn_backend;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Out.Adapter.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISqlDataAcess, SqlDataAcess>();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddScoped<IShoppingListItemService, ShoppingListItemService>();
builder.Services.AddScoped<IUserDataService, UserDataService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins(
                    "https://handlaren-frontend.azurewebsites.net",
                    "https://localhost:*",
                    "https://127.0.0.1:*",
                    "http://localhost:5173",
                    "http://127.0.0.1:*",
                    "http://192.168.50.14:8001"
                )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Configure azure key vault
if (!builder.Environment.IsDevelopment())
{
    var keyVaultEndpoint = builder.Configuration["KeyVault:Endpoint"];

    if (!string.IsNullOrEmpty(keyVaultEndpoint))
    {
        var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(new AzureServiceTokenProvider().KeyVaultTokenCallback));
        builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();