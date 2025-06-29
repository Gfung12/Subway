using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichPavo : SandwichBase
    {
        public SandwichPavo(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich de Pavo (${Precio:0.00})";

        public override double Precio => Tamaño == "15" ? 12.00 : 18.00;
    }
}
