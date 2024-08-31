using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola_Ternium_NetCore.src.Configuration
{
    public interface IConfigurationLoader
    {
        string ConnectionString { get; }
        string LogFilePath { get; }
    }
}
