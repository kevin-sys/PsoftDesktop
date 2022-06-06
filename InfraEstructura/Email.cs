using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace InfraEstructura
{
    public class Email
    {


        private MailMessage Correo;
        private SmtpClient Smtp;

        public Email()
        {
            Smtp = new SmtpClient();
        }

        private void ConfigurarSmtp()
        {
            Smtp.Host = "smtp.gmail.com";
            Smtp.Port = 587;
            Smtp.EnableSsl = true;
            Smtp.UseDefaultCredentials = false;
            Smtp.Credentials = new NetworkCredential("bagranados@unicesar.edu.co", "123456789bg");
        }


        private void ConfigurarEmail(Cliente cliente)
        {
            Correo = new MailMessage();
            Correo.To.Add(cliente.email);
            Correo.From = new MailAddress(cliente.email);
            Correo.Subject = "Factura de Compra " + DateTime.Now.ToString("dd/MMM/yyy hh:mm:ss");

            Correo.Body = $"<b> {cliente.nombre} </b" +
                $">Gracias por tu compra en Percy's , deseamos seguir contando con personas especiales como tu";
            Correo.IsBodyHtml = true;
            Correo.Priority = MailPriority.Normal;
        }

        public string EnviarEmail(Cliente cliente)
        {
            try
            {
                ConfigurarSmtp();
                ConfigurarEmail(cliente);
                Smtp.Send(Correo);
                return $"Correo enviado Satisfactoriamente. ";
            }
            catch (Exception e)
            {
                return $"Error al enviar el correo {e.Message.ToString()}";
            }
            finally
            {
                Correo.Dispose();
            }
        }


    }
}
