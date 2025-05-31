using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Presupuesto
    {
        public int Id { get; set; }             
        public int IdCliente { get; set; }      
        public DateTime FechaSolicitud { get; set; } 
        public decimal Total { get; set; }
    }
}
