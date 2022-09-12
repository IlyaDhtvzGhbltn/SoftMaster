using Client.ViewModels;
using Contracts.v1.RequestAndResponse.Area;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Infrastructure.Commands
{
    public class GetAreasCommand : AsyncCommand
    {
        private MainWindowViewModel _main;
        private ApiHandler _handler;

        public GetAreasCommand(MainWindowViewModel main)
        {
            _main = main;
            _handler = new ApiHandler(_main.ApiUrl);
        }

        protected override async Task ExecuteCommandAsync(object parameter)
        {
            _main.SpeenRotate = true;
            string url = $"area?Type={_main.SelectedType}&Date={_main.DateFilter}";
            var resp = await _handler.ExecuteRequestAsync<AreasListResponse>(url, "get", null);
            if (resp != null && resp.AreasInfos.Count > 0)
            {
                _main.AreasCollection = new System.Collections.ObjectModel.ObservableCollection<AreaInfo>();
                _main.StorageGuids = new System.Collections.ObjectModel.ObservableCollection<Guid>();
                resp.AreasInfos.ForEach(x => _main.AreasCollection.Add(x));
                resp.AreasInfos.ForEach(x => _main.StorageGuids.Add(x.StorageId));
                if (resp.AreasInfos.Count > 0)
                {
                    _main.SelectedStorageGuid = _main.StorageGuids[0];
                    _main.AddAreaBtnEnabled = true;
                }
                else 
                {
                    _main.AddAreaBtnEnabled = false;
                }
            }
            _main.SpeenRotate = false;
        }
    }
}
