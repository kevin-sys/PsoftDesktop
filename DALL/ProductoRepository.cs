using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DALL
{
    public class ProductoRepository
    {

        private string ruta = "Producto.txt";
        private IList<Producto> productos;
        public ProductoRepository()
        {
            productos = new List<Producto>();

        }

        public void Guardar(Producto producto)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter writer = new StreamWriter(fileStream);
            writer.WriteLine(producto.ToString());
            writer.Close();
            fileStream.Close();
        }




        public IList<Producto> ConsultarKEVIN()
        {
            productos.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            string linea = string.Empty;
            Producto producto;
            while ((linea = streamReader.ReadLine()) != null)
            {

                producto = new Producto();
                string[] datos = linea.Split(',');
               
               
                producto.nombre = datos[0];
                producto.valorCosto = double.Parse(datos[1]);
                producto.valorVenta = double.Parse(datos[2]);
                producto.utilidad = double.Parse(datos[3]);

                productos.Add(producto);
            }
            fileStream.Close();
            streamReader.Close();
            return productos;
        }


  


    }
}
