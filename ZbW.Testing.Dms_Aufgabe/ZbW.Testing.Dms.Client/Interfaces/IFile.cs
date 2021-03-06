﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbW.Testing.Dms.Client.Interfaces
{
    public interface IFile
    {
        bool DestinationDir(string year, string target);

        IList<string> GetAllFiles(IList<string> FolderList,string _target);

        IList<string> GetExistingDirectories(string _target);
    }


}
