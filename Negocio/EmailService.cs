using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("fdd7ac65bff015", "0be0881a4f44dd");
            //server.Credentials = new NetworkCredential("grupo10.programacion3@gmail.com", "grupo10p3");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "smtp.mailtrap.io";

        }



        public void armarCorreo( string nombre, string apellido, string mail, string tema, string mensaje)
        {
            string subjet = tema + " - " + nombre + " "+ apellido;
            string emailDestino = "grupo10.programacion3@gmail.com";
            email = new MailMessage();
            email.From = new MailAddress("grupo10.programacion3@gmail.com");
            email.To.Add(emailDestino); // acá ponés el correo del equipo técnico
            email.Subject = subjet;
            email.IsBodyHtml = true;

            email.Body = "<div style=\"max-width: 600px; margin: auto; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); padding: 30px; font-family: sans-serif;\">\r\n" +
                "    <h2 style=\"color: #333;\">🧾 Nueva consulta recibida desde el formulario de contacto</h2>\r\n" +
                "    <p style=\"font-size: 16px;\">\r\n" +
                "      <strong>Nombre:</strong> " + nombre + " " + apellido + "<br>\r\n" +
                "      <strong>Email:</strong> " + mail + "<br>\r\n" +
                "      <strong>Tema:</strong> " + tema + "\r\n" +
                "    </p>\r\n" +
                "    <hr style=\"margin: 20px 0;\">\r\n" +
                "    <p style=\"font-size: 16px;\"><strong>Mensaje:</strong><br><br>" + mensaje + "</p>\r\n" +
                "    <hr style=\"margin: 30px 0;\">\r\n" +
                "    <p style=\"font-size: 14px; color: #777;\">\r\n" +
                "      Este mensaje fue generado automáticamente desde el formulario de contacto del sitio web.\r\n" +
                "    </p>\r\n" +
                "</div>";
        }


        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
