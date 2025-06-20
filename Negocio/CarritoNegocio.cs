using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoNegocio
    {
        public int CrearCarrito(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Carrito (id_usuario, fecha_creacion) VALUES (@idUsuario, @fechaCreacion); SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@idUsuario", idUsuario);

                datos.setearParametro("@fechaCreacion", DateTime.Now);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return Convert.ToInt32(datos.Lector[0]);
                }
                else
                    throw new Exception("No se pudo crear el carrito");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        /*public Carrito ObtenerCarrito(int idCarrito)
         {
             Carrito carrito = null;
             AccesoDatos datos = new AccesoDatos();

             try
             {
                 datos.setearConsulta(@"
     SELECT c.id_carrito, c.id_usuario, c.fecha_creacion,
            u.id_usuario, u.mail, u.nombre, u.apellido,
            ci.id_producto, ci.cantidad,
            p.id_producto, p.nombre AS nombreProducto, p.precio
     FROM Carrito c
     LEFT JOIN Usuario u ON c.id_usuario = u.id_usuario
     LEFT JOIN Carrito_Item ci ON c.id_carrito = ci.id_carrito
     LEFT JOIN Producto p ON ci.id_producto = p.id_producto
     WHERE c.id_carrito = @idCarrito
 ");
                 datos.setearParametro("@idCarrito", idCarrito);
                 datos.ejecutarLectura();

                 carrito = new Carrito();
                 carrito.Items = new List<CarritoItem>();

                 while (datos.Lector.Read())
                 {
                     if (carrito.Id == 0)
                     {
                         carrito.Id = (int)datos.Lector["id_carrito"];
                         carrito.FechaCreacion = (DateTime)datos.Lector["fecha_creacion"];

                         if (datos.Lector["id_usuario"] != DBNull.Value)
                         {
                             carrito.Usuario = new Usuario
                             {
                                 Id = (int)datos.Lector["id_usuario"],
                                 Mail = datos.Lector["mail"].ToString(),
                                 Nombre = datos.Lector["nombre"].ToString(),
                                 Apellido = datos.Lector["apellido"].ToString()
                             };
                         }
                     }


                     if (datos.Lector["id_producto"] != DBNull.Value)
                     {
                         carrito.Items.Add(new CarritoItem
                         {
                             Producto = new Producto
                             {
                                 Id = (int)datos.Lector["id_producto"],
                                 Nombre = datos.Lector["nombreProducto"].ToString(),
                                 Precio = (decimal)datos.Lector["precio"]
                             },
                             Cantidad = (int)datos.Lector["cantidad"]
                         });
                     }
                 }

                 return carrito;
             }
             catch (Exception ex)
             {
                 throw new Exception("Error al obtener carrito", ex);
             }
             finally
             {
                 datos.cerrarConexion();
             }
         }/*

         /*public void GuardarItems(int idCarrito, List<CarritoItem> items)
         {
             AccesoDatos datos = new AccesoDatos();

             try
             {
                 // Primero, eliminar items actuales para reemplazar
                 datos.setearConsulta("DELETE FROM Carrito_Item WHERE id_carrito = @idCarrito");
                 datos.setearParametro("@idCarrito", idCarrito);
                 datos.ejecutarAccion();

                 // Insertar cada item nuevo
                 foreach (var item in items)
                 {
                     datos.setearConsulta("INSERT INTO Carrito_Item (id_carrito, id_producto, cantidad) VALUES (@idCarrito, @idProducto, @cantidad)");
                     datos.setearParametro("@idCarrito", idCarrito);
                     datos.setearParametro("@idProducto", item.Producto.Id);
                     datos.setearParametro("@cantidad", item.Cantidad);
                     datos.ejecutarAccion();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception("Error al guardar items del carrito", ex);
             }
             finally
             {
                 datos.cerrarConexion();
             }
         }
        */

        public int ObtenerUltimoCarritoIdPorUsuario(int idUsuario)//para que me cargue el ultimo carrito del usuario si es q tiene
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT TOP 1 id_carrito 
            FROM Carrito 
            WHERE id_usuario = @idUsuario 
            ORDER BY fecha_creacion DESC");

                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["id_carrito"];
                }
                else
                {
                    // No tiene carrito
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último carrito del usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}