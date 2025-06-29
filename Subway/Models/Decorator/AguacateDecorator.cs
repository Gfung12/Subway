using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Decorator
{
    public class AguacateDecorator : SandwichDecorator
    {
        public AguacateDecorator(ISandwich sandwich) : base(sandwich) { }
        public override string Descripcion
        {
            get
            {
                double precioAdicional = Tamaño == "15" ? 1.50 : 2.50;
                return $"{_sandwich.Descripcion} + Aguacate (${precioAdicional:0.00})";
            }
        }
        public override double Precio => _sandwich.Precio + (Tamaño == "15" ? 1.50 : 2.50);
    }
}
