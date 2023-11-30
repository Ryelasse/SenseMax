using Microsoft.EntityFrameworkCore;
using SenseMax;
using SenseRepositoryDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProfileDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(Secret.GetConnectionString)));

builder.Services.AddDbContext<ArtworkDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(Secret.GetConnectionString)));

// Registrer dit repository som en scoped service.
builder.Services.AddScoped<IRepositoryDB<Profile>, ProfileRepositoryDB>();
builder.Services.AddScoped<IRepositoryDB<Artwork>, ArtworkRepositoryDB>();

builder.Services.AddCors(option =>
    option.AddPolicy("Allow All",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
