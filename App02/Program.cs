using Microsoft.Extensions.DependencyInjection;
using System;

namespace App02
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            //var feeder = new CsvPriceFeeder();
            var provider = services.BuildServiceProvider();
            var robot = provider.GetService<Robot>();
            var x = robot.AveragePrice();
            robot.DoWork();
            Console.WriteLine(x);

            // 1
            Console.WriteLine(provider.GetService<Robot>().Id);

            using (var scope = provider.CreateScope())
            {
                var p = scope.ServiceProvider;
                Console.WriteLine(p.GetService<Robot>().Id);
                Console.WriteLine(p.GetService<Robot>().Id);
            }

            using (var scope = provider.CreateScope())
            {
                var p = scope.ServiceProvider;
                Console.WriteLine(p.GetService<Robot>().Id);
                Console.WriteLine(p.GetService<Robot>().Id);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IPriceFeeder, CsvPriceFeeder>();
            //services.AddTransient<Robot>();
            services.AddSingleton<Robot>();
            services.AddSingleton<ILog, FileLog>();
            services.AddSingleton<ILog, AirTableLog>();
        }
    }
}
