using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.CRUD.Reporting
{
    public class Rpt_VouchersPayableSubCRUD : IRpt_VouchersPayableSubCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public Rpt_VouchersPayableSubCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public ICollectionLoadRequest GetPovchCrsLoadRequestForCursor(DateTime? CutoffDate)
        {
            #region CRUD LoadToRecord
            var PovchCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                        {
                                            {"po_vch.type","po_vch.type"},
                                            {"po_vch.item_cost","po_vch.item_cost"},
                                            {"po_vch.exch_rate","po_vch.exch_rate"},
                                            {"po_vch.qty_received","po_vch.qty_received"},
                                            {"po_vch.qty_returned","po_vch.qty_returned"},
                                            {"po_vch.qty_vouchered","po_vch.qty_vouchered"},
                                            {"po_vch.rcvd_date","po_vch.rcvd_date"},
                                            {"po_vch.date_seq","po_vch.date_seq"},
                                            {"po_vch.grn_num","po_vch.grn_num"},
                                            {"po_vch.pack_num","po_vch.pack_num"},
                                        },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_po_vch",
                fromClause: collectionLoadRequestFactory.Clause(" po_vch"),
                whereClause: collectionLoadRequestFactory.Clause("po_vch.rcvd_date <= {0}", CutoffDate),
                orderByClause: collectionLoadRequestFactory.Clause(" po_vch.rcvd_date, po_vch.date_seq"),
                maximumRows: 0,
                targetTableName: null);
            #endregion  LoadToRecord

            return PovchCrsLoadRequestForCursor;
        }

        public ICollectionLoadRequest GetSiteGroupCrsLoadRequestForCursor(string siteGroup, string siteRef)
        {
            #region CRUD LoadToRecord
            var siteGroupCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"site_Group.site","site_Group.site"},
                    },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "site_Group",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("site_Group.site_Group = {0} AND site_Group.site >= {1}", siteGroup, siteRef),
                orderByClause: collectionLoadRequestFactory.Clause(" site_Group.site"));
            #endregion  LoadToRecord

            return siteGroupCrsLoadRequestForCursor;
        }

        public (string PoVchType, decimal? PoVchItemCost, decimal? PoVchExchRate, decimal? PoVchQtyReceived,decimal? PoVchQtyReturned, decimal? PoVchQtyVouchered, DateTime? PoVchRcvdDate, int? PoVchDateSeq, string PoVchGrnNum, string PoVchPackNum) SetValues(IRecordReadOnly PovchCrsLoadResponseForCursor)
        {
            var PoVchType = PovchCrsLoadResponseForCursor.GetValue<string>(0);
            var PoVchItemCost = PovchCrsLoadResponseForCursor.GetValue<decimal?>(1);
            var PoVchExchRate = PovchCrsLoadResponseForCursor.GetValue<decimal?>(2);
            var PoVchQtyReceived = PovchCrsLoadResponseForCursor.GetValue<decimal?>(3);
            var PoVchQtyReturned = PovchCrsLoadResponseForCursor.GetValue<decimal?>(4);
            var PoVchQtyVouchered = PovchCrsLoadResponseForCursor.GetValue<decimal?>(5);
            var PoVchRcvdDate = PovchCrsLoadResponseForCursor.GetValue<DateTime?>(6);
            var PoVchDateSeq = PovchCrsLoadResponseForCursor.GetValue<int?>(7);
            var PoVchGrnNum = PovchCrsLoadResponseForCursor.GetValue<string>(8);
            var PoVchPackNum = PovchCrsLoadResponseForCursor.GetValue<string>(9);

            return (PoVchType, PoVchItemCost, PoVchExchRate, PoVchQtyReceived, PoVchQtyReturned, PoVchQtyVouchered, PoVchRcvdDate, PoVchDateSeq, PoVchGrnNum, PoVchPackNum);
        }
    }
}
