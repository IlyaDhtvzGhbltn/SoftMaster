using Client.Infrastructure;
using Client.Infrastructure.Commands;
using Contracts.v1.RequestAndResponse.Area;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Text;
using System.Windows.Input;

namespace Client.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public readonly Uri ApiUrl;

        private bool _speenRotate = false;
        private bool _addAreaBtnEnabled = false;
        private string _selectedType = "NotDetermined";
        private string _newAreaTitle;
        private DateTime _dateFilter = DateTime.Now;
        public DateTime DateFilter 
        {
            get { return _dateFilter; }
            set { SetProperty(ref _dateFilter, value); }
        }
        private ObservableCollection<AreaInfo> _areasCollection;
        public ObservableCollection<AreaInfo> AreasCollection 
        {
            get { return _areasCollection; }
            set 
            { 
                SetProperty(ref _areasCollection, value);
            }
        }

        private ObservableCollection<Guid> _storageGuids;
        private Guid _selectedStorageGuid;

        public ObservableCollection<Guid> StorageGuids 
        {
            get { return _storageGuids; }
            set { SetProperty(ref _storageGuids, value); }
        }
        public Guid SelectedStorageGuid
        {
            get
            {
                return _selectedStorageGuid; 
            }
            set
            {
                SetProperty(ref _selectedStorageGuid, value);
            }
        }

        public List<string> CargoTypes
        {
            get {
                return new List<string>()
                {
                "NotDetermined",
                "Bulk",
                "Powdered",
                "Liquid",
                "Gaz",
                "General",
                "Oversized",
                "Perishable",
                "Dangerous"
                };
            } 
        }
        public bool SpeenRotate 
        {
            get { return _speenRotate; }
            set { SetProperty(ref _speenRotate, value); }
        }

        public string SelectedType 
        {
            get { return _selectedType; }
            set { SetProperty(ref _selectedType, value); }
        }
        
        public string NewAreaTitle
        {
            get { return _newAreaTitle; }
            set { SetProperty(ref _newAreaTitle, value); }
        }
        
        public bool AddAreaBtnEnabled
        {
            get { return _addAreaBtnEnabled; }
            set { SetProperty(ref _addAreaBtnEnabled, value); }
        }


        public ICommand GetAreas 
        {
            get 
            {
                return new GetAreasCommand(this);
            }
        }

        public ICommand AddArea
        {
            get 
            {
                return new CreateAreaCommand(this);
            }
        }

        public ICommand DeleteArea 
        {
            get 
            {
                return new DeleteAreaCommand(this);
            }
        }        
        
        public ICommand UpdateArea
        {
            get 
            {
                return new UpdateCommand(this);
            }
        }

        public MainWindowViewModel()
        {
            string url = ConfigurationManager.AppSettings.Get("ApiUrl");
            ApiUrl = new Uri(url);
        }
    }
}
