using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Producto
    {

       
        public string nombre { get; set; }
        public double valorCosto { get; set; }
        public double valorVenta { get; set; }

        public double utilidad { get; set; }

        public double calcularUtilidad() {

            utilidad = valorVenta - valorCosto;

            return utilidad;
        
        }

      

        public override string ToString()
        {
            return $"{nombre},{valorCosto},{valorVenta},{utilidad}";
        }


    }
}
