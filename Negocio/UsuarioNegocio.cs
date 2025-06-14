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
                   U.ciudad, U.codigo_postal, U.telefono, U.estado
            FROM Usuario U
            JOIN TipoUsuario T ON U.id_tipo_usuario = T.id_tipo_usuario");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = datos.Lector["id_usuario"] != DBNull.Value ? (int)datos.Lector["id_usuario"] : 0,
                        Mail = datos.Lector["mail"] != DBNull.Value ? datos.Lector["mail"].ToString() : "",
                        Pass = datos.Lector["pass"] != DBNull.Value ? datos.Lector["pass"].ToString() : "",
                        TipoUsuario = new TipoUsuario
                        {
                            Id = datos.Lector["id_tipo_usuario"] != DBNull.Value ? (int)datos.Lector["id_tipo_usuario"] : 0,
                            Descripcion = datos.Lector["tipo_usuario"] != DBNull.Value ? datos.Lector["tipo_usuario"].ToString() : ""
                        },
                        Dni = datos.Lector["dni"] != DBNull.Value ? datos.Lector["dni"].ToString() : "",
                        Nombre = datos.Lector["nombre"] != DBNull.Value ? datos.Lector["nombre"].ToString() : "",
                        Apellido = datos.Lector["apellido"] != DBNull.Value ? datos.Lector["apellido"].ToString() : "",
                        Direccion = datos.Lector["direccion"] != DBNull.Value ? datos.Lector["direccion"].ToString() : "",
                        Ciudad = datos.Lector["ciudad"] != DBNull.Value ? datos.Lector["ciudad"].ToString() : "",
                        CodigoPostal = datos.Lector["codigo_postal"] != DBNull.Value ? Convert.ToInt32(datos.Lector["codigo_postal"]) : 0,
                        Telefono = datos.Lector["telefono"] != DBNull.Value ? datos.Lector["telefono"].ToString() : "",
                        Estado = datos.Lector["estado"] != DBNull.Value ? (bool)datos.Lector["estado"] : false
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
            WHERE U.mail = @mail AND U.pass = @pass AND U.estado = 1");

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
                //string hash = BCrypt.Net.BCrypt.HashPassword(cliente.Pass);

                datos.setearConsulta(@"INSERT INTO Usuario 
            (mail, pass, id_tipo_usuario, dni, nombre, apellido, direccion, ciudad, codigo_postal, telefono, estado)
            VALUES 
            (@mail, @pass, @id_tipo_usuario, @dni, @nombre, @apellido, @direccion, @ciudad, @codigo_postal, @telefono, @estado)");

                datos.setearParametro("@mail", cliente.Mail);
                //datos.setearParametro("@pass", cliente.hash);
                datos.setearParametro("@pass", cliente.Pass);
                datos.setearParametro("@id_tipo_usuario", 1); // siempre cliente
                //datos.setearParametro("@id_tipo_usuario", cliente.TipoUsuario.Id);
                datos.setearParametro("@dni", (object)cliente.Dni ?? DBNull.Value);
                datos.setearParametro("@nombre", (object)cliente.Nombre ?? DBNull.Value);
                datos.setearParametro("@apellido", (object)cliente.Apellido ?? DBNull.Value);
                datos.setearParametro("@direccion", (object)cliente.Direccion ?? DBNull.Value);
                datos.setearParametro("@ciudad", (object)cliente.Ciudad ?? DBNull.Value);
                datos.setearParametro("@codigo_postal", cliente.CodigoPostal > 0 ? (object)cliente.CodigoPostal : DBNull.Value);
                datos.setearParametro("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                datos.setearParametro("@estado", true); //siempre activo

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

        public void DarDeBajaUsuario(int idUsuario) //seria eliminar suscripcion 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET estado = 0 WHERE id_usuario = @id");
                datos.setearParametro("@id", idUsuario);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ReactivarUsuario(int idUsuario) //seria como recuperar cuenta, nose
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuario SET estado = 1 WHERE id_usuario = @id");
                datos.setearParametro("@id", idUsuario);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al reactivar el usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuario = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT U.id_usuario, U.mail, U.pass, 
                   U.id_tipo_usuario, T.descripcion AS tipo_usuario,
                   U.dni, U.nombre, U.apellido, U.direccion, 
                   U.ciudad, U.codigo_postal, U.telefono, U.estado
            FROM Usuario U
            JOIN TipoUsuario T ON U.id_tipo_usuario = T.id_tipo_usuario
            WHERE U.id_usuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario
                    {
                        Id = datos.Lector["id_usuario"] != DBNull.Value ? (int)datos.Lector["id_usuario"] : 0,
                        Mail = datos.Lector["mail"] != DBNull.Value ? datos.Lector["mail"].ToString() : "",
                        Pass = datos.Lector["pass"] != DBNull.Value ? datos.Lector["pass"].ToString() : "",
                        TipoUsuario = new TipoUsuario
                        {
                            Id = datos.Lector["id_tipo_usuario"] != DBNull.Value ? (int)datos.Lector["id_tipo_usuario"] : 0,
                            Descripcion = datos.Lector["tipo_usuario"] != DBNull.Value ? datos.Lector["tipo_usuario"].ToString() : ""
                        },
                        Dni = datos.Lector["dni"] != DBNull.Value ? datos.Lector["dni"].ToString() : "",
                        Nombre = datos.Lector["nombre"] != DBNull.Value ? datos.Lector["nombre"].ToString() : "",
                        Apellido = datos.Lector["apellido"] != DBNull.Value ? datos.Lector["apellido"].ToString() : "",
                        Direccion = datos.Lector["direccion"] != DBNull.Value ? datos.Lector["direccion"].ToString() : "",
                        Ciudad = datos.Lector["ciudad"] != DBNull.Value ? datos.Lector["ciudad"].ToString() : "",
                        CodigoPostal = datos.Lector["codigo_postal"] != DBNull.Value ? Convert.ToInt32(datos.Lector["codigo_postal"]) : 0,
                        Telefono = datos.Lector["telefono"] != DBNull.Value ? datos.Lector["telefono"].ToString() : "",
                        Estado = datos.Lector["estado"] != DBNull.Value ? (bool)datos.Lector["estado"] : false
                    };
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuario por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public bool ModificarContrasenia(int idUsuario, string contraseniaActual, string nuevaContrasenia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Obtener la contraseña actual de la BD
                datos.setearConsulta("SELECT pass FROM Usuario WHERE id_usuario = @id");
                datos.setearParametro("@id", idUsuario);
                datos.ejecutarLectura();

                if (!datos.Lector.Read())
                    throw new Exception("Usuario no encontrado");

                string passActualBD = (string)datos.Lector["pass"];

                if (passActualBD != contraseniaActual)
                    return false; // La contraseña actual no coincide

                datos.cerrarConexion();

                // Actualizar la contraseña por la nueva
                datos = new AccesoDatos();
                datos.setearConsulta("UPDATE Usuario SET pass = @nueva WHERE id_usuario = @id");
                datos.setearParametro("@nueva", nuevaContrasenia);
                datos.setearParametro("@id", idUsuario);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la contraseña", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                // Modificar solo los campos permitidos (sin modificar mail, pass, dni, id, tipo, estado)
                datos.setearConsulta(@"UPDATE Usuario SET
            direccion = @direccion,
            ciudad = @ciudad,
            codigo_postal = @codigo_postal,
            telefono = @telefono
            WHERE id_usuario = @id_usuario");

                datos.setearParametro("@direccion", (object)usuario.Direccion ?? DBNull.Value);
                datos.setearParametro("@ciudad", (object)usuario.Ciudad ?? DBNull.Value);
                datos.setearParametro("@codigo_postal", usuario.CodigoPostal > 0 ? (object)usuario.CodigoPostal : DBNull.Value);
                datos.setearParametro("@telefono", (object)usuario.Telefono ?? DBNull.Value);
                datos.setearParametro("@id_usuario", usuario.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Usuario> BuscarPorDniOMail(string filtro) //filtro para el admin
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT U.id_usuario, U.mail, U.pass, 
                   U.id_tipo_usuario, T.descripcion AS tipo_usuario,
                   U.dni, U.nombre, U.apellido, U.direccion, 
                   U.ciudad, U.codigo_postal, U.telefono, U.estado
            FROM Usuario U
            JOIN TipoUsuario T ON U.id_tipo_usuario = T.id_tipo_usuario
            WHERE U.dni LIKE @filtro OR U.mail LIKE @filtro");

                datos.setearParametro("@filtro", "%" + filtro + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = datos.Lector["id_usuario"] != DBNull.Value ? (int)datos.Lector["id_usuario"] : 0,
                        Mail = datos.Lector["mail"] != DBNull.Value ? datos.Lector["mail"].ToString() : "",
                        Pass = datos.Lector["pass"] != DBNull.Value ? datos.Lector["pass"].ToString() : "",
                        TipoUsuario = new TipoUsuario
                        {
                            Id = datos.Lector["id_tipo_usuario"] != DBNull.Value ? (int)datos.Lector["id_tipo_usuario"] : 0,
                            Descripcion = datos.Lector["tipo_usuario"] != DBNull.Value ? datos.Lector["tipo_usuario"].ToString() : ""
                        },
                        Dni = datos.Lector["dni"] != DBNull.Value ? datos.Lector["dni"].ToString() : "",
                        Nombre = datos.Lector["nombre"] != DBNull.Value ? datos.Lector["nombre"].ToString() : "",
                        Apellido = datos.Lector["apellido"] != DBNull.Value ? datos.Lector["apellido"].ToString() : "",
                        Direccion = datos.Lector["direccion"] != DBNull.Value ? datos.Lector["direccion"].ToString() : "",
                        Ciudad = datos.Lector["ciudad"] != DBNull.Value ? datos.Lector["ciudad"].ToString() : "",
                        CodigoPostal = datos.Lector["codigo_postal"] != DBNull.Value ? Convert.ToInt32(datos.Lector["codigo_postal"]) : 0,
                        Telefono = datos.Lector["telefono"] != DBNull.Value ? datos.Lector["telefono"].ToString() : "",
                        Estado = datos.Lector["estado"] != DBNull.Value ? (bool)datos.Lector["estado"] : false
                    };

                    lista.Add(usuario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar usuarios", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}