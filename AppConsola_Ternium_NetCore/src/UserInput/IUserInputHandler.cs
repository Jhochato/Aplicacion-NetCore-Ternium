using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppConsola_Ternium_NetCore.src.Models;


namespace AppConsola_Ternium_NetCore.src.UserInput
{
    public interface IUserInputHandler
    {
        User GetUserData();
        int GetAgeForQuery();
    }
}
