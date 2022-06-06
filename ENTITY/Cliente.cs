using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cliente : Persona
    {


        public override string ToString()
        {
            return $"{identificacion};{nombre};{telefono};{direccion};{email}";
        }
    }
}
