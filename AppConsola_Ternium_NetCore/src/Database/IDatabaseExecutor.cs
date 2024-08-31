using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppConsola_Ternium_NetCore.src.Logging;
using AppConsola_Ternium_NetCore.src.Models;

namespace AppConsola_Ternium_NetCore.src.Database
{
    public interface IDatabaseExecutor
    {
        void InsertUser(User user);
        void GetUsersByAge(int edad);
        void GetUsersCreatedLastTwoHours();
    }
}
