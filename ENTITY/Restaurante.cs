using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Restaurante
    {
        public int nit { get; set; }

        public string nombre { get; set; }
        public string ubicacion {get; set;}


        public string Adicionar() {

            return $"{nit},{nombre},{ubicacion}";
        }

       


    }
}
