using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.RequestAndResponse
{
    public class BaseResponse
    {
        public bool OperationSuccess{ get; set; }
        public string Message { get; set; }
    }
}
