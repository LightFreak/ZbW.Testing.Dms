using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;

namespace ZbW.Testing.Dms.Client.Fakes
{
    class FileStub : IFile
    {
        private readonly string _destination;

        public FileStub(string destination)
        {
            _destination = destination;
        }
        public bool CheckDirectory(string destination)
        {
            
            return destination.Equals(_destination);
            
        }

        public void CreateDirectory(string destination)
        {
            //throw new NotImplementedException();
        }
    }
}
