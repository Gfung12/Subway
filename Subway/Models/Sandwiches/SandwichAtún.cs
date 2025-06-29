using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichAtún : SandwichBase
    {
        public SandwichAtún(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich de Atún (${Precio:0.00})";
        public override double Precio => Tamaño == "15" ? 11.00 : 17.00;
    }
}
