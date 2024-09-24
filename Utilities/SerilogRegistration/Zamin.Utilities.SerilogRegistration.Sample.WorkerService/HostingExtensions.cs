using Zamin.Extensions.DependencyInjection;

namespace Zamin.Utilities.SerilogRegistration.Sample.WorkerService;

public static class HostingExtensions
{
    public static IHost ConfigureServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddZaminWebUserInfoService(c =>
        {
            c.DefaultUserId = "1";
        }, true);

        builder.Services.AddHostedService<Worker>();

        return builder.Build();
    }
}