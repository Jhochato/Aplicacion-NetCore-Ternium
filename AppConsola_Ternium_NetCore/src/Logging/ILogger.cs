using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola_Ternium_NetCore.src.Logging
{
    public interface ILogger
    {
        void CreateProcessTitle();
        void LogError(string message);
        void WriteSectionTitle(string title);
        void WriteLogEntry(string logEntry);
    }
}
