using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {
        //se usa herencia para id, contrase y mail
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Carrito Carrito { get; set; }
        public List<Presupuesto> Presupuestos { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}
