using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.RequestAndResponse.Area
{
    public class AreasListResponse : BaseResponse
    {
        public List<AreaInfo> AreasInfos { get; set; }
    }

    public class AreaInfo
    {
        public string AreasTitle { get; set; }
        public DateTime AreaFormationDate { get; set; }
        public Guid AreaId { get; set; }
        public Guid StorageId { get; set; }
    }
}
