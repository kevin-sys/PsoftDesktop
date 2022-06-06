using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace DALL
{
    public class FacturaRepository
    {
        private List<Factura> facturas = new List<Factura>();
        string ruta = @"Factura.txt";
        private FileStream flujoDelFichero;

        public void Guardar(Factura factura)
        {
            flujoDelFichero= new FileStream(ruta, FileMode.OpenOrCreate);
            StreamWriter escritor = new StreamWriter(flujoDelFichero);
            escritor.WriteLine(factura.ToString());
            escritor.Close();
            flujoDelFichero.Close();
        }

        public List<Factura> Consultar()
        {
            facturas.Clear();
            flujoDelFichero = new FileStream(ruta, FileMode.Append);
            StreamReader lector = new StreamReader(flujoDelFichero);
            string linea = string.Empty;
            while ((linea = lector.ReadLine()) != null)
            {
                Factura factura = MapearFactura(linea);
                facturas.Add(factura);
            }
            lector.Close();
            flujoDelFichero.Close();
            return facturas;
        }

        private Factura MapearFactura(string linea)
        {
            Factura factura;
            string[] datosFactura = linea.Split(';');
            int idfactura = int.Parse(datosFactura[0]);
            string Fecha = datosFactura[1];
            string tipoPago = datosFactura[2];
            double ValorTotalFactura =double.Parse(datosFactura[3]);
            string nombreCliente = datosFactura[4];
            string direccion = datosFactura[5];
            double ValorTotalUtilidad = double.Parse(datosFactura[6]);
            factura = new Factura(idfactura,Fecha,nombreCliente,direccion,tipoPago,ValorTotalFactura);
            return factura;
        }

        //Eliminar Producto
        public void Eliminar(int Id)
        {
            List<Factura> facturas = new List<Factura>();
            facturas.Clear();
            facturas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in facturas)
            {
                if (item.idfactura != Id)
                {
                    Guardar(item);
                }
            }
        }

        //Modificar Producto

        public void Modificar(int Id, string nombrenuevo, string vCosto, double vVenta)
        {
            List<Factura> facturas = new List<Factura>();
            facturas.Clear();
            facturas = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in facturas)
            {
                if (item.idfactura == Id)
                {
                    item.nombreCliente = nombrenuevo;
                    item.tipoPago = vCosto;
                    
                    Guardar(item);
                }
                else
                {
                    Guardar(item);
                }
            }
        }

        //Buscar Producto
       
         public Factura Buscar(int id)
        {
            facturas = Consultar();
            foreach (Factura item in facturas)
            {
                if (item.idfactura.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }



    }
}
