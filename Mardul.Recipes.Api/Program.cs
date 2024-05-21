using Mardul.Recipes.Api.Configuration;
using Mardul.Recipes.Core.Enums;
using Mardul.Recipes.Infrastructure.Authentication;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddConfiguredOptions(configuration);

builder.Services.AddInfrastructure(configuration);

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Read", builder => builder
            .AddRequirements(new PermissionRequirement([Permission.Read])))
    .AddPolicy("Create", builder => builder
            .AddRequirements(new PermissionRequirement([Permission.Create])));

builder.Services.AddLogging(o => o.AddFilter("Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerHandler", LogLevel.Debug));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
