using SistemaVenta.Application;
using SistemaVenta.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sw =>
{
    //sw.SwaggerDoc("Sistema", new OpenApiInfo { Title = "Sistema de Inventario", Version = "v1", Description = "Todos los derechos reservados por Brian Pelegrin" });
});
builder.Services.AddInfratructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCors(cors =>
{
    cors.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
