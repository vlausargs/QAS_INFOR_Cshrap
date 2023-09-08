using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Vendor
{

    public class InsertSiteGroupLoader : IInsertSiteGroupLoader
    {
        public IList<string> InsertSiteGroup(ICollectionLoadResponse tt_siteLoadResponse)
        {
            IList<string> siteGroupVar = new List<string>();
            foreach (var item in tt_siteLoadResponse.Items)
            {
                siteGroupVar.Add(item.GetValue<string>("site"));
            }
            return siteGroupVar;
        }
    }
}
