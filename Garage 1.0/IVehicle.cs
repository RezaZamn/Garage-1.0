using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage_1._0
{
    internal interface IVehicle
    {
        string RegisterNumber { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
    }
}
