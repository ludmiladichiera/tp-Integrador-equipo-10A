using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; 

namespace Negocio
{
    public class PedidoItemNegocio
    {
        public List<PedidoItem> ObtenerItemsValidosParaPedido(int idCarrito)
        {
            List<PedidoItem> itemsPedido = new List<PedidoItem>();
            AccesoDatos datos = new AccesoDatos();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                datos.setearConsulta(@"
                SELECT ci.id_producto, ci.cantidad, p.nombre, p.precio, p.stock, p.estado
                FROM Carrito_Item ci
                JOIN Producto p ON ci.id_producto = p.id_producto
                WHERE ci.id_carrito = @idCarrito
            ");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int stock = (int)datos.Lector["stock"];
                    string estado = datos.Lector["estado"].ToString();
                    int cantidad = (int)datos.Lector["cantidad"];
                    decimal precioActual = (decimal)datos.Lector["precio"];

                    if (estado == "Activo" && stock >= cantidad)
                    {
                        itemsPedido.Add(new PedidoItem
                        {
                            Producto = new Producto
                            {
                                Id = (int)datos.Lector["id_producto"],
                                Nombre = datos.Lector["nombre"].ToString(),
                            },
                            Cantidad = cantidad,
                            Precio = precioActual
                        });
                    }
                    else
                    {
                        // msj de error

                    }
                }

                return itemsPedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener items validados para pedido", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void AgregarItemPedido(int idPedido, int idProducto, int cantidad, decimal precio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            INSERT INTO Pedido_Item (id_pedido, id_producto, cantidad, precio)
            VALUES (@idPedido, @idProducto, @cantidad, @precio)
        ");

                datos.setearParametro("@idPedido", idPedido);
                datos.setearParametro("@idProducto", idProducto);
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@precio", precio);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar ítem al pedido", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<PedidoItem> ListarPorPedido(int idPedido)
        {
            List<PedidoItem> listaItems = new List<PedidoItem>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT pi.id_producto, pi.cantidad, pi.precio, p.nombre
            FROM Pedido_Item pi
            INNER JOIN Producto p ON pi.id_producto = p.id_producto
            WHERE pi.id_pedido = @idPedido");
                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PedidoItem item = new PedidoItem
                    {
                        Cantidad = (int)datos.Lector["cantidad"],
                        Precio = (decimal)datos.Lector["precio"],
                        Producto = new Producto
                        {
                            Id = (int)datos.Lector["id_producto"],
                            Nombre = datos.Lector["nombre"].ToString()
                        }
                    };

                    listaItems.Add(item);
                }

                return listaItems;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar items del pedido", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}


