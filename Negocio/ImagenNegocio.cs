﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar(int idProducto)
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT id_imagen, id_producto,imagen_url FROM Imagen WHERE id_producto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Id = (int)datos.Lector["id_imagen"];
                    imagen.IdProducto = (int)datos.Lector["id_producto"];
                    imagen.Url = datos.Lector["imagen_url"].ToString();

                    lista.Add(imagen);
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

        public void Agregar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Imagen (id_producto, imagen_url) VALUES (@idProducto, @imagen_url)");
                datos.setearParametro("@idProducto", imagen.IdProducto);
                datos.setearParametro("@imagen_url", imagen.Url);
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

        public void eliminarImagen(int idImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Imagen WHERE id_imagen = @idImagen");
                datos.setearParametro("@idImagen", idImagen);
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

        public void modificarImagenUrl(int idProducto, List<Imagen> imagenes)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("DELETE FROM Imagen WHERE id_producto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarAccion();


                foreach (Imagen imagen in imagenes)
                {
                    datos.setearConsulta("INSERT INTO Imagen (id_producto, imagen_url) VALUES (@idProducto, @imagen_url)");
                    datos.setearParametro("@idProducto", idProducto);
                    datos.setearParametro("@imagen_url", imagen.Url);
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
    

        public void modificarImagenPorID(int idImagen, string url)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Imagen SET imagen_url = @url WHERE id_imagen = @idImagen");
                datos.setearParametro("@idImagen", idImagen);
                datos.setearParametro("@url", url);
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
        public int obtenerIDproduto(int idImgn)
        {
            int idProd = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id_producto from Imagen where id_imagen=@idImgn");
                datos.setearParametro("@idImgn", idImgn);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    idProd = (int)datos.Lector["id_producto"];
                }
                return idProd;
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

        public List<string> obtenerImagenesAleatorias(int cantidad)
        {
            List<string> lista = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            SELECT TOP (@cantidad) imagen_url 
            FROM Imagen 
            ORDER BY NEWID()");
                datos.setearParametro("@cantidad", cantidad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    lista.Add(datos.Lector["imagen_url"].ToString());
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

