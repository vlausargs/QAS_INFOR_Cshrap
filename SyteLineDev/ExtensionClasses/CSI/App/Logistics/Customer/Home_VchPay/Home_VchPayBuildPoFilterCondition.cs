using CSI.Data.CRUD;
using CSI.Data.SQL;
using System;

namespace CSI.Logistics.Customer
{
    public class Home_VchPayBuildPoFilterCondition : IHome_VchPayBuildPoFilterCondition
    {
        readonly ICollectionLoadRequestFactory _collectionLoadRequestFactory;

        public Home_VchPayBuildPoFilterCondition(ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            _collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public IParameterizedCommand GetPoFilterWhereClause(DateTime? CutoffDate, string SiteGroup, string filterInPlaceWhereClause)
        {
            return _collectionLoadRequestFactory.Clause(@"CHARINDEX(po_all.type, 'RB') <> 0 AND CHARINDEX(po_all.stat, 'O') <> 0 AND po_all.site_ref IN (SELECT site FROM site_group WHERE site_group = {1}) 
                                  AND EXISTS (SELECT 1 FROM poitem_all INNER JOIN po_vch_all ON po_vch_all.po_num = po_all.po_num AND po_vch_all.po_line = poitem_all.po_line AND po_vch_all.po_release = poitem_all.po_release 
                                  WHERE poitem_all.po_num = po_all.po_num AND CHARINDEX(poitem_all.stat, 'OF') <> 0 AND poitem_all.site_ref = po_all.site_ref AND (po_vch_all.rcvd_date <= {0} OR po_vch_all.type = 'G') AND po_vch_all.site_ref IN (SELECT site FROM site_group WHERE site_group = {1})) 
                                  AND " + filterInPlaceWhereClause, CutoffDate, SiteGroup);
        }
    }
}
