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
        public void EliminarCarrito(int idCarrito) //metodo nuevo, al hacer el pedido se borra ese carrito
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Carrito WHERE id_carrito = @idCarrito");
                datos.setearParametro("@idCarrito", idCarrito);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el carrito", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Carrito> ListarCarritosMayoresA4Dias() //metodo para q el admin pueda ver carritos viejos
        {
            List<Carrito> lista = new List<Carrito>();
            AccesoDatos datos = new AccesoDatos();
            DateTime fechaLimite = DateTime.Now.AddDays(-4);

            try
            {
                datos.setearConsulta(@"
SELECT c.id_carrito, c.id_usuario, c.fecha_creacion,
       u.mail, u.nombre, u.apellido
FROM Carrito c
LEFT JOIN Usuario u ON u.id_usuario = c.id_usuario
WHERE c.fecha_creacion < @fechaLimite
ORDER BY c.fecha_creacion ASC");

                datos.setearParametro("@fechaLimite", fechaLimite);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Carrito carrito = new Carrito
                    {
                        Id = (int)datos.Lector["id_carrito"],
                        FechaCreacion = (DateTime)datos.Lector["fecha_creacion"],
                        Usuario = new Usuario
                        {
                            Id = (int)datos.Lector["id_usuario"],
                            Mail = datos.Lector["mail"].ToString(),
                            Nombre = datos.Lector["nombre"].ToString(),
                            Apellido = datos.Lector["apellido"].ToString()
                        }
                    };

                    lista.Add(carrito);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar carritos con más de 4 días", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarCarritosViejos() //metodo para q el admin elimine esos carritos viejos
        {
            CarritoItemNegocio itemNegocio = new CarritoItemNegocio();
            List<Carrito> carritosViejos = ListarCarritosMayoresA4Dias();

            foreach (var carrito in carritosViejos)
            {
                itemNegocio.EliminarItems(carrito.Id);     // borrar los ítems del carrito
                EliminarCarrito(carrito.Id);               //  borrar el carrito
            }
        }
    }
}

 