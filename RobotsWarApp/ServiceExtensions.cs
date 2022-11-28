using Microsoft.Extensions.DependencyInjection;
using RobotsWarLibrary.Commands;
using RobotsWarLibrary.Executors.Implementations;
using RobotsWarLibrary.Executors.Interfaces;
using RobotsWarLibrary.Factory.Implementations;
using RobotsWarLibrary.Factory.Interfaces;
using RobotsWarLibrary.Logging;
using RobotsWarLibrary.Validators;
using RobotWarsLibrary.Executors.Implementations;
using RobotWarsLibrary.Executors.Interfaces;
using ILogger = RobotsWarLibrary.Logging.ILogger;

namespace RobotsWarApp
{
    public static class ServiceExtensions
    {
        public static void ConfigureAllServices(this IServiceCollection services)
        {
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<ICommand, SpinCommand>();
            services.AddTransient<IExecutor, ArenaExecutor>();
            services.AddTransient<IExecutor, BuildRobotExecutor>();
            services.AddTransient<IExecutor, MoveRobotExecutor>();
            services.AddTransient<IArenaFactory, ArenaFactory>();
            services.AddTransient<IRobotFactory, RobotFactory>();
            services.AddTransient<IInputValidator, InputValidator>();
            services.AddTransient<ILogger, Logger>();
            services.AddSingleton<IContext, Context>();
        }
    }
}