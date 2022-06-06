using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class DetalledeFactura
    {
        public DetalledeFactura(Producto producto)
        {
            Producto = producto;
            PrecioProducto = producto.valorVenta;

        }

        public DetalledeFactura()
        {

        }

        public int CodigoVenta { get; set; }

        public string descripcionProducto { get; set; }
        
        public double PrecioProducto { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }

        public Cliente Cliente { get; set; }

        public int Cantidad { get; set; }

        public double ValorTotal { get { return PrecioProducto * Cantidad; } set { } }


        public override string ToString()
        {
            return $"{CodigoVenta};{Cantidad};{descripcionProducto};{PrecioProducto}";
        }


    }
}
