using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        public List<TipoUsuario> Listar()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_tipo_usuario, descripcion FROM TipoUsuario");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario tipo = new TipoUsuario
                    {
                        Id = (int)datos.Lector["id_tipo_usuario"],
                        Descripcion = datos.Lector["descripcion"].ToString()
                    };

                    lista.Add(tipo);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los tipos de usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}


