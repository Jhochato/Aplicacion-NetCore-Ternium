using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola_Ternium_NetCore.src.Logging
{
    public class Logger : ILogger
    {
        private readonly string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void CreateProcessTitle()
        {
            WriteLogEntry($"--- NUEVO PROCESO: {DateTime.Now} ---");
        }

        public void LogError(string message)
        {
            WriteLogEntry($"ERROR: {DateTime.Now}: {message}");
        }

        public void WriteSectionTitle(string title)
        {
            WriteLogEntry($"--- {title} ---");
        }

        public void WriteLogEntry(string logEntry)
        {
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de log: {ex.Message}");
            }
        }
    }
}
