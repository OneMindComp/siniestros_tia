using ICore.Siniestro.Api.Extensiones;
using ICore.Siniestro.Aplicacion;
using ICore.Siniestro.Infraestructura;
using Microsoft.OpenApi.Models;
using Sbins.Diagnostico.HealthChecks;
using Sbins.Diagnostico.HealthChecks.ApiRest;

var logger = Logging.GetCurrentLogger();
logger.Debug("Inicio program.cs");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Logging.
    builder.ConfigureLogging();

    // Define version.
    var version = typeof(Program).Assembly.GetName().Version!.ToString()[..5];

    // HealthCheck.
    builder.Services.AddSbinsHealthCheck(version);

    builder.Services.ConfigureControllers();

    // Incorpora Aplicacion e Infraestructura.
    builder.Services.AddAplicacion()
        .AddInfraestructura(builder.Configuration);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddSbinsSwaggerGen($"v{version}", new OpenApiInfo
    {
        Title = "SBINS - ICore Siniestro API ",
        Version = $"v{version}",
        Description = "Proyecto dedicado a entregar Apis para la obtencion y registro de siniestros hacia el CORE TIA."
    });

    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSbinsSwagger();
    }

    // Sentry
    app.UseSentryTracing();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapSbinsHealthCheckEnpoints();

    app.MapControllers();

    await app.RunAsync();
}
catch (Exception exception)
{
    logger.Error(exception, "Program.cs detenido por excepcion");
}
finally
{
    NLog.LogManager.Shutdown();
}