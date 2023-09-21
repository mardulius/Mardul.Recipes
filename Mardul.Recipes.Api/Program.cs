using Mardul.Recipes.Api.Services;
using Mardul.Recipes.Core.Interfaces.Services;
using Mardul.Recipes.Core.Interfaces.Repositories;
using Mardul.Recipes.Infrastructure.DbContexts;
using Mardul.Recipes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Mardul.Recipes.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlite(builder.Configuration.GetConnectionString("db"));
    x.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    x.UseLazyLoadingProxies();

});

builder.Services.AddAutoMapper(typeof(RecipeMappingProfile));
builder.Services.AddScoped<DbContext, AppDbContext>();
builder.Services.AddTransient<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors( builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
