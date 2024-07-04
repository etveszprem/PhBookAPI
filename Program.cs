using InsOrUpdUsr.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PhoneUsrContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phonebook API", Version = "v1" });

    // Enable XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// HTTP request becsatorn�z�sa...
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsrToDB");
        c.RoutePrefix = string.Empty; // Swagger UI el�r�se a gy�k�r URL-r�l
        
    });
}
//TODO Nem m�k�d�tt az �tir�ny�t�s t�zfal miatt, ezt ki kellett kommentelni:
//app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();