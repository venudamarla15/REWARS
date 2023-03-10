using Microsoft.EntityFrameworkCore;
using RewardPoints;
using RewardPoints.Entities;
using RewardPoints.Repository;
using RewardPoints.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBaseRepository<CustomerEntity>, CustomerRepository>();
builder.Services.AddScoped<IBaseRepository<TransactionEntity>, TransactionRepository>();
builder.Services.AddDbContext<TransactionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TransactionDbConnectionString")));
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

app.Run();
