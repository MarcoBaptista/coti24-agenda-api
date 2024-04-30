using AgendaApp.API.Extensions;
using AgendaApp.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map=> { map.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddCorsConfig();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCorsConfig();
app.UseAuthorization();
app.MapControllers();
app.Run();


//declacaro para tornar a calasse program 
//um classe pública do projeto
public partial class Program { }
