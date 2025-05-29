using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public List<CarritoItem> Items { get; set; }

        public decimal Subtotal => Items?.Sum(i => i.Subtotal) ?? 0;
    }
}
