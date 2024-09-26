using Microsoft.EntityFrameworkCore;
using WebApiTenis.Context;

var builder = WebApplication.CreateBuilder(args);

//Se crea una variable para la cadena de conexion.
var connectionString = builder.Configuration.GetConnectionString("Connection");

//Se registra el servicio para la conexion
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)

);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
