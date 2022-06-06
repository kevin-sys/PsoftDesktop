using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Factura
    {

        public Factura(int codigoFactura, string fecha,string nombre, string Direccion, string tipopa, double valorTotalFactura)
        {
            idfactura = codigoFactura;
            Fecha = fecha;
            tipoPago = tipopa;
            ValorTotalFactura = valorTotalFactura;
            nombreCliente = nombre;
            direccion = Direccion;
        }
        
        public Factura()
        {
            DetalledeFacturas = new List<DetalledeFactura>();
        }

        
        public Cliente Cliente { get; set; }
        public string nombreCliente { get; set; }
        public string direccion { get; set; }
        public int idfactura { get; set; }
        public string tipoPago { get; set; }
        public string Fecha { get; set; }
        public int Cantidad { get; set; }
        public double ValorTotalFactura { get; set; }
        public double ValorTotalUtilidad { get; set; }

        public IList<DetalledeFactura> DetalledeFacturas { get; set; }
        public string Tipo { get; set; }
        public Persona Persona { get; set; }


       public void AgregarDetalle(Producto producto, int cantidad)
        {
            DetalledeFactura detalledeFactura = new DetalledeFactura(producto);
            detalledeFactura.Factura = this;
            detalledeFactura.CodigoVenta = idfactura;
            detalledeFactura.Cantidad = cantidad;
            detalledeFactura.PrecioProducto = producto.valorVenta;
            DetalledeFacturas.Add(detalledeFactura);


           
        }

        public void AgregarCliente(Cliente cliente) {

            Cliente = cliente;
        }
        
       
        public void CalcularTotalFactura()
        {
            ValorTotalFactura = DetalledeFacturas.Sum(d => d.PrecioProducto);
        }

        public void CalcularTotalUtilidad() {
            ValorTotalUtilidad = DetalledeFacturas.Sum(d => d.Producto.utilidad);
        
        }

        public void CalcularCantidad() {
            
            Cantidad = DetalledeFacturas.Count;
        
        }

        public override string ToString()
        {
            return $"{idfactura};{Fecha};{tipoPago};{ValorTotalFactura};{nombreCliente};{direccion};{ValorTotalUtilidad}";
        }



    }
}
