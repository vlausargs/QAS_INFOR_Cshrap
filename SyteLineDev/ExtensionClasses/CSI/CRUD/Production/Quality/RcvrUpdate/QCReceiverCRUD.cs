using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.CRUD.Production.Quality.RcvrUpdate
{
    public interface IQCReceiverCRUD
    {
        void GetQtyDataByRcvrNum(int? RcvrNum, out QtyUnitType QtyAvail, out QtyUnitType QtyHold, out ListYesNoType RcvrComplete, out QtyUnitType QtyReceived);

        void UpdateQtyReceivedAndTransactionCompleteByRcvrNum(int? RcvrNum, QtyUnitType QtyReceived, decimal? Qty, byte? Complete);
    }
    
    public class QCReceiverCRUD : IQCReceiverCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB appDB;

        public QCReceiverCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, ICollectionUpdateRequestFactory collectionUpdateRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory ?? throw new ArgumentNullException(nameof(collectionUpdateRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public void GetQtyDataByRcvrNum(int? RcvrNum, out QtyUnitType QtyAvail, out QtyUnitType QtyHold, out ListYesNoType RcvrComplete, out QtyUnitType QtyReceived)
        {
            QtyUnitType qtyAvail = DBNull.Value;
            QtyUnitType qtyHold = DBNull.Value;
            ListYesNoType rcvrComplete = DBNull.Value;
            QtyUnitType qtyReceived = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
                                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    { qtyAvail,         "(rs_qcrcvr.qty_received - rs_qcrcvr.qty_accepted - rs_qcrcvr.qty_rejected - rs_qcrcvr.qty_hold)" },
                                    { qtyHold,          "rs_qcrcvr.qty_hold" },
                                    { rcvrComplete,     "rs_qcrcvr.complete"},
                                    { qtyReceived,      "rs_qcrcvr.qty_received"}
                                },
                            tableName: "rs_qcrcvr",
                            loadForChange: false,
                            lockingType: LockingType.None,
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("rs_qcrcvr.rcvr_num = {0}", RcvrNum));

            this.appDB.Load(request);

            QtyAvail = qtyAvail;
            QtyHold = qtyHold;
            QtyReceived = qtyReceived;
            RcvrComplete = rcvrComplete;
        }

        public void UpdateQtyReceivedAndTransactionCompleteByRcvrNum(int? RcvrNum, QtyUnitType QtyReceived, decimal? Qty, byte? Complete)
        {
            var requestLoad = collectionLoadRequestFactory.SQLLoad(
                                columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    { "qty_received",      "qty_received"},
                                    { "complete",           "complete"}
                                },
                            tableName: "rs_qcrcvr",
                            loadForChange: true,
                            lockingType: LockingType.UPDLock,
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("rs_qcrcvr.rcvr_num = {0}", RcvrNum)
                            );

            var result = this.appDB.Load(requestLoad);

            foreach (var item in result.Items)
            {
                var qty = item.GetValue<decimal?>("qty_received");
                var complete = item.GetValue<byte?>("complete");
                item.SetValue<object>("qty_received", qty + Qty);
                item.SetValue<object>("complete", complete);
            }

            var requestUpdate = collectionUpdateRequestFactory.SQLUpdate(
                tableName: "rs_qcrcvr",
                items: result.Items);
            appDB.Update(requestUpdate);
        }
    }
}
