using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Interfaces
{
    public interface IFile
    {
        bool CheckDirectory(string destination);

        void CreateDirectory(string destination);
    }


}
