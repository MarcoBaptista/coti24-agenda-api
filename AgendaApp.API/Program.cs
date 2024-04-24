using AgendaApp.API.Extensions;
using AgendaApp.API.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map=> { map.LowercaseUrls = true; });
builder.Services.AddSwaggerDoc();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
