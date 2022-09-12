using Client.ViewModels;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Infrastructure.Commands
{
    public class UpdateCommand : AsyncCommand
    {
        private MainWindowViewModel _main;
        private ApiHandler _handler;

        public UpdateCommand(MainWindowViewModel main)
        {
            _main = main;
            _handler = new ApiHandler(_main.ApiUrl);
        }

        protected async override Task ExecuteCommandAsync(object parameter)
        {
            AreaInfo model = parameter as AreaInfo;
            if (model == null)
                return;

            var request = new UpdateAreaRequest();
            request.AreaId = model.AreaId;
            request.AreaTitle = model.AreasTitle;

            string jsonContent = JsonConvert.SerializeObject(request);

            var resp = await _handler.ExecuteRequestAsync<BaseResponse>("area", "patch", jsonContent);
            if (resp.OperationSuccess)
            {
                MessageBox.Show("Item updated successful", "Info", MessageBoxButton.OK);
            }
        }
    }
}
