using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface ISLItemCatalogs
    {
        int GetCustomerCatalogRowPointerSp(string CustNum, ref Guid? CatalogRowPointer, ref string Infobar);
    }
}
