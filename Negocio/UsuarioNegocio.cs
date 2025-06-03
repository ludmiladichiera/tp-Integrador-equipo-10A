using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio

    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT U.id_usuario, U.mail, U.pass, 
                   U.id_tipo_usuario, T.descripcion AS tipo_usuario,
                   U.dni, U.nombre, U.apellido, U.direccion, 
                   U.ciudad, U.codigo_postal, U.telefono
            FROM Usuario U
            JOIN TipoUsuario T ON U.id_tipo_usuario = T.id_tipo_usuario");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)datos.Lector["id_usuario"],
                        Mail = datos.Lector["mail"].ToString(),
                        Pass = datos.Lector["pass"].ToString(),
                        TipoUsuario = new TipoUsuario
                        {
                            Id = (int)datos.Lector["id_tipo_usuario"],
                            Descripcion = datos.Lector["tipo_usuario"].ToString()
                        },
                        Dni = datos.Lector["dni"].ToString(),
                        Nombre = datos.Lector["nombre"].ToString(),
                        Apellido = datos.Lector["apellido"].ToString(),
                        Direccion = datos.Lector["direccion"].ToString(),
                        Ciudad = datos.Lector["ciudad"].ToString(),
                        CodigoPostal = Convert.ToInt32(datos.Lector["codigo_postal"]),
                        Telefono = datos.Lector["telefono"].ToString()
                    };

                    lista.Add(usuario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los usuarios", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario Loguear(string mail, string pass)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT U.id_usuario, U.mail, U.pass, 
                   U.id_tipo_usuario, T.descripcion AS tipo_usuario,
                   U.dni, U.nombre, U.apellido, U.direccion, 
                   U.ciudad, U.codigo_postal, U.telefono
            FROM Usuario U
            JOIN TipoUsuario T ON U.id_tipo_usuario = T.id_tipo_usuario
            WHERE U.mail = @mail AND U.pass = @pass");

                datos.setearParametro("@mail", mail);
                datos.setearParametro("@pass", pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = (int)datos.Lector["id_usuario"],
                        Mail = datos.Lector["mail"].ToString(),
                        Pass = datos.Lector["pass"].ToString(),
                        TipoUsuario = new TipoUsuario
                        {
                            Id = (int)datos.Lector["id_tipo_usuario"],
                            Descripcion = datos.Lector["tipo_usuario"].ToString()
                        },
                        Dni = datos.Lector["dni"].ToString(),
                        Nombre = datos.Lector["nombre"].ToString(),
                        Apellido = datos.Lector["apellido"].ToString(),
                        Direccion = datos.Lector["direccion"].ToString(),
                        Ciudad = datos.Lector["ciudad"].ToString(),
                        CodigoPostal = Convert.ToInt32(datos.Lector["codigo_postal"]),
                        Telefono = datos.Lector["telefono"].ToString()
                    };

                    return usuario;
                }

                return null; // No se encontró usuario
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void RegistrarCliente(Usuario cliente)
        {
            if (EmailExiste(cliente.Mail))
                throw new Exception("Ya existe un usuario registrado con ese email.");

            if (!string.IsNullOrEmpty(cliente.Dni) && DniExiste(cliente.Dni))
                throw new Exception("Ya existe un usuario registrado con ese DNI.");

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Usuario 
            (mail, pass, id_tipo_usuario, dni, nombre, apellido, direccion, ciudad, codigo_postal, telefono)
            VALUES 
            (@mail, @pass, @id_tipo_usuario, @dni, @nombre, @apellido, @direccion, @ciudad, @codigo_postal, @telefono)");

                datos.setearParametro("@mail", cliente.Mail);
                datos.setearParametro("@pass", cliente.Pass);
                datos.setearParametro("@id_tipo_usuario", 1); // Siempre cliente
                //datos.setearParametro("@id_tipo_usuario", cliente.TipoUsuario.Id);
                datos.setearParametro("@dni", (object)cliente.Dni ?? DBNull.Value);
                datos.setearParametro("@nombre", (object)cliente.Nombre ?? DBNull.Value);
                datos.setearParametro("@apellido", (object)cliente.Apellido ?? DBNull.Value);
                datos.setearParametro("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                datos.setearParametro("@ciudad", (object)cliente.Ciudad ?? DBNull.Value);
                datos.setearParametro("@codigo_postal", cliente.CodigoPostal > 0 ? (object)cliente.CodigoPostal : DBNull.Value);
                datos.setearParametro("@telefono", (object)cliente.Telefono ?? DBNull.Value);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool EmailExiste(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(1) FROM Usuario WHERE mail = @mail");
                datos.setearParametro("@mail", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar email", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool DniExiste(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(1) FROM Usuario WHERE dni = @dni");
                datos.setearParametro("@dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar DNI", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}