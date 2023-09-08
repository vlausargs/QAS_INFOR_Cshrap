using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Utilities
{
    public interface IFileNameUtil
    {
        string RemoveInvalidCharFromFileName(string fileName);
    }
}
