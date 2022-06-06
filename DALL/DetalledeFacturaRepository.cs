using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DALL
{
    public class DetalledeFacturaRepository
    {

        string ruta = "DetalleFactura.txt";

        public void Guardar(List <DetalledeFactura> detalledeFacturas)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            foreach (var detalle in detalledeFacturas) {
                escritor.WriteLine(detalle.ToString());
            }
            escritor.Close();
            file.Close();
        }


        public List<DetalledeFactura> Consultar()
        {
            List<DetalledeFactura> detalledeFactura = new List<DetalledeFactura>();
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(file);
            string linea = "";
            while ((linea = lector.ReadLine()) != null)
            {
                DetalledeFactura detalledeFacturas = MapearDetalledeFactura(linea);
                detalledeFactura.Add(detalledeFacturas);
            }
            lector.Close();
            file.Close();
            return detalledeFactura;
        }

       

        private static DetalledeFactura MapearDetalledeFactura(string linea)
        {
            string[] datosDetalledeFactura = linea.Split(';');
            DetalledeFactura detalledeFactura = new DetalledeFactura();
            detalledeFactura.CodigoVenta = int.Parse(datosDetalledeFactura[1]);
            detalledeFactura.Cantidad =int.Parse (datosDetalledeFactura[2]);
            detalledeFactura.descripcionProducto = datosDetalledeFactura[3];
            detalledeFactura.PrecioProducto = double.Parse(datosDetalledeFactura[4]);
            
            return detalledeFactura;
        }

       

    }
}
