using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DALL
{
    public class ClienteRepository
    {

        string ruta = "Cliente.txt";

        public void Guardar(Cliente cliente)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine(cliente.ToString());
            escritor.Flush();
            escritor.Close();
            file.Close();
        }


        public List<Cliente> Consultar()
        {
            List<Cliente> cliente = new List<Cliente>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                Cliente clientes = MapearCliente(linea);
                cliente.Add(clientes);
            }
            lector.Close();
            file.Close();
            return cliente;
        }

        private static Cliente MapearCliente(string linea)
        {
            string[] datosCliente= linea.Split(';');
            Cliente cliente = new Cliente();
            cliente.identificacion = datosCliente[0];
            cliente.nombre = datosCliente[1];
            cliente.telefono = datosCliente[2];
            cliente.direccion = datosCliente[3];
            cliente.email = datosCliente[4];
            return cliente;
        }

        //Eliminar Restaurante
        public void Eliminar(string Id)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Clear();
            clientes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in clientes)
            {
                if (item.identificacion != Id)
                {
                    Guardar(item);
                }
            }
        }

        //Modificar Cliente

        public void Modificar(string Id, string nombrenuevo, string apellidonuevo, string telefononuevo, string emailnuevo)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Clear();
            clientes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in clientes)
            {
                if (item.identificacion == Id)
                {
                    item.nombre = nombrenuevo;
                    item.telefono = telefononuevo;
                    item.email = emailnuevo;
                    Guardar(item);
                }
                else
                {
                    Guardar(item);
                }
            }
        }

        //Buscar Cliente
        public Cliente Buscar(string Id)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Clear();
            clientes = Consultar();

            foreach (var item in clientes)
            {
                if (item.identificacion == Id)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
