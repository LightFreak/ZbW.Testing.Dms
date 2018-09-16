using System.IO;
using System.Windows;
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

        private const string _destination = @"D:\Dms\";

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private List<string> _typItems;

        private DateTime _valutaDatum;

        private MetadataItem _metadata; 

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

        public DateTime ValutaDatum
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
                _metadata = new MetadataItem(_benutzer,_bezeichnung,_erfassungsdatum,_filePath,_destination,_isRemoveFileEnabled,_selectedTypItem,
                                                _stichwoerter,_valutaDatum);
                if (IsRemoveFileEnabled == true)
                {
                    file.MoveFile(_metadata);
                }
                else
                {
                    file.CopyFile(_metadata);
                }
                _navigateBack();
            }
            else
            {
                MessageBox.Show("Es wurden nicht Alle Pflichtfelder angegeben!");
            }
            // TODO: Add your Code here
            /*var tmp = _filePath.LastIndexOf("\");

            if (_isRemoveFileEnabled = true)
            {
                File.Move(_filePath, _destination);
            }
            else
            {
                File.Copy(_filePath, _destination);
            }
            */
            /* file.copy oder file.move() an ein bestimmtes Ort (Hardcodiert) an Hand Bool _isRemoveFileEnabled
             - guid generieren für ein neues File filename service für generieren
             - Bei generierung neuer Filename angeben.

             - vorgehen anhand der AC's der Aufgaben beschreibung...
             */
            //_filePath.saveFileDialog.ShowDialog(); 
            
        }
    }
}