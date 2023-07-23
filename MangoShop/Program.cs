using System.Reflection;
using MangoShop.Services.CouponApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}).AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

await ApplyMigrations();
app.Run();

async Task ApplyMigrations()
{
    using var scope = app.Services.CreateScope();

    var service = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var pendingMigrations = await service.Database.GetPendingMigrationsAsync();
    if (pendingMigrations.Any()) await service.Database.MigrateAsync();
}