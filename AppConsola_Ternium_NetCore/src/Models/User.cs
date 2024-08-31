using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConsola_Ternium_NetCore.src.Models
{
    public class User
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Correo { get; set; }
        public string Hobbies { get; set; }
        public bool Activo { get; set; }
        public string CreadoPor { get; set; }
    }
}
