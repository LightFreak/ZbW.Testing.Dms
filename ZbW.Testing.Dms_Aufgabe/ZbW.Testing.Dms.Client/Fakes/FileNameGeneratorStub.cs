using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Fakes
{
    class FileNameGeneratorStub : IFileNameGenerator

    {
        private readonly string _guid;

        public FileNameGeneratorStub(string guid)
        {
            _guid = guid;
        }
        public string GenerateGuid()
        {
            return _guid;
        }
    }
}
