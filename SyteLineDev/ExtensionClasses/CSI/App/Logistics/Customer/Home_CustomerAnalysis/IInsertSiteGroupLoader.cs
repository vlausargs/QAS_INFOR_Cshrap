using CSI.Data.CRUD;
using System.Collections.Generic;

namespace CSI.Logistics.Customer
{
    public interface IInsertSiteGroupLoader
    {
        IList<string> InsertSiteGroup(ICollectionLoadResponse tt_siteLoadResponse);
    }
}