using Client.ViewModels;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Commands
{
    class DeleteAreaCommand : AsyncCommand
    {

        private MainWindowViewModel _main;
        private ApiHandler _handler;

        public DeleteAreaCommand(MainWindowViewModel main)
        {
            _main = main;
            _handler = new ApiHandler(_main.ApiUrl);
        }


        protected async override Task ExecuteCommandAsync(object parameter)
        {
            AreaInfo model = parameter as AreaInfo;
            var request = new DeleteAreaRequest();
            request.AreaId = model.AreaId;

            string jsonContent = JsonConvert.SerializeObject(request);

            var resp = await _handler.ExecuteRequestAsync<BaseResponse>("area", "delete", jsonContent);
            if (resp.OperationSuccess) 
            {
                var area = _main.AreasCollection.First(x=>x.AreaId == request.AreaId);
                _main.AreasCollection.Remove(area);
            }

        }
    }
}
