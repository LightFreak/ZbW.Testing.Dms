﻿using System;
using System.Collections.Generic;
using Prism.Mvvm;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItem : BindableBase
    {
        private string _benutzer;

        private string _bezeichnung;

        private DateTime _erfassungsdatum;

        private string _filePath;

        private static string _destination = @"D:\Dms\";

        private bool _isRemoveFileEnabled;

        private string _selectedTypItem;

        private string _stichwoerter;

        private DateTime _valutaDatum;

        public MetadataItem(string benutzer, string bezeichnung, DateTime erfassungsdatum, string sourcepath, string destinationPath,
                            bool isRemoveFileEnabled, string selectedTypItem, string stichwoerter, DateTime valutaDatum)
        {
            _benutzer = benutzer;
            _bezeichnung = bezeichnung;
            _erfassungsdatum = erfassungsdatum;
            _filePath = sourcepath;
            _destination = destinationPath;
            _isRemoveFileEnabled = isRemoveFileEnabled;
            _selectedTypItem = selectedTypItem;
            _stichwoerter = stichwoerter;
            _valutaDatum = valutaDatum;
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

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                SetProperty(ref _filePath, value);
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

        public bool IsRemoveFileEnable
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

        public DateTime ValutaDatum
        {
            get { return _valutaDatum; }
            set { SetProperty(ref _valutaDatum, value); }
        }
    }
}