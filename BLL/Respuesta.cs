using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
namespace BLL
{
    public class Respuesta
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
    }
    public class RespuestaConsulta : Respuesta
    {
        public List<Factura> Facturas { get; set; }
    }
    public class RespuestaBusqueda : Respuesta
    {
        public Factura factura { get; set; }
    }
}
