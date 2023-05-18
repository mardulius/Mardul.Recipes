using Mardul.Recipes.Api.Services;
using Mardul.Recipes.Api.Services.Mappings;
using Mardul.Recipes.Data.DbContexts;
using Mardul.Recipes.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>( x =>
{
    x.UseSqlite(builder.Configuration.GetConnectionString("db"));
    x.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    x.UseLazyLoadingProxies();
    
});
builder.Services.AddAutoMapper(typeof(RecipeMappingProfile));
builder.Services.AddScoped(typeof(DbContext), typeof(AppDbContext));
builder.Services.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
