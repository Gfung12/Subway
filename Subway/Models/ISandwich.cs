using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Models
{
    public interface ISandwich
    {
        string? Descripcion { get; }
        double Precio { get; }
        string? Tamaño { get; }
    }
}
