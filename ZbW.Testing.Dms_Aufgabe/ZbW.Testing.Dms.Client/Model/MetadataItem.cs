using System;
using System.Collections.Generic;
using Prism.Mvvm;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem : BindableBase
    {
        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _orignalPath;

        private string _filename;

        private string _extension;

        private string _metaDataFileName;

        private static string _destination;

        private string _selectedTypItem;

        private string _stichwoerter;

        private DateTime? _valutaDatum;

        private string _valutaYear;

        private string _contentFilePath;

        public MetadataItem( )
        {
           
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

        public string OriginalPath
        {
            get
            {
                return _orignalPath;
            }
            set
            {
                SetProperty(ref _orignalPath, value);
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

        public string MetaDataFileName
        {
            get
            {
                return _metaDataFileName;
            }
            set
            {
                SetProperty(ref _metaDataFileName, value);
            }
        }

        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                SetProperty(ref _destination, value);
            }
        }

        public string SelectedTypItem
        {
            get { return _selectedTypItem; }
            set { SetProperty(ref _selectedTypItem, value); }
        }

        public string Stichwoerter
        {
            get { return _stichwoerter; }
            set { SetProperty(ref _stichwoerter, value); }
        }

        public DateTime? ValutaDatum
        {
            get { return _valutaDatum; }
            set { SetProperty(ref _valutaDatum, value); }
        }

        public string ValutaYear
        {
            get { return _valutaYear; }
            set { SetProperty(ref _valutaYear, value); }
        }

        public string ContentFilePath
        {
            get { return _contentFilePath; }
            set { SetProperty(ref _contentFilePath, value); }
        }

       

    }
}