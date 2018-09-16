using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;

namespace ZbW.Testing.Dms.Client.Services
{
    class DirServices : IFile
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
    }
}
