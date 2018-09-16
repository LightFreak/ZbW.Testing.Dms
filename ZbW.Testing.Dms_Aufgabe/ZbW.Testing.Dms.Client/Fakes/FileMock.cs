using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;

namespace ZbW.Testing.Dms.Client.Fakes
{
    class FileMock : IFile
    {
        public bool CheckDirectoryCalled { get; set; }

        public bool CheckDirectory(string destination)
        {
            CheckDirectoryCalled = true;
            return true;
        }

        public bool CreateDirectoryCalled { get; set; }
        public void CreateDirectory(string destination)
        {
            CreateDirectoryCalled = true;
        }
    }
}
