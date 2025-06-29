using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Decorator
{
    public class PostreDecorator : SandwichDecorator
    {
        public PostreDecorator(ISandwich sandwich) : base(sandwich) { }
        public override string Descripcion
        {
            get
            {
                double precioAdicional = Tamaño == "15" ? 3.50 : 3.50;
                return $"{_sandwich.Descripcion} + Postre (${precioAdicional:0.00})";
            }
        }
        public override double Precio => _sandwich.Precio + (Tamaño == "15" ? 3.50 : 3.50);
    }
}
