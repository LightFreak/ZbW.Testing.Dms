using System.IO;
using System.Windows;
using System.Windows.Media.TextFormatting;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Win32;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Repositories;

    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;

        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;
        
        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime? _valutaDatum;

        private MetadataItem _metadata;

        private string _extension;

        private string _filename;

        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;
            
            

            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }

        public string Stichwoerter
        {
            get
            {
                return _stichwoerter;
            }

            set
            {
                SetProperty(ref _stichwoerter, value);
            }
        }

        public string Bezeichnung
        {
            get
            {
                return _bezeichnung;
            }

            set
            {
                SetProperty(ref _bezeichnung, value);
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

        public DateTime Erfassungsdatum
        {
            get
            {
                return _erfassungsdatum;
            }

            set
            {
                SetProperty(ref _erfassungsdatum, value);
            }
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public DelegateCommand CmdDurchsuchen { get; }

        public DelegateCommand CmdSpeichern { get; }

        public DateTime? ValutaDatum
        {
            get
            {
                return _valutaDatum;
            }

            set
            {
                SetProperty(ref _valutaDatum, value);
            }
        }

        public bool IsRemoveFileEnabled
        {
            get
            {
                return _isRemoveFileEnabled;
            }

            set
            {
                SetProperty(ref _isRemoveFileEnabled, value);
            }
        }

        public string Extension
        {
            get
            {
                return _extension;
            }

            set
            {
                SetProperty(ref _extension, value);
            }
        }

        public string Filename
        {
            get
            {
                return _filename;
            }

            set
            {
                SetProperty(ref _filename, value);
            }
        }




        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();

            if (result.GetValueOrDefault())
            {
                _filePath = openFileDialog.FileName;
            }
        }

        private void OnCmdSpeichern()
        {
            FileOp file = new FileOp();
            if (Bezeichnung != null && ValutaDatum != null && TypItems != null)
            {
                _filename = file.GetFilename(_filePath);
                _extension = file.GetExtension(_filePath);
               
                file.CopyFile(createMetadataItem(), IsRemoveFileEnabled);
               
                _navigateBack();
            }
            else
            {
                MessageBox.Show("Es wurden nicht Alle Pflichtfelder angegeben!");
            }
            
        }

        private MetadataItem createMetadataItem()
        {
            MetadataItem meta = new MetadataItem();
            meta.Benutzer = _benutzer;
            meta.Bezeichnung = _bezeichnung;
            meta.Erfassungsdatum = _erfassungsdatum;
            meta.Extension = _extension;
            meta.Filename = _filename;
            meta.OriginalPath = _filePath;
            meta.SelectedTypItem = _selectedTypItem;
            meta.ValutaDatum = _valutaDatum;
            var temp = _valutaDatum.GetValueOrDefault();
            meta.ValutaYear =  temp.Year.ToString();
            return meta;

        }
    }
}