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
        public override string Descipcion => $"Sandwich de Carne de Res (${Precio:0.00})";
        public override double Precio => Tamaño == "15" ? 10.00 : 16.00;
    }
}
