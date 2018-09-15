using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Services
{
    class FileNameGenerator : IFileNameGenerator
    {
        public string GenerateGuid()
        {

            return System.Guid.NewGuid().ToString();
            
        }
    }
}
