using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Core.Services.LogService
{
    public class LogService : ILogService
    {
        public async Task LogDebugAsync(string message)
        {
            Console.WriteLine("Info: " + message);
        }

        public async Task LogErrorAsync(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public async Task LogInfoAsync(string message)
        {
            Console.WriteLine("Debug: " + message);
        }
    }
}
