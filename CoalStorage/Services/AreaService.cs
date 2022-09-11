using BaseTypes;
using Contracts.v1.Infrastructure;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.v1.Services
{
    public class AreaService : IAreaService
    {
        private readonly IFactory<StorageDbContext> _dbFactory;

        public AreaService(IFactory<StorageDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }


        public async Task<CreateAreaResponse> CreateArea(string title, Guid storageId)
        {
            var resp = new CreateAreaResponse();
            using (var context = _dbFactory.Create())
            {
                var storage = await context.Storages
                    .Include(x=>x.Areas)
                    .FirstOrDefaultAsync(x => x.StorageId == storageId);
                if (storage != null)
                {
                    Guid areaId = Guid.NewGuid();
                    context.Areas.Add(
                        new Area 
                        {
                            StorageId = storageId,
                            Storage = storage,
                            Title = title,
                            AreaFormationDate = DateTime.Now, 
                            AreaId = areaId
                        });

                    await context.SaveChangesAsync();
                    resp.OperationSuccess = true;
                    resp.AreaId = areaId;
                }
                else 
                {
                    resp.Message = "Invalid storageId";
                }
                return resp;
            }
        }

        public async Task<BaseResponse> DeleteArea(Guid areaId)
        {
            BaseResponse resp = new BaseResponse();
            using (var context = _dbFactory.Create())
            {
                var area = await context.Areas.FirstOrDefaultAsync(x => x.AreaId == areaId);
                if (area != null)
                {
                    context.Areas.Remove(area);
                    await context.SaveChangesAsync();
                    resp.OperationSuccess = true;
                }
                else 
                {
                    resp.Message = "Invalid areaId";
                }
            }
            return resp;
        }

        public async Task<AreasListResponse> GetAreasByDateAndType(CargoType type, DateTime date)
        {
            var resp = new AreasListResponse
            {
                AreasInfos = new List<AreaInfo>(),
                OperationSuccess = true
            };

            using (var context = _dbFactory.Create()) 
            {
                var areas = await context.Areas
                    .Where(x => x.AreaFormationDate >= date)
                    .Include(x => x.Pickets)
                    .ThenInclude(x => x.Cargos)
                    .ToListAsync();
                if (type == CargoType.NotDetermined)
                {
                    areas.ForEach(x => resp.AreasInfos
                        .Add(new AreaInfo
                        {
                            AreasTitle = x.Title,
                            AreaFormationDate = x.AreaFormationDate,
                            AreaId = x.AreaId,
                            StorageId = x.StorageId
                        }));
                }
                else
                {
                    foreach (var area in areas)
                    {
                        foreach (var pic in area.Pickets)
                        {
                            var cargo = pic.Cargos.FirstOrDefault(x => x.Type == type);
                            if (cargo != null)
                            {
                                resp.AreasInfos.Add(new AreaInfo
                                {
                                    AreasTitle = area.Title,
                                    AreaFormationDate = area.AreaFormationDate,
                                    AreaId = area.AreaId,
                                    StorageId = area.StorageId
                                });
                                break;
                            }
                        }
                    }
                }
            }
                return resp;
        }

        public async Task<BaseResponse> UpdateArea(string title, Guid areaId)
        {
            BaseResponse resp = new BaseResponse();

            using (var context = _dbFactory.Create())
            {
               var area = await context.Areas.FirstOrDefaultAsync(x=>x.AreaId == areaId);
                if (area != null)
                {
                    area.Title = title;
                    resp.OperationSuccess = true;
                    await context.SaveChangesAsync();
                }
                else 
                {
                    resp.Message = "Invalid areaId";
                }
            }
            return resp;
        }
    }
}
