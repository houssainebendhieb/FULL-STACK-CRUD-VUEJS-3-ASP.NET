global using BackEnd.Model;
global using Microsoft.EntityFrameworkCore;
global using BackEnd.Data;
global using BackEnd.Services.PersonneServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name:MyAllowSpecificOrigins, 
        builder =>
    {
        builder.WithOrigins("http://localhost",
            "http://localhost:8080",
            "https://localhost:7230",
            "http://localhost:90")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});





builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonneServices,PersonneServices>();
builder.Services.AddDbContext<DataContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("test")));

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
