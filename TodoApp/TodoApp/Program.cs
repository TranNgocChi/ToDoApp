using DataAccess.Context;
using DataAccess.DAO;
using DataAccess.Repository.MyTaskRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject from Data Access
builder.Services.AddDbContext<TaskContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("Todo"));
});
builder.Services.AddScoped<TaskDAO>();
builder.Services.AddScoped<IMyTaskRepository, MyTaskRepository>();

//Allow port 3000 access
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowOrigin",
		builder =>
		{
			builder.WithOrigins("http://localhost:3000") 
				   .AllowAnyHeader()
				   .AllowAnyMethod();
		});
});

var app = builder.Build();

app.UseCors("AllowOrigin");

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
