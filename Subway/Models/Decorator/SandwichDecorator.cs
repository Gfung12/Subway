using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models.Decorator
{
    public abstract class SandwichDecorator : ISandwich
    {
        public readonly ISandwich _sandwich;

        protected SandwichDecorator(ISandwich sandwich)
        {
            _sandwich = sandwich;
        }

        public virtual string Descripcion => _sandwich.Descripcion;
        public virtual double Precio => _sandwich.Precio;
        public virtual string Tamaño => _sandwich.Tamaño;
    }
}
