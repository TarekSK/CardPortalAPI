using CardPortal.API.Configuration;
using CardPortal.Application.AutoMapper;
using CardPortal.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Main Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProductionConnection")));

// Custom Services - [Repository Interface, Repository]
builder.Services.AddCustomServices();

// MediatR
builder.Services.AddMediatRServices();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// CORS
builder.Services.AddCors(option => option.AddPolicy("corsPolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Swagger Allowed in Production [For Testing Purpose]
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
