using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito //se agrega el atributo subtotal o se maneja asi?
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<CarritoItem> Items { get; set; }

        public decimal Subtotal => Items?.Sum(i => i.Subtotal) ?? 0;
    }
}
