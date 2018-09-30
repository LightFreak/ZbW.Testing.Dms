using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;
using Directory = System.IO.Directory;

namespace ZbW.Testing.Dms.Client.Provider
{
    class FileServices : IFile
    {
        public bool CheckDirectory(string destination)
        {
            if (!Directory.Exists(destination))
            {
                return false;
            }

            return true; 
        }

        public void CreateDirectory(string destination)
        {
            Directory.CreateDirectory(destination);
        }

        public virtual bool DestinationDir(string year, string target)
        {
            if(!Directory.Exists(Path.Combine(target,year)))
            {
                Directory.CreateDirectory(Path.Combine(target, year));
                return true;
            }
            return true;

        }

        public IList<string> GetAllFiles(IList<string> FolderList, string _target)
        {
            var metadataFile = new List<string>();
            foreach (var d in FolderList)
            {
                var path = _target + @"\" + d + @"\*_Metadata.xml";
                var list = Directory.GetFiles(_target + @"\" + d, @"*_Metadata.xml");
                metadataFile.AddRange(list);
            }

            return metadataFile;
        }

        public IList<string> GetExistingDirectories(string _target)
        {
            IList<string> result = new List<string>();
            if (_target != null)
            {
                
                IList<string> temp = Directory.GetDirectories(_target);
                foreach (var dir in temp)
                {
                    var position = dir.LastIndexOf(@"\");
                    if (position != 0)
                    {
                        result.Add(dir.Substring(position + 1)); 
                    }
                }
            }

            return result;
        }
    }
}
