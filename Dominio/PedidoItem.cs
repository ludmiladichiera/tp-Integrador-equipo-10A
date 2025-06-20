using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PedidoItem 
    {
        public int IdPedido { get; set; } //relación con pedido
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; } // Precio unitario al momento del pedido, x si se actualiza producto

        public decimal Subtotal => Precio * Cantidad;
    }
}
