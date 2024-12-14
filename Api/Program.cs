using Microsoft.EntityFrameworkCore;
using SharedLibrary.Data;
using SharedLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
var dbFilePath = Path.Combine(projectRootPath, "SharedLibrary", "DissertionThemes.db");

Console.WriteLine(dbFilePath);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbFilePath}"));

builder.Services.AddScoped<IThemeService, ThemeService>();
builder.Services.AddScoped<IStProgramService, StProgramService>();
builder.Services.AddScoped<ISupervisorService, SupervisorService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
