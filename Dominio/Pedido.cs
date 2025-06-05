using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum EstadoPedido
    {
        Pendiente = 1,
        Recepcionado = 2,
        EnPreparacion = 3,
        ListoParaRetirar = 4,
        ListoParaEnviar = 5,
        Enviado = 6,
        Entregado = 7,
        Cancelado = 8
    }
    public class Pedido 
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPedido { get; set; }
        public string MetodoEntrega { get; set; } // 'envio' o 'retiro'
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<PedidoItem> Items { get; set; }
        public Pago Pago { get; set; }
        public Envio Envio { get; set; }
        public EstadoPedido EstadoPedido { get; set; } 
    }
}
