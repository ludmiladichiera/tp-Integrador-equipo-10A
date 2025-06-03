using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario

    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Pass { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
        public string Telefono { get; set; }
    }


}
