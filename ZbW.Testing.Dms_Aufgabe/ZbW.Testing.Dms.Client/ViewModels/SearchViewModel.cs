using System.Collections.ObjectModel;
using System.IO;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Collections.Generic;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Model;
    using ZbW.Testing.Dms.Client.Repositories;
    using ZbW.Testing.Dms.Client.Interfaces;

    internal class SearchViewModel : BindableBase
    {
        //private List<MetadataItem> _filteredMetadataItems;
        private ObservableCollection<MetadataItem> _filteredMetadataItems;
        private MetadataItem _selectedMetadataItem;
        private FileOp _fileSystemService;

        private string _selectedTypItem;

        private string _suchbegriff;

        private List<string> _typItems;

        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;

            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            _fileSystemService = new FileOp();
            _filteredMetadataItems = new ObservableCollection<MetadataItem>();
            ShowData();
        }

        public DelegateCommand CmdOeffnen { get; }

        public DelegateCommand CmdSuchen { get; }

        public DelegateCommand CmdReset { get; }

        public string Suchbegriff
        {
            get
            {
                return _suchbegriff;
            }

            set
            {
                SetProperty(ref _suchbegriff, value);
            }
        }

        public List<string> TypItems
        {
            get
            {
                return _typItems;
            }

            set
            {
                SetProperty(ref _typItems, value);
            }
        }

        public string SelectedTypItem
        {
            get
            {
                return _selectedTypItem;
            }

            set
            {
                SetProperty(ref _selectedTypItem, value);
            }
        }

        public ObservableCollection<MetadataItem> FilteredMetadataItems
        {
            get
            {
                return _filteredMetadataItems;
            }

            set
            {
                SetProperty(ref _filteredMetadataItems, value);
                RaisePropertyChanged("FilteredMetadataItems");
            }
        }

        public MetadataItem SelectedMetadataItem
        {
            get
            {
                return _selectedMetadataItem;
            }

            set
            {
                if (SetProperty(ref _selectedMetadataItem, value))
                {
                    CmdOeffnen.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanCmdOeffnen()
        {
            return SelectedMetadataItem != null;
        }

        private void OnCmdOeffnen()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = SelectedMetadataItem.ContentFilePath;
            process.Start();
            
        }

        private void OnCmdSuchen()
        {
            var tempList = new List<MetadataItem>();
            foreach (var m in FilteredMetadataItems)
            {
                if (m.Bezeichnung.ToLower().Equals(Suchbegriff.ToLower()) || m.Stichwoerter.ToLower().Equals(Suchbegriff.ToLower()) || m.SelectedTypItem.Equals(SelectedTypItem))
                {
                    tempList.Add(m);
                }
            }
            FilteredMetadataItems.Clear();
            FilteredMetadataItems.AddRange(tempList);
            
        }

        private void ShowData()
        {
            _fileSystemService = new FileOp();
            var metadataList = _fileSystemService.LoadMetadata();
            foreach (var m in metadataList)
            {
                FilteredMetadataItems.Add(m);
            }
        }

        private void OnCmdReset()
        {
            FilteredMetadataItems.Clear();
            Suchbegriff = null;
            SelectedTypItem = null;
            ShowData();
            
        }
    }
}