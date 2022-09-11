using BaseTypes;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.Infrastructure
{
    public interface IAreaService
    {
        Task<AreasListResponse> GetAreasByDateAndType(CargoType type, DateTime date);
        Task<CreateAreaResponse> CreateArea(string title, Guid storageId);
        Task<BaseResponse> UpdateArea(string title, Guid areaId);
        Task<BaseResponse> DeleteArea(Guid areaId);
    }
}
