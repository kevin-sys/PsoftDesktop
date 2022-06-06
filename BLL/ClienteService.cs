using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;
using ENTITY;

namespace BLL
{
    public class ClienteService
    {

        ClienteRepository clienteRepository;

        public ClienteService() {

            clienteRepository = new ClienteRepository();
        
        
        }


        public string Guardar(Cliente cliente) {

            try
            {
                if (cliente ==null) {

                    return "No se guardo nada cole";
                } 
                else {


                    clienteRepository.Guardar(cliente);
                    return "Datos Guardados Satisfactoriamente";
                    
                }
                   

            }
            catch (Exception exception)
            {

                return "Se presentó el siguiente error:" + exception.Message;
            }


        }


        public Cliente BuscarPorIdentificacion(string Id)
        {

            foreach (var item in Consultar().Clientes)
            {
                if (item.identificacion.Equals(Id))
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
                response = new ConsultaResponse(clienteRepository.Consultar());
                return response;
            }
            catch (Exception exception)
            {
                response = new ConsultaResponse("Se presentó el siguiente error:" + exception.Message);
                response.Clientes = null;
                return response;
            }

        }


        public class ConsultaResponse
        {
            public List<Cliente> Clientes { get; set; }
            public string Mensaje { get; set; }
            public bool Error { get; set; }

            public ConsultaResponse(List<Cliente> clientes)
            {
                Clientes = clientes;
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
