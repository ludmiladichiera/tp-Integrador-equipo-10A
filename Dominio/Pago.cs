using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pago
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }//ver, enumerador int, no string
        public decimal Monto { get; set; }
    }
}
