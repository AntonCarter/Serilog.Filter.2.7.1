using System;
using System.IO;
using Serilog;

namespace SerilogSinkFilter2_7
{
    class Program
    { 
        static void Main(string[] args)
        {
            var testMessage = "do not show in log file";

            //Async - This will log the test message to the log file
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .Async(r => r.RollingFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "excluding.log"))
                    .Filter.ByExcluding(l => l.MessageTemplate.Text == testMessage))
                .CreateLogger();

            Log.Information("started logging");
            Log.Information(testMessage);

            Console.ReadKey(true);
        }
    }
}
