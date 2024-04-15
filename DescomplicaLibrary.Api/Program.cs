using DescomplicaLibrary.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//Configure EF Core Database
builder.Services.AddDbContext<DescomplicaLibraryDbContext>(opt => opt.UseInMemoryDatabase("DescomplicaLibrary"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

//Create dabase and run seeds
using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DescomplicaLibraryDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();