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
                datos.setearConsulta(@"
            SELECT id_pedido, id_usuario, fecha_pedido, metodo_entrega, fecha_entrega, 
                   precio_total, metodo_pago, estado_pago, estado_pedido
            FROM Pedido");

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
                        MetodoEntrega = (MetodoEntrega)(int)datos.Lector["metodo_entrega"],
                        FechaEntrega = (DateTime)datos.Lector["fecha_entrega"],
                        PrecioTotal = (decimal)datos.Lector["precio_total"],
                        MetodoPago = (MetodoPago)(int)datos.Lector["metodo_pago"],
                        EstadoPago = (EstadoPago)(int)datos.Lector["estado_pago"],
                        EstadoPedido = (EstadoPedido)(int)datos.Lector["estado_pedido"]
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

        public int CrearPedido(Pedido nuevoPedido)
        {
            string cadenaConexion = "server=.\\SQLEXPRESS; database=Ecommerce; integrated security=true";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    int idPedido;

                    // Insertar Pedido
                    string insertPedido = @"
                INSERT INTO Pedido (id_usuario, fecha_pedido, metodo_entrega, fecha_entrega, precio_total, metodo_pago, estado_pago, estado_pedido)
                VALUES (@idUsuario, @fechaPedido, @metodoEntrega, @fechaEntrega, @precioTotal, @metodoPago, @estadoPago, @estadoPedido);
                SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertPedido, conexion, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", nuevoPedido.Usuario.Id);
                        cmd.Parameters.AddWithValue("@fechaPedido", nuevoPedido.FechaPedido);
                        cmd.Parameters.AddWithValue("@metodoEntrega", (int)nuevoPedido.MetodoEntrega);
                        cmd.Parameters.AddWithValue("@fechaEntrega", nuevoPedido.FechaEntrega);
                        cmd.Parameters.AddWithValue("@precioTotal", nuevoPedido.PrecioTotal);
                        cmd.Parameters.AddWithValue("@metodoPago", (int)nuevoPedido.MetodoPago);
                        cmd.Parameters.AddWithValue("@estadoPago", (int)nuevoPedido.EstadoPago);
                        cmd.Parameters.AddWithValue("@estadoPedido", (int)nuevoPedido.EstadoPedido);

                        idPedido = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insertar ítems y actualizar stock dentro del mismo foreach
                    foreach (var item in nuevoPedido.Items)
                    {
                        if (!item.Producto.Estado || item.Producto.Stock < item.Cantidad)
                            throw new Exception($"Producto '{item.Producto.Nombre}' no disponible o sin stock suficiente.");

                        // Insertar ítem
                        string insertItem = @"
                    INSERT INTO Pedido_Item (id_pedido, id_producto, cantidad, precio)
                    VALUES (@idPedido, @idProducto, @cantidad, @precio)";

                        using (SqlCommand cmdItem = new SqlCommand(insertItem, conexion, transaccion))
                        {
                            cmdItem.Parameters.AddWithValue("@idPedido", idPedido);
                            cmdItem.Parameters.AddWithValue("@idProducto", item.Producto.Id);
                            cmdItem.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            cmdItem.Parameters.AddWithValue("@precio", item.Precio);
                            cmdItem.ExecuteNonQuery();
                        }

                        // Actualizar stock del producto
                        string updateStock = @"
                    UPDATE Producto 
                    SET stock = stock - @cantidad 
                    WHERE id_producto = @idProducto";

                        using (SqlCommand cmdStock = new SqlCommand(updateStock, conexion, transaccion))
                        {
                            cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                            cmdStock.Parameters.AddWithValue("@idProducto", item.Producto.Id);
                            cmdStock.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                    return idPedido;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al crear el pedido: " + ex.Message, ex);
                }
            }
        }
        public List<Pedido> ListarPorUsuario(int idUsuario) //este es para leer solo por usuario 
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT id_pedido, id_usuario, fecha_pedido, metodo_entrega, fecha_entrega, 
                   precio_total, metodo_pago, estado_pago, estado_pedido
            FROM Pedido
            WHERE id_usuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
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
                        MetodoEntrega = (MetodoEntrega)(int)datos.Lector["metodo_entrega"],
                        FechaEntrega = (DateTime)datos.Lector["fecha_entrega"],
                        PrecioTotal = (decimal)datos.Lector["precio_total"],
                        MetodoPago = (MetodoPago)(int)datos.Lector["metodo_pago"],
                        EstadoPago = (EstadoPago)(int)datos.Lector["estado_pago"],
                        EstadoPedido = (EstadoPedido)(int)datos.Lector["estado_pedido"]
                    };

                    lista.Add(pedido);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los pedidos del usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Pedido ObtenerPedidoPorId(int idPedido)
        {
            Pedido pedido = null;
            AccesoDatos datos = new AccesoDatos();
            PedidoItemNegocio pedidoItemNegocio = new PedidoItemNegocio();

            try
            {
                datos.setearConsulta(@"
            SELECT id_pedido, id_usuario, fecha_pedido, metodo_entrega, fecha_entrega, 
                   precio_total, metodo_pago, estado_pago, estado_pedido
            FROM Pedido
            WHERE id_pedido = @idPedido");
                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    pedido = new Pedido
                    {
                        Id = (int)datos.Lector["id_pedido"],
                        Usuario = new Usuario
                        {
                            Id = (int)datos.Lector["id_usuario"]
                        },
                        FechaPedido = (DateTime)datos.Lector["fecha_pedido"],
                        MetodoEntrega = (MetodoEntrega)(int)datos.Lector["metodo_entrega"],
                        FechaEntrega = (DateTime)datos.Lector["fecha_entrega"],
                        PrecioTotal = (decimal)datos.Lector["precio_total"],
                        MetodoPago = (MetodoPago)(int)datos.Lector["metodo_pago"],
                        EstadoPago = (EstadoPago)(int)datos.Lector["estado_pago"],
                        EstadoPedido = (EstadoPedido)(int)datos.Lector["estado_pedido"],
                        Items = pedidoItemNegocio.ListarPorPedido(idPedido) // Este método debería devolver los items del pedido
                    };
                }

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pedido por id", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void CancelarPedido(int idPedido) //para el btn de arrepentimiento del cliente
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Pedido SET estado_pedido = @estadoCancelado WHERE id_pedido = @idPedido");
                datos.setearParametro("@estadoCancelado", (int)EstadoPedido.Cancelado);
                datos.setearParametro("@idPedido", idPedido);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cancelar el pedido", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
    