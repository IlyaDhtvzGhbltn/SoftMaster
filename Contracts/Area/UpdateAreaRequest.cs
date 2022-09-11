using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.RequestAndResponse.Area
{
    public class UpdateAreaRequest
    {
        public Guid AreaId { get; set; }
        public string AreaTitle { get; set; }
    }
}
