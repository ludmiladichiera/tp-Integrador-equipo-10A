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
    public enum MetodoEntrega
    {
        Retiro = 1,
        Envio = 2
    }
    public enum MetodoPago
    {
        MercadoPago = 1,
        Transferencia = 2,
        Efectivo = 3
    }
    public enum EstadoPago
    {
        Pendiente = 1,
        Abonado = 2
    }
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPedido { get; set; }
        public MetodoEntrega MetodoEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal PrecioTotal { get; set; }
        public List<PedidoItem> Items { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public EstadoPago EstadoPago { get; set; }

        public EstadoPedido EstadoPedido { get; set; }

        // para mostrar nombres de enums
        public string MetodoEntregaNombre => MetodoEntrega.ToString();
        public string MetodoPagoNombre => MetodoPago.ToString();
        public string EstadoPagoNombre => EstadoPago.ToString();
        public string EstadoPedidoNombre => EstadoPedido.ToString();
    }
}
