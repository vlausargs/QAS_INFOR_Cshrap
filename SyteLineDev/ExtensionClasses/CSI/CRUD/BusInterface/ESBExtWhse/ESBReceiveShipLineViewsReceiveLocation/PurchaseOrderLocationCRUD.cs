using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IPurchaseOrderLocationCRUD
    {
        string LoadTopOneLocationTt_rcv(Guid sessionID);
        ICollectionLoadResponse LoadLocationTt_rcv(Guid sessionID);
        void UpdateLocationTt_rcv(string nonNetLoc, ICollectionLoadResponse tt_rcvLocResponse);
    }

    public class PurchaseOrderLocationCRUD : IPurchaseOrderLocationCRUD
    {

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB applicationDB;

        public PurchaseOrderLocationCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IApplicationDB applicationDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.applicationDB = applicationDB;
        }

        public string LoadTopOneLocationTt_rcv(Guid sessionID)
        {
            LocType Loc = DBNull.Value;

            var topOnett_rcvLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {Loc,"loc"},
                },
                tableName: "tt_rcv",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                maximumRows: 1);
            applicationDB.Load(topOnett_rcvLocRequest);

            return Loc;
        }

        public ICollectionLoadResponse LoadLocationTt_rcv(Guid sessionID)
        {
            var tt_rcvLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"loc","tt_rcv.loc"},
                },
                tableName: "tt_rcv",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return applicationDB.Load(tt_rcvLocRequest);
        }

        public void UpdateLocationTt_rcv(string nonNetLoc, ICollectionLoadResponse tt_rcvLocResponse)
        {
            foreach (var tt_rcvLoc in tt_rcvLocResponse.Items)
            {
                tt_rcvLoc.SetValue<string>("loc", nonNetLoc);
            };

            var tt_rcvLocUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tt_rcv",
                items: tt_rcvLocResponse.Items);

            applicationDB.Update(tt_rcvLocUpdate);
        }
    }
}
