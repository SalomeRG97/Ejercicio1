using IoC;
using IoC.Ejercicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

SerilogIoC.ConfigureSeqService(builder);
Ejercicio_AutomapperIoC.ConfigureServie(builder);
Ejercicio_DatabaseIoC.ConfigureSQLServerService(builder);
Ejercicio_BusinessLogicIoC.RepositoryService(builder);
Ejercicio_BusinessLogicIoC.ReglasNegocioService(builder);

builder.Services.AddHttpContextAccessor();
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