using AppConsola_Ternium_NetCore.src.Configuration;
using AppConsola_Ternium_NetCore.src.Database;
using AppConsola_Ternium_NetCore.src.Logging;
using AppConsola_Ternium_NetCore.src.Models;
using AppConsola_Ternium_NetCore.src.UserInput;

class Program
{
    static void Main()
    {
        try
        {
            IConfigurationLoader configLoader = new ConfigurationLoader("config.xml");
            ILogger logger = new Logger(configLoader.LogFilePath);
            IUserInputHandler userInputHandler = new UserInputHandler(logger);
            IDatabaseExecutor dbExecutor = new DatabaseExecutor(configLoader.ConnectionString, logger);

            logger.CreateProcessTitle();

            User user = userInputHandler.GetUserData();
            dbExecutor.InsertUser(user);

            int ageForQuery = userInputHandler.GetAgeForQuery();
            dbExecutor.GetUsersByAge(ageForQuery);

            dbExecutor.GetUsersCreatedLastTwoHours();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el proceso principal: {ex.Message}");
        }
    }
}