using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace DALL
{
    public class RestauranteRepository
    {
        string ruta = "Restaurante.txt";

        public void Guardar(Restaurante restaurante)
        {
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine(restaurante.Adicionar());
            escritor.Flush();
            escritor.Close();
            file.Close();
        }


        public List<Restaurante> Consultar()
        {
            List<Restaurante> restaurante = new List<Restaurante>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                Restaurante restaurantes = MapearRestaurante(linea);
                restaurante.Add(restaurantes);
            }
            lector.Close();
            file.Close();
            return restaurante;
        }

        private static Restaurante MapearRestaurante(string linea)
        {
            string[] datosRestaurante = linea.Split(';');
            Restaurante restaurante = new Restaurante();
            restaurante.nit = int.Parse(datosRestaurante[0]);
            restaurante.nombre = datosRestaurante[1];
            restaurante.ubicacion = datosRestaurante[2];
            return restaurante;
        }

        //Eliminar Restaurante
        public void Eliminar(int Id)
        {
            List<Restaurante> restaurantes = new List<Restaurante>();
            restaurantes.Clear();
            restaurantes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in restaurantes)
            {
                if (item.nit != Id)
                {
                    Guardar(item);
                }
            }
        }

        //Modificar Restaurante

        public void Modificar(int Id, string nombrenuevo, string ubicacion)
        {
            List<Restaurante> restaurantes = new List<Restaurante>();
            restaurantes.Clear();
            restaurantes = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in restaurantes)
            {
                if (item.nit == Id)
                {
                    item.nombre = nombrenuevo;
                    item.ubicacion = ubicacion;
                    Guardar(item);
                }
                else
                {
                    Guardar(item);
                }
            }
        }

        //Buscar Restaurante
        public Restaurante Buscar(int Id)
        {
            List<Restaurante> restaurantes = new List<Restaurante>();
            restaurantes.Clear();
            restaurantes = Consultar();

            foreach (var item in restaurantes)
            {
                if (item.nit==Id)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
