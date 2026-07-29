using Microsoft.EntityFrameworkCore;
using TennisCourt.Features.Users;
using TennisCourt.Infrastructure;
using TennisCourt.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection") ?? "";

builder.Services.AddDbContext(connectionString);
builder.Services.AddUsersFeature();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        // context.Database.EnsureDeleted();
        await context.Database.MigrateAsync();
    }


    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.MapControllers();

app.Run();