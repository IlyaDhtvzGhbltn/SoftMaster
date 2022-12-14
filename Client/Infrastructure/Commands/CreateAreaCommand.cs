using Client.ViewModels;
using Contracts.v1.RequestAndResponse;
using Contracts.v1.RequestAndResponse.Area;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.Infrastructure.Commands
{
    public class CreateAreaCommand : AsyncCommand
    {
        private MainWindowViewModel _main;
        private ApiHandler _handler;

        public CreateAreaCommand(MainWindowViewModel main)
        {
            _main = main;
            _handler = new ApiHandler(_main.ApiUrl);
        }

        protected async override Task ExecuteCommandAsync(object parameter)
        {
            string url = $"area";
            CreateAreaRequest request = new CreateAreaRequest();
            request.AreaTitle = _main.NewAreaTitle;
            request.StorageId = _main.SelectedStorageGuid;

            string jsonContent = JsonConvert.SerializeObject(request);

            var resp = await _handler.ExecuteRequestAsync<BaseResponse>(url, "post", jsonContent);
            if (resp.OperationSuccess) 
            {
                _main.GetAreas.Execute(null);
                MessageBox.Show("Item was added successful", "Info", MessageBoxButton.OK);
            }
        }
    }
}
