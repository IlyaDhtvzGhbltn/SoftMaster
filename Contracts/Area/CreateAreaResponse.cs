
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.RequestAndResponse.Area
{
    public class CreateAreaResponse : BaseResponse
    {
        public Guid AreaId { get; set; }
    }
}
