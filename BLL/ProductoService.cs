using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using ENTITY;
namespace BLL
{
    public class ProductoService
    {
        private static ProductoRepository productoRepository = new ProductoRepository();
        List<Producto> productos;


        public ProductoService()
        {

            productoRepository = new ProductoRepository();


        }


        public string Guardar(Producto producto)
        {

            try
            {
                if (producto == null)
                {

                    return "No se guardo nada cole";
                }
                else
                {


                    productoRepository.Guardar(producto);
                    return "Datos Guardados Satisfactoriamente";

                }


            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }


        }


        public static IList<Producto> ConsultarTodos()
        {
            return productoRepository.ConsultarKEVIN();
        }


        public class ConsultaResponse
        {
            public List<Producto> Producto { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public ConsultaResponse(List<Producto> productos)
            {
                Producto = productos;
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
