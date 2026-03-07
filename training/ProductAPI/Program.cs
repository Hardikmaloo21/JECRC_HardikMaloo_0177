using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);
//add controller
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add database context
builder.Services.AddControllers();

//Add services for database context
builder.Services.AddDbContext<ProductAPI.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//middleware
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
