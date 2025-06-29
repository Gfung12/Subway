using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Sandwiches
{
    public class SandwichVeggie : SandwichBase
    {
        public SandwichVeggie(string tamaño) : base(tamaño) { }
        public override string Descipcion => $"Sandwich Vegetariano (${Precio:0.00})";
        public override double Precio => Tamaño == "15" ? 8.00 : 14.00;
    }
}
