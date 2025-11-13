using Microsoft.EntityFrameworkCore;
using SchoolApi.Application.Interfaces;
using SchoolApi.Application.Services;
using SchoolApi.Domain.Interfaces;
using SchoolApi.Infrastructure.Data;
using SchoolApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite("Data Source=School.db"));

// Register repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// Register services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// Apply pending migrations
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    context.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
