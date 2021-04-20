using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.Services
{
    public class QueueHostedService : BackgroundService
    {
        private readonly ILogger _logger;
        public QueueHostedService(IBackgroundTaskQueue taskQueue, ILogger<QueueHostedService> logger)
        {
            TaskQueue = taskQueue;
            _logger = logger;
        }

        public IBackgroundTaskQueue TaskQueue { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background service has started.");
            await BackgroundProcessing(stoppingToken);
        }

        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var workItem = await TaskQueue.DequeueAsync(stoppingToken);

                try
                {
                    _logger.LogInformation("An item is popped from queue and started processing.");
                    await workItem(stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while processing item from queue, error {ex.StackTrace}");
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Background service has stopped.");
            await base.StopAsync(stoppingToken);
        }
    }
}
