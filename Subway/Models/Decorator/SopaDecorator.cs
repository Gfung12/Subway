using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Decorator
{
    public class SopaDecorator : SandwichDecorator
    {
        public SopaDecorator(ISandwich sandwich) : base(sandwich) { }
        public override string Descripcion
        {
            get
            {
                double precioAdicional = Tamaño == "15" ? 4.20 : 4.20;
                return $"{_sandwich.Descripcion} + Sopa (${precioAdicional:0.00})";
            }
        }
        public override double Precio => _sandwich.Precio + (Tamaño == "15" ? 4.20 : 4.20);
    }
}
