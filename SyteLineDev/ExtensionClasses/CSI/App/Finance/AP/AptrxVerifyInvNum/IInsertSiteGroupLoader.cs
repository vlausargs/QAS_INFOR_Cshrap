using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Vendor
{
    public interface IInsertSiteGroupLoader
    {
        IList<string> InsertSiteGroup(ICollectionLoadResponse tt_siteLoadResponse);
    }
}
