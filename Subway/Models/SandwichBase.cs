using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models
{
    public abstract class SandwichBase : ISandwich
    {
        public abstract string Descipcion { get; }
        public abstract double Precio { get; }
        public string Tamaño { get; protected set; }

        protected SandwichBase (string tamaño)
        {
            Tamaño = tamaño;
        }
    }
}
