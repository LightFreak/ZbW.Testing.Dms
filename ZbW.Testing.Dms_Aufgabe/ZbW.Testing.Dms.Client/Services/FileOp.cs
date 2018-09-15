using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileOp 
    {
        private readonly IFileNameGenerator _fileNameGenerator;
        private FileNameGenerator fng;

        public FileOp()
        {
            fng = new FileNameGenerator();
        }


        public string MoveFile(string source)
        {
            
            String MyGuid = GenerateFilename(fng,source);
            //MessageBox.Show(MyGuid);
            return MyGuid;

        }

        public string CopyFile(string source)
        {
            String MyGuid = GenerateFilename(fng,source);
            //MessageBox.Show(MyGuid);
            return MyGuid;
        }

        public string GenerateFilename(IFileNameGenerator fileNameGenerator,string filename)
        {
            var suffixString = fileNameGenerator.GenerateGuid().ToString();
            return $"{suffixString}{filename}";
        }

        public string GetFilename(string source)
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

        public string GetExtension(string source)
        {
            string ret = "";
           
            var positionExtension = 0;

            positionExtension = source.LastIndexOf(".");
            ret = source.Substring(positionExtension + 1);
            return ret;
        }

        //public void GenerateXMLDoc(File file,string generatedGuid)
        //{

        //}


    }
}
