using Contracts.v1.Infrastructure;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.Controllers
{
    [Route("api/v1/area")]
    public class AreasController : ControllerBase
    {
        IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        [HttpGet]
        public async Task<JsonResult> GetAreas([FromQuery] AreasListRequest request)
        {
            var resp = await _areaService.GetAreasByDateAndType(request.Type, request.Date);
            return new JsonResult(resp);
        }

        [HttpPatch]
        public async Task<BaseResponse> UpdateArea([FromBody] UpdateAreaRequest request) 
        {
            return await _areaService.UpdateArea(request.AreaTitle, request.AreaId);
        }

        [HttpPost]
        public async Task<BaseResponse> CreateArea([FromBody] CreateAreaRequest request) 
        {
            return await _areaService.CreateArea(request.AreaTitle, request.StorageId);
        }

        [HttpDelete]
        public async Task<BaseResponse> DeleteArea([FromBody] DeleteAreaRequest request) 
        {
            return await _areaService.DeleteArea(request.AreaId);
        }

    }
}
