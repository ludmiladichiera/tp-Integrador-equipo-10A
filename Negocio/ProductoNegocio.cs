using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=Ecommerce; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = @"
SELECT 
    P.id_producto AS Id,
    P.codigo AS Codigo,
    P.nombre AS Nombre,
    P.descripcion AS Descripcion,
    P.precio AS Precio,
    P.stock AS Stock,
    P.unidad_venta AS UnidadVenta,
    P.id_categoria AS IdCategoria,
    C.descripcion AS Categoria,
    MIN(I.url) AS ImagenUrl
FROM Producto P
JOIN Categoria C ON P.id_categoria = C.id_categoria
LEFT JOIN Imagen I ON P.id_producto = I.id_producto
GROUP BY
    P.id_producto, P.codigo, P.nombre, P.descripcion, P.precio, P.stock, 
    P.unidad_venta, P.id_categoria, C.descripcion";

                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = lector["Id"] != DBNull.Value ? (int)lector["Id"] : 0;
                    aux.Codigo = lector["Codigo"] != DBNull.Value ? lector["Codigo"].ToString() : "No especifica";
                    aux.Nombre = lector["Nombre"] != DBNull.Value ? lector["Nombre"].ToString() : "No especifica";
                    aux.Descripcion = lector["Descripcion"] != DBNull.Value ? lector["Descripcion"].ToString() : "No especifica";
                    aux.Precio = lector["Precio"] != DBNull.Value ? (decimal)lector["Precio"] : 0;
                    aux.Stock = lector["Stock"] != DBNull.Value ? (int)lector["Stock"] : 0;                 // <- agregá esto
                    aux.UnidadVenta = lector["UnidadVenta"] != DBNull.Value ? lector["UnidadVenta"].ToString() : "No especifica";  // <- y esto si lo necesitás

                    // Categoría
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : 0;
                    aux.Categoria.Descripcion = lector["Categoria"] != DBNull.Value ? lector["Categoria"].ToString() : "No especifica";

                    if (aux.Imagenes == null)
                        aux.Imagenes = new List<Imagen>();

                    if (!(lector["ImagenUrl"] is DBNull))
                    {
                        aux.Imagenes.Add(new Imagen(lector["ImagenUrl"].ToString()));
                    }
                    else
                    {
                        aux.Imagenes.Add(new Imagen("https://media.istockphoto.com/id/1128826884/es/vector/ning%C3%BAn-s%C3%ADmbolo-de-vector-de-imagen-falta-icono-disponible-no-hay-galer%C3%ADa-para-este-momento.jpg?s=612x612&w=0&k=20&c=9vnjI4XI3XQC0VHfuDePO7vNJE7WDM8uzQmZJ1SnQgk="));
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public int agregarProductoYDevolverId(Producto nuevoProducto)
        {
            int idGenerado;
            SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Ecommerce; integrated security=true");
            SqlCommand comando = new SqlCommand();

            try
            {
                comando.Connection = conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = @"
INSERT INTO Producto 
    (codigo, nombre, descripcion, precio, stock, unidad_venta, id_categoria) 
VALUES 
    (@Codigo, @Nombre, @Descripcion, @Precio, @Stock, @UnidadVenta, @IdCategoria);
SELECT SCOPE_IDENTITY();";

                comando.Parameters.AddWithValue("@Codigo", string.IsNullOrWhiteSpace(nuevoProducto.Codigo)
                    ? (object)DBNull.Value
                    : nuevoProducto.Codigo);

                comando.Parameters.AddWithValue("@Nombre", string.IsNullOrWhiteSpace(nuevoProducto.Nombre)
                    ? (object)DBNull.Value
                    : nuevoProducto.Nombre);

                comando.Parameters.AddWithValue("@Descripcion", string.IsNullOrWhiteSpace(nuevoProducto.Descripcion)
                    ? (object)DBNull.Value
                    : nuevoProducto.Descripcion);

                comando.Parameters.AddWithValue("@Precio", nuevoProducto.Precio);

                comando.Parameters.AddWithValue("@Stock", nuevoProducto.Stock);

                comando.Parameters.AddWithValue("@UnidadVenta", string.IsNullOrWhiteSpace(nuevoProducto.UnidadVenta)
                    ? (object)DBNull.Value
                    : nuevoProducto.UnidadVenta);

                comando.Parameters.AddWithValue("@IdCategoria", nuevoProducto.Categoria?.Id ?? (object)DBNull.Value);


                conexion.Open();
                idGenerado = Convert.ToInt32(comando.ExecuteScalar());
                return idGenerado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

        }

        /*
        public void agregarImagenUrl(int idProducto, List<Imagen> imagenes)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (Imagen imagen in imagenes)
                {
                    datos.setearConsulta("INSERT INTO Imagen (id_producto, url) VALUES (@IdProducto, @Url)");
                    datos.setearParametro("@IdProducto", idProducto);
                    datos.setearParametro("@Url", imagen.Url); 
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        */

        public Producto ObtenerProductoId(int idProducto)
        {
            Producto producto = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT P.id_producto AS Id, P.codigo AS Codigo, P.nombre AS Nombre, P.descripcion AS Descripcion, P.precio AS Precio, P.stock AS Stock, P.unidad_venta AS UnidadVenta, P.id_categoria AS IdCategoria, C.descripcion AS Categoria " +
                   "FROM Producto P " +
                   "INNER JOIN Categoria C ON P.id_categoria = C.id_categoria " +
                   "WHERE P.id_producto = @Id");

                datos.setearParametro("@Id", idProducto);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)datos.Lector["Id"];
                    prod.Codigo = datos.Lector["Codigo"].ToString();
                    prod.Nombre = datos.Lector["Nombre"].ToString();
                    prod.Descripcion = datos.Lector["Descripcion"].ToString();
                    prod.Precio = (decimal)datos.Lector["Precio"];
                    prod.Stock = (int)datos.Lector["Stock"];
                    prod.UnidadVenta = datos.Lector["UnidadVenta"].ToString();
                    prod.Categoria = new Categoria((int)datos.Lector["IdCategoria"], datos.Lector["Categoria"].ToString());
                    producto = prod;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return producto;
        }
        /*
            public void Modificar(Producto modificar) //nose para que lo usamos
            {
                AccesoDatos datos = new AccesoDatos();
                modificarProducto(modificar);
                int idProducto = datos.obtenerIdProducto(modificar.Codigo);
                
            }*/

        public void modificarProducto(Producto modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Producto SET codigo = @Codigo, nombre = @Nombre, descripcion = @Descripcion, id_categoria = @IdCategoria, precio = @Precio, stock = @Stock, unidad_venta = @UnidadVenta WHERE id_producto = @Id");

                datos.setearParametro("@Codigo", modificar.Codigo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@IdCategoria", modificar.Categoria.Id);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@Stock", modificar.Stock);
                datos.setearParametro("@UnidadVenta", modificar.UnidadVenta);
                datos.setearParametro("@Id", modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        /*
        public void modificarImagenUrl(int idProducto, List<Imagen> imagenes)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                foreach (Imagen imagen in imagenes)
                {
                    datos.setearConsulta("INSERT INTO Imagen (id_producto, url) VALUES (@IdProducto, @Url)");
                    datos.setearParametro("@IdProducto", idProducto);
                    datos.setearParametro("@Url", imagen.Url);  // La propiedad debe llamarse Url
                    datos.ejecutarAccion();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/

        public void EliminarProducto(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM Producto WHERE id_producto = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Producto> filtrar(string campo, string criterio, string filtro)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"SELECT 
                            P.id_producto AS Id, 
                            P.codigo AS Codigo, 
                            P.nombre AS Nombre, 
                            P.descripcion AS Descripcion, 
                            P.precio AS Precio,
                            P.stock AS Stock,
                            P.unidad_venta AS UnidadVenta,
                            C.descripcion AS Categoria,
                            MIN(I.url) AS ImagenesUrl
                        FROM Producto P
                        LEFT JOIN Categoria C ON P.id_categoria = C.id_categoria
                        LEFT JOIN Imagen I ON P.id_producto = I.id_producto
                        WHERE ";

                if (campo == "Codigo")
                {
                    consulta += "P.codigo LIKE @filtro";
                }
                else if (campo == "Nombre")
                {
                    consulta += "P.nombre LIKE @filtro";
                }
                else if (campo == "Descripcion")
                {
                    consulta += "P.descripcion LIKE @filtro";
                }
                else if (campo == "Categoria")
                {
                    consulta += "C.descripcion LIKE @filtro";
                }
                else if (campo == "Precio")
                {
                    if (decimal.TryParse(filtro, out decimal precio))
                    {
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "P.precio > @filtro";
                                break;
                            case "Menor a":
                                consulta += "P.precio < @filtro";
                                break;
                            default:
                                consulta += "P.precio = @filtro";
                                break;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("El filtro para el precio debe ser un número válido.");
                    }
                }

                consulta += @" GROUP BY 
                    P.id_producto, P.codigo, P.nombre, P.descripcion, P.precio, P.stock, P.unidad_venta, C.descripcion";

                datos.setearConsulta(consulta);

                if (campo == "Precio")
                    datos.setearParametro("@filtro", filtro);
                else
                    datos.setearParametro("@filtro", "%" + filtro + "%");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.UnidadVenta = datos.Lector["UnidadVenta"].ToString();

                    aux.Categoria = new Categoria { Descripcion = datos.Lector["Categoria"].ToString() };

                    aux.Imagenes = new List<Imagen>();
                    if (!(datos.Lector["ImagenesUrl"] is DBNull))
                        aux.Imagenes.Add(new Imagen(datos.Lector["ImagenesUrl"].ToString()));

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool existeCodigo(string codigo) //para alta, ver de integrar al otro metodo
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Producto WHERE codigo = @codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool existeCodigoEnOtroProducto(string codigo, int idProducto) //para modificacion
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Producto WHERE codigo = @codigo AND id_producto <> @id");
                datos.setearParametro("@codigo", codigo);
                datos.setearParametro("@id", idProducto);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool existeProductoPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Producto WHERE id_producto = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector[0] > 0;

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Producto> buscarRapido(string texto)
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"SELECT 
                    P.id_producto AS Id, 
                    P.codigo AS Codigo, 
                    P.nombre AS Nombre, 
                    P.descripcion AS Descripcion, 
                    P.precio AS Precio,
                    P.stock AS Stock,
                    P.unidad_venta AS UnidadVenta,
                    C.descripcion AS Categoria,
                    MIN(I.url) AS ImagenesUrl
                FROM Producto P
                LEFT JOIN Categoria C ON P.id_categoria = C.id_categoria
                LEFT JOIN Imagen I ON P.id_producto = I.id_producto
                WHERE 
                    P.nombre LIKE @texto OR 
                    P.descripcion LIKE @texto OR 
                    C.descripcion LIKE @texto
                GROUP BY 
                    P.id_producto, P.codigo, P.nombre, P.descripcion, P.precio, P.stock, P.unidad_venta, C.descripcion";

                datos.setearConsulta(consulta);
                datos.setearParametro("@texto", "%" + texto + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.UnidadVenta = datos.Lector["UnidadVenta"].ToString();
                    aux.Categoria = new Categoria { Descripcion = datos.Lector["Categoria"].ToString() };

                    aux.Imagenes = new List<Imagen>();
                    if (!(datos.Lector["ImagenesUrl"] is DBNull))
                        aux.Imagenes.Add(new Imagen(datos.Lector["ImagenesUrl"].ToString()));

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }


}



