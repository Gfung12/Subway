using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichPollo : SandwichBase
    {
        public SandwichPollo(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich de Pollo (${Precio:0.00})";
        public override double Precio => Tamaño == "15" ? 12.00 : 18.00;
    }
}
