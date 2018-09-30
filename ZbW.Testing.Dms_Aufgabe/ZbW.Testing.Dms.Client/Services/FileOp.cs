using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Properties;
using ZbW.Testing.Dms.Client.Provider;


namespace ZbW.Testing.Dms.Client.Services
{
    
    internal class FileOp 
    {
        private string _target;
        private IList<string> DirectoryFolder = new List<string>();

        //private FileNameGenerator _fng;
        
        private XmlService XmlService;

        public FileOp()
        {
            _target = Settings.Default.DefaultRepo;
            Destiny = new FileServices();
            XmlService = new XmlService();
            Guid = new FileNameGenerator();
            
        }

        internal FileServices Destiny { private get; set; }
        internal XmlService Xml { private get; set; }
        internal FileNameGenerator Guid {private get; set; }
        
        public void CopyFile(MetadataItem source, bool fileRemove)
        {
            source.Destination = _target;
            SetDestinationDir(source.ValutaYear, _target);
            source.Destination = Path.Combine(_target, source.ValutaYear);
            String[] MyGuid = GenerateFilename(source.Filename,source.Extension);
            source.MetaDataFileName = MyGuid[1];
            source.ContentFilePath = $"{source.Destination}\\{MyGuid[0]}";
            XmlService.MetadataItemToXml(source, source.Destination);
            var newFile = source.ContentFilePath;
            File.Copy(source.OriginalPath,newFile);
            
        }

        internal string[] GenerateFilename(string filename, string extension)
        {
            string[] result = new string[2];
            var suffixString = Guid.NewGuid().ToString();
            result[0] = $"{suffixString}_{filename}_Content.{extension}";
            result[1] = $"{suffixString}_{filename}_Metadata.xml";
            return result;
        }

        internal string GetFilename(string source)
        {
            string ret ="";
            var position = 0;
            var positionExtension = 0;
            if (source == "")
            {
                return ret;
            }
            position = source.LastIndexOf(@"\");
            positionExtension = source.LastIndexOf(".");
            if (position != 0 && positionExtension != 0)
            {
                ret = source.Substring(position + 1, positionExtension - position - 1);
            }
            
            return ret;
        }

        internal string GetExtension(string source)
        {
            string ret = "";
           
            var positionExtension = 0;

            positionExtension = source.LastIndexOf(".");
            ret = source.Substring(positionExtension + 1);
            return ret;
        }
        
        internal void SetDestinationDir(string year, string target)
        {
            if (Destiny.DestinationDir(year, target))
            {
                DirectoryFolder.Add(year);
            }
        }

        internal IList<string> ExtractFolderList()
        {
            return DirectoryFolder;
        }

        internal void GenerateFolderList()
        {
            DirectoryFolder = Destiny.GetExistingDirectories(_target);
        }

        public IList<MetadataItem> LoadMetadata()
        {
            var metadataFile = GetAllFiles();
            var metadataList = XmlService.XmlToMetadataItems(metadataFile);
            return metadataList;
        }

        private IList<string> GetAllFiles()
        {

            var metadataFile = Destiny.GetAllFiles(DirectoryFolder, _target);
            
            return metadataFile;
        }
    }
}
