using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoItem //falta id carrito?
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public decimal Subtotal => Producto.Precio * Cantidad;
        public void incrementarCantidad()
        {
            Cantidad++;
        }
        public void decrementarCantidad()
        {
            if (Cantidad > 1)
            {
                Cantidad--;
            }
        }
    }
}
