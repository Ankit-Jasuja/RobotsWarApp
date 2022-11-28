using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RobotsWarLibrary.Validators;
using RobotWarsLibrary.Executors.Interfaces;

namespace RobotsWarApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHost host; 
            try
            {
                host = CreateHostBuilder(args).Build();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured {e.Message}");
                return;
            }
            Console.WriteLine("Enter quit any time to exit the game");

            var executors = host.Services.GetServices<IExecutor>();
            var validator = host.Services.GetRequiredService<IInputValidator>();

            var isQuit = false;
            while (!isQuit)
            {
                var input = Console.ReadLine();
                if (input?.ToLowerInvariant() == "quit")
                {
                    isQuit = true;
                    return;
                }

                var executor = executors.FirstOrDefault(z => validator.IsInputValid(input!, z.regexPattern));
                if (executor is null)
                {
                    Console.WriteLine($"Invalid input");
                    return;
                }
                else
                {
                    executor.Execute(input!);
                }
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.ConfigureAllServices();
                });
        }
    }
}