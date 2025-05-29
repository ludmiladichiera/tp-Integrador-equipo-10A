﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string UnidadVenta { get; set; } // unidad, docena
        public string ImagenUrl { get; set; }

        public Categoria Categoria { get; set; }
    }
}
