using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Use MySQL instead of SQL Server
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("TaskContext"),
        new MySqlServerVersion(new Version(8, 0, 25)))); // Replace with your MySQL version

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskContext>();
    db.Database.Migrate(); // Ensure database is up-to-date
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
