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

        public Usuario Usuario { get; set; } //no puede ser null

        public DateTime FechaCreacion { get; set; }

        public List<CarritoItem> Items { get; set; }

        public decimal Subtotal => Items?.Sum(i => i.Subtotal) ?? 0;

        public Carrito()
        {
            Items = new List<CarritoItem>();
            FechaCreacion = DateTime.Now; // se asigna al crear el carrito
        }
    }
}