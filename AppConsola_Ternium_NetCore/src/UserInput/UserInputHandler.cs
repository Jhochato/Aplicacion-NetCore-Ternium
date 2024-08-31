using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppConsola_Ternium_NetCore.src.Logging;
using AppConsola_Ternium_NetCore.src.Models;


namespace AppConsola_Ternium_NetCore.src.UserInput
{
    public class UserInputHandler : IUserInputHandler
    {
        private readonly ILogger logger;

        public UserInputHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public User GetUserData()
        {
            Console.WriteLine("Ingrese el Nombre del Usuario:");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido del Usuario:");
            string apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la Edad del Usuario:");
            if (!int.TryParse(Console.ReadLine(), out int edad))
            {
                logger.LogError("La edad ingresada no es válida.");
                throw new InvalidOperationException("La edad ingresada no es válida.");
            }
            Console.WriteLine("Ingrese el Correo del Usuario:");
            string correo = Console.ReadLine();
            Console.WriteLine("Ingrese los Hobbies del Usuario (separados por guiones):");
            string hobbies = Console.ReadLine();
            Console.WriteLine("¿Está el Usuario Activo? (S/N):");
            bool activo = Console.ReadLine().ToUpper() == "S";
            Console.WriteLine("Nombre de quien crea el Usuario:");
            string creadoPor = Console.ReadLine();

            return new User
            {
                Nombre = nombre,
                Apellido = apellido,
                Edad = edad,
                Correo = correo,
                Hobbies = hobbies,
                Activo = activo,
                CreadoPor = creadoPor
            };
        }

        public int GetAgeForQuery()
        {
            Console.WriteLine("Ingrese la Edad para obtener usuarios:");
            if (!int.TryParse(Console.ReadLine(), out int edadParaConsulta))
            {
                logger.LogError("La edad ingresada no es válida.");
                throw new InvalidOperationException("La edad ingresada no es válida.");
            }

            return edadParaConsulta;
        }
    }
}
