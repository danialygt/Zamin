using Zamin.Extensions.DependencyInjection;
using Zamin.Utilities.SerilogRegistration.Extensions;
using Zamin.Utilities.SerilogRegistration.Sample.WorkerService;

SerilogExtensions.RunWithSerilogExceptionHandling(() =>
{
    var builder = Host.CreateApplicationBuilder(args);
    builder
    .AddZaminSerilog(c =>
    {
        c.ApplicationName = "SerilogRegistration";
        c.ServiceName = "SampleService";
        c.ServiceVersion = "1.0";
        c.ServiceId = Guid.NewGuid().ToString();
    })
    .ConfigureServices()
    .Run();
});