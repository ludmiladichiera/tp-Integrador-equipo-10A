using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public string MetodoEntrega { get; set; } // 'envio' o 'retiro'
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<PedidoItem> Items { get; set; }
        public Pago Pago { get; set; }
        public Envio Envio { get; set; }
    }
}
