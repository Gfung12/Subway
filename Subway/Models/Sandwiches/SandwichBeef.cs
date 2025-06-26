using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichBeef : SandwichBase
    {
        public SandwichBeef(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich de Carne de Res ({Tamaño} cm)";
        public override double Precio => Tamaño == "15" ? 10.00 : 16.00;
    }
}
