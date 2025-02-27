﻿using Metalama.Logging.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VtlSoftware.LoggedConsoleApp
{
    internal class Program
    {
        #region Private Methods

        [NoLog]
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Trace))
            .AddSingleton<Calculator>()
            .AddSingleton<StringStuff>()
            .AddSingleton<TimedFun>()
            .BuildServiceProvider();

            var calculator = serviceProvider.GetService<Calculator>()!;

            try
            {
                calculator.Add(1, 1);
                calculator.Subtract(1, 1);
                calculator.Multiply(1, 1);
                calculator.Divide(1, 1);
            } catch
            {
            }

            var stringStuff = serviceProvider.GetService<StringStuff>()!;

            try
            {
                Console.WriteLine(stringStuff.LoginWithoutObfuscation("Dom", "MySecretPassword").ToString());
                Console.WriteLine(stringStuff.LoginWithObfuscation("Dom", "MySecretPassword").ToString());
            } catch
            {
            }

            var times = serviceProvider.GetService<TimedFun>()!;
            try
            {
                times.Delay();
            } catch
            {
            }
        }

        #endregion
    }
}