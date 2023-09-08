//PROJECT NAME: Data
//CLASS NAME: IGetCatalogRowPointer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IGetCatalogRowPointer
    {
        Guid? GetCatalogRowPointerFn(
            string CustNum);
    }
}

