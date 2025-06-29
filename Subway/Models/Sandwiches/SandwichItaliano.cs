using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichItaliano : SandwichBase
    {
        public SandwichItaliano(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich Italiano (${Precio:0.00})";
        public override double Precio => Tamaño == "15" ? 9.00 : 16.00;
    }
}
