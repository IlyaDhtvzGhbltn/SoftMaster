using BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.RequestAndResponse.Area
{
    public class AreasListRequest
    {
        public DateTime Date { get; set; }
        public CargoType Type { get; set; }
    }
}
