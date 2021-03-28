using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop.Core.Services.LogService
{
    public interface ILogService
    {
        Task LogInfoAsync(string message);
        Task LogDebugAsync(string message);
        Task LogErrorAsync(string message);
    }
}
