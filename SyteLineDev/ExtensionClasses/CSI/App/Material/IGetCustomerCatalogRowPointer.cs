//PROJECT NAME: Material
//CLASS NAME: IGetCustomerCatalogRowPointer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
    public interface IGetCustomerCatalogRowPointer
    {
            (int? ReturnCode,
            Guid? CatalogRowPointer,
            string Infobar) 
        GetCustomerCatalogRowPointerSp(
            string CustNum,
            Guid? CatalogRowPointer,
            string Infobar);
    }
}

