using System;
using System.Collections.Generic;
using System.Text;

namespace PLLOC.Interfaces
{
    public interface IJPKV7MEntity1Manager
    {
        (string email, string name, string phone) GetJPKV7MEntity1ValueFromDB();
    }
}
