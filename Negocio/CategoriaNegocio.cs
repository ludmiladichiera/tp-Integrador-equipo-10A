using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_categoria, descripcion, estado FROM CATEGORIA");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["id_categoria"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Estado = (bool)datos.Lector["estado"];

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

        public void agregar(Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Categoria (descripcion, estado) VALUES (@Descripcion, @Estado)");
                datos.setearParametro("@Descripcion", nuevaCategoria.Descripcion);
                datos.setearParametro("@Estado", nuevaCategoria.Estado);
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
        public void Modificar(Categoria modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            modificarCategoria(modificar);
        }
        public void modificarCategoria(Categoria modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Categoria SET descripcion = @descripcion WHERE id_categoria = @id");
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@id", modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la categoría", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void DesactivarCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Categoria SET estado = 0 WHERE id_categoria = @id");
                datos.setearParametro("@id", idCategoria);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la categoría", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void ReactivarCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Categoria SET estado = 1 WHERE id_categoria = @id");
                datos.setearParametro("@id", idCategoria);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al reactivar la categoría", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool existeCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Categoria WHERE id_categoria = @id");
                datos.setearParametro("@id", idCategoria);
                datos.ejecutarLectura();
                return datos.Lector.Read() && (int)datos.Lector[0] > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Categoria categoriaXdescripcion(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();
            Categoria categoria = new Categoria();
            try
            {
                datos.setearConsulta("SELECT id_categoria,descripcion From Categoria WHERE descripcion=@descripcion");
                datos.setearParametro("@descripcion", descripcion);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    categoria.Id = (int)datos.Lector["id_categoria"];
                    categoria.Descripcion = (string)datos.Lector["descripcion"];

                }
                return categoria;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}








