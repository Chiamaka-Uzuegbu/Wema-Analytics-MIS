using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Chiamaka.WemaAnalytics.Infrastructure.Data;
using Chiamaka.WemaAnalytics.WorkerService;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<WemaDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("AppDBConnection")));

        services.AddHostedService<KpiWorker>();
    })
    .ConfigureLogging(logging => logging.AddConsole());

await builder.RunConsoleAsync();
