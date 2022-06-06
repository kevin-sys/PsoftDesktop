using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DALL;
namespace BLL
{
    public  class DetalledeFacturaService
    {

         DetalledeFacturaRepository detalledeFacturaRepository; 

        public DetalledeFacturaService()
        {

            detalledeFacturaRepository = new DetalledeFacturaRepository();


        }


        public string GuardarEnRango(List <DetalledeFactura> detalledeFacturas)
        {

            try
            {
                if (detalledeFacturas is null && detalledeFacturas.Count == 0)
                {

                    return "No se Guardo";
                }
                
                detalledeFacturaRepository.Guardar(detalledeFacturas);
                return "Datos Guardados Satisfactoriamente";


            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }


        }


        public DetalledeFactura BuscarPorIdentificacion(int Id)
        {

            foreach (var item in Consultar().DetalledeFacturas)
            {
                if (item.CodigoVenta.Equals(Id))
                {
                    return item;
                }
            }
            return null;
        }

        public ConsultaResponse Consultar()
        {
            ConsultaResponse response;

            try
            {
                response = new ConsultaResponse(detalledeFacturaRepository.Consultar());
                return response;
            }
            catch (Exception exception)
            {
                response = new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
                response.DetalledeFacturas = null;
                return response;
            }

        }


        public class ConsultaResponse
        {
            public List<DetalledeFactura> DetalledeFacturas { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public ConsultaResponse(List<DetalledeFactura> detalledeFacturas)
            {
                DetalledeFacturas = detalledeFacturas;
                Error = false;
            }

            public ConsultaResponse(string mensaje)
            {
                Mensaje = mensaje;
                Error = true;
            }

        }




    }
}
