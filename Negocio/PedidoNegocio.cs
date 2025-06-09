using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_pedido, id_usuario, fecha_pedido, metodo_entrega, fecha_entrega, precio_total FROM Pedido");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido pedido = new Pedido
                    {
                        Id = (int)datos.Lector["id_pedido"],
                        Usuario = new Usuario
                        {
                            Id = (int)datos.Lector["id_usuario"]
                        },
                        FechaPedido = (DateTime)datos.Lector["fecha_pedido"],
                        MetodoEntrega = datos.Lector["metodo_entrega"].ToString(),
                        FechaEntrega = (DateTime)datos.Lector["fecha_entrega"],
                        PrecioTotal = (decimal)datos.Lector["precio_total"],
                    };

                    lista.Add(pedido);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los pedidos", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
