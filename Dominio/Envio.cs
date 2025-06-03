using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Envio //falta un estado de envio entregado o no
    {
        public int Id { get; set; }
        public Pedido Pedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
    }
}
