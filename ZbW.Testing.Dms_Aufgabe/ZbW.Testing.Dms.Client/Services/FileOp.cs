using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZbW.Testing.Dms.Client.Interfaces;
using ZbW.Testing.Dms.Client.Model;


namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileOp 
    {
        private readonly IFileNameGenerator _fileNameGenerator;
        
        private FileNameGenerator fng;
        private DirServices dir;

        public FileOp()
        {
            fng = new FileNameGenerator();
            dir = new DirServices();
        }


        public string MoveFile(MetadataItem source)
        {
            if (CheckDestinationDir(dir,source.Destination) == false)
            {
                CreateDestinationDir(dir,source.Destination);
            }
            String MyGuid = GenerateFilename(fng, source.Filename, source.Extension);
            var newFile = $"{source.Destination}\\{source.Filename}.{source.Extension}";
            File.Copy(source.OriginalPath, newFile);
            //MessageBox.Show(MyGuid);
            return MyGuid;
        }

        public string CopyFile(MetadataItem source)
        {
            if (CheckDestinationDir(dir,source.Destination) == false)
            {
                  CreateDestinationDir(dir,source.Destination);
            }
            String MyGuid = GenerateFilename(fng,source.Filename,source.Extension);
            var newFile = $"{source.Destination}\\{source.Filename}.{source.Extension}";
            File.Copy(source.OriginalPath,newFile);
            //MessageBox.Show(MyGuid);
            return MyGuid;
        }

        internal string GenerateFilename(IFileNameGenerator fileNameGenerator,string filename,string extension)
        {
            var suffixString = fileNameGenerator.GenerateGuid().ToString();
            return $"{suffixString}{filename}.{extension}";
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

        internal bool CheckDestinationDir(IFile dir, string destinationPath)
        {
            return dir.CheckDirectory(destinationPath);
        }

        internal void CreateDestinationDir(IFile dir,string destinationPath)
        {
            dir.CreateDirectory(destinationPath);
        }

        //public void GenerateXMLDoc(File file,string generatedGuid)
        //{

        //}


    }
}
