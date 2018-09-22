using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZbW.Testing.Dms.Client.Interfaces;

namespace ZbW.Testing.Dms.Client.Provider
{
    internal class FileNameGenerator : IFileNameGenerator
    {
        public virtual string NewGuid()
        {

            return System.Guid.NewGuid().ToString();
            
        }
    }
}
