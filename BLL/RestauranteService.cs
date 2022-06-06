using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using ENTITY;


namespace BLL
{
    public class RestauranteService
    {
       RestauranteRepository restauranteRepository;

        public RestauranteService()
        {

            restauranteRepository = new RestauranteRepository();

        }


        public string Guardar(Restaurante restaurante)
        {

            try
            {
                if (restaurante == null)
                {

                    return "No se guardo nada cole";
                }
                else
                {


                    restauranteRepository.Guardar(restaurante);
                    return "Datos Guardados Satisfactoriamente";

                }


            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }


        }


        public Restaurante BuscarPorIdentificacion(int Id)
        {

            foreach (var item in Consultar().Restaurantes)
            {
                if (item.nit.Equals(Id))
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
                response = new ConsultaResponse(restauranteRepository.Consultar());
                return response;
            }
            catch (Exception exception)
            {
                response = new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
                response.Restaurantes = null;
                return response;
            }

        }


        public class ConsultaResponse
        {
            public List<Restaurante> Restaurantes { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public ConsultaResponse(List<Restaurante> restaurantes)
            {
                Restaurantes = restaurantes;
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
