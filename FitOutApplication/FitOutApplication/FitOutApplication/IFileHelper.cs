using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitOutApplication
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
