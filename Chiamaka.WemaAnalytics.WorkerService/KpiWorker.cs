using Microsoft.EntityFrameworkCore;
using Chiamaka.WemaAnalytics.Domain.Entities;
using Chiamaka.WemaAnalytics.Infrastructure.Data; 
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chiamaka.WemaAnalytics.WorkerService
{
    public class KpiWorker : BackgroundService
    {
        private readonly ILogger<KpiWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

        public KpiWorker(ILogger<KpiWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("KpiWorker starting.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<WemaDbContext>();

                    var today = DateTime.UtcNow.Date;

                    var exists = await db.Set<KpiSnapshot>().AnyAsync(k => k.SnapshotDate == today, stoppingToken);
                    if (!exists)
                    {
                        var totalAccounts = await db.Set<Account>().CountAsync(stoppingToken);
                        var activeAccounts = await db.Set<Account>().CountAsync(a => a.Status == "Active", stoppingToken);
                        var totalBalance = await db.Set<Account>().SumAsync(a => (decimal?)a.Balance ?? 0m, stoppingToken);
                        var averageBalance = totalAccounts > 0 ? (totalBalance ?? 0m) / totalAccounts : 0m;

                        var snapshot = new KpiSnapshot
                        {
                            SnapshotDate = today,
                            TotalAccounts = totalAccounts,
                            ActiveAccounts = activeAccounts,
                            TotalBalance = totalBalance ?? 0m,
                            AverageBalance = averageBalance,
                            CreatedAtUtc = DateTime.UtcNow
                        };

                        db.Add(snapshot);
                        await db.SaveChangesAsync(stoppingToken);
                        _logger.LogInformation("Inserted KPI snapshot for {date}", today.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        _logger.LogInformation("KPI snapshot already exists for {date}", today.ToString("yyyy-MM-dd"));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in KpiWorker loop");
                }

                await Task.Delay(_interval, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("KpiWorker stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}