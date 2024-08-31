using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppConsola_Ternium_NetCore.src.Configuration
{
    public class ConfigurationLoader : IConfigurationLoader
    {
        public string ConnectionString { get; private set; }
        public string LogFilePath { get; private set; }

        public ConfigurationLoader(string configFilePath)
        {
            var config = XDocument.Load(configFilePath);

            var connectionStringElement = config.Root.Element("connectionStrings")?.Element("add");
            var logFilePathElement = config.Root.Element("appSettings")?.Element("add");

            if (connectionStringElement == null)
                throw new InvalidOperationException("No se encontró el elemento 'connectionStrings' en el archivo XML.");

            if (logFilePathElement == null)
                throw new InvalidOperationException("No se encontró el elemento 'appSettings' en el archivo XML.");

            ConnectionString = connectionStringElement.Attribute("connectionString")?.Value
                ?? throw new InvalidOperationException("La cadena de conexión no está configurada en el archivo XML.");

            LogFilePath = logFilePathElement.Attribute("value")?.Value
                ?? throw new InvalidOperationException("La ruta del archivo de log no está configurada en el archivo XML.");
        }
    }
}
