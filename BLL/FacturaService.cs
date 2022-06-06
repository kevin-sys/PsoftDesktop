using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using ENTITY;
namespace BLL
{
    public class FacturaService
    {
        FacturaRepository facturaRepository;

        public FacturaService()
        {

            facturaRepository = new FacturaRepository();
        }

        public string GuardarFactura(Factura factura)
        {

            try
            {
                if (factura == null)
                {

                    return "No se guardo nada cole";
                }
                else
                {


                    facturaRepository.Guardar(factura);
                    return "Datos Guardados Satisfactoriamente";

                }


            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }


        }



        public string Guardar(Factura factura)
        {
             try
            {
                RespuestaBusqueda respuestaBusqueda = Buscar(factura.idfactura);
                string respuesta = IntentarGuardar(respuestaBusqueda, factura);
                return respuesta;
            }
            catch (Exception e)
            {

                return $"Error al Guardar datos : {e.Message}";
            }
        }

        public string IntentarGuardar(RespuestaBusqueda respuesta, Factura factura)
        {
            if (respuesta.factura == null)
            {
                facturaRepository.Guardar(factura);
                return $"Datos del Vehiculo Guardados con exito";
            }
            return " error la placa ya se encuentra registrada";
        }

        public RespuestaBusqueda Buscar(int id)
        {
            RespuestaBusqueda respuestaBusqueda = new RespuestaBusqueda();
            respuestaBusqueda.Error = false;
            try
            {
                respuestaBusqueda = ObtenerRespuestaBusqueda(respuestaBusqueda, id);
                return respuestaBusqueda;
            }
            catch (Exception e)
            {
               // respuestaBusqueda = ObtenerRespuestaBusqueda(respuestaBusqueda, e);
                return respuestaBusqueda;
            }
        }
        public RespuestaBusqueda ObtenerRespuestaBusqueda(RespuestaBusqueda respuestaBusqueda, int id)
        {
            respuestaBusqueda.factura = facturaRepository.Buscar(id);
            if (respuestaBusqueda.factura != null)
            {
                respuestaBusqueda.Mensaje = "Datos de la factura encontrado con exito";
            }
            else
            {
                respuestaBusqueda.Mensaje = "Los datos del numero de factura no se encuentra registrado";
            }
            return respuestaBusqueda;
        }

        public RespuestaConsulta Consultar()
        {
            RespuestaConsulta respuestaConsulta = new RespuestaConsulta();
            respuestaConsulta.Error = false;
            try
            {
                respuestaConsulta = ObtenerRespuestaConsulta(respuestaConsulta);
                return respuestaConsulta;
            }
            catch (Exception e)
            {
                return respuestaConsulta;
            }
        }

        public RespuestaConsulta ObtenerRespuestaConsulta(RespuestaConsulta respuestaConsulta)
        {
            respuestaConsulta.Facturas = facturaRepository.Consultar();
            if (respuestaConsulta.Facturas.Count > 0)
            {
                respuestaConsulta.Mensaje = "registro encontrado con exito";

            }
            else
            {
                respuestaConsulta.Mensaje = "no hay facturas registrados";
            }
            return respuestaConsulta;
        }


       

        




        


      

    }
}
