using System.Diagnostics;

namespace Zamin.Utilities.SerilogRegistration.Sample.WorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            using (var activity = new Activity("WorkerActivity"))
            {
                activity.Start();

                _logger.LogInformation("Trace ID: {TraceId}, Span ID: {SpanId}", activity.TraceId, activity.SpanId);

                await Task.Delay(5000, stoppingToken);

                activity.Stop();
            }
        }
    }
}
