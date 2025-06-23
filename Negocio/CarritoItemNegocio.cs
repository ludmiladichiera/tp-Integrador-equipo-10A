using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoItemNegocio
    {
        public List<CarritoItem> ObtenerItems(int idCarrito)
        {
            List<CarritoItem> items = new List<CarritoItem>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
                SELECT ci.id_producto, ci.cantidad,
                       p.nombre, p.precio
                FROM Carrito_Item ci
                JOIN Producto p ON ci.id_producto = p.id_producto
                WHERE ci.id_carrito = @idCarrito
            ");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    items.Add(new CarritoItem
                    {
                        Producto = new Producto
                        {
                            Id = (int)datos.Lector["id_producto"],
                            Nombre = datos.Lector["nombre"].ToString(),
                            Precio = (decimal)datos.Lector["precio"]
                        },
                        Cantidad = (int)datos.Lector["cantidad"]
                    });
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener items del carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool AgregarOActualizarItem(int idCarrito, int idProducto, int cantidad)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            int stockDisponible = productoNegocio.ObtenerStockProducto(idProducto);

            int cantidadActual = ObtenerCantidad(idCarrito, idProducto);
            int nuevaCantidad = cantidadActual + cantidad;

            if (nuevaCantidad > stockDisponible)
            {
                // No hay stock suficiente, false para que la UI lo maneje
                return false;
            }

            if (ExisteItem(idCarrito, idProducto))
            {
                ModificarCantidad(idCarrito, idProducto, cantidad);
            }
            else
            {
                AgregarItem(idCarrito, idProducto, cantidad);
            }

            return true;
        }

        public bool ExisteItem(int idCarrito, int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT 1 FROM Carrito_Item WHERE id_carrito = @idCarrito AND id_producto = @idProducto");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                return datos.Lector.Read();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si el item existe", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarCantidad(int idCarrito, int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Primero obtengo la cantidad actual
                int cantidadActual = ObtenerCantidad(idCarrito, idProducto);
                int nuevaCantidad = cantidadActual + cantidad;

                if (nuevaCantidad < 1)
                {
                    // Si queda menos de 1, elimino el item
                    EliminarItem(idCarrito, idProducto);
                }
                else
                {
                    // Sino actualizo la cantidad
                    datos.setearConsulta("UPDATE Carrito_Item SET cantidad = @cantidad WHERE id_carrito = @idCarrito AND id_producto = @idProducto");
                    datos.setearParametro("@cantidad", nuevaCantidad);
                    datos.setearParametro("@idCarrito", idCarrito);
                    datos.setearParametro("@idProducto", idProducto);
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la cantidad del item", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void AgregarItem(int idCarrito, int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Carrito_Item (id_carrito, id_producto, cantidad) VALUES (@idCarrito, @idProducto, @cantidad)");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.setearParametro("@cantidad", cantidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar nuevo item al carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int ObtenerCantidad(int idCarrito, int idProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT cantidad FROM Carrito_Item WHERE id_carrito = @idCarrito AND id_producto = @idProducto");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["cantidad"];
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la cantidad del item", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void EliminarItem(int idCarrito, int idProducto) //no confundir con el otro, este es para eliminar un producto del carrito
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM Carrito_Item WHERE id_carrito = @idCarrito AND id_producto = @idProducto");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar item del carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void EliminarItems(int idCarrito) //ojo este metodo es para eliminar TODOS los items asociados a un carrito, no es igual al anterior
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Carrito_Item WHERE id_carrito = @idCarrito");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar los ítems del carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}