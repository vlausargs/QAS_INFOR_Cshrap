//PROJECT NAME: Data
//CLASS NAME: IIsAddonAvailable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IIsAddonAvailable
    {
        int? IsAddonAvailableFn(string ModuleName);
    }
}

