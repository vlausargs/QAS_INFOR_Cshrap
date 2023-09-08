using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ITransferOrderLocationCRUD
    {
        string LoadTopOneLocationTmp_transfer(Guid sessionID);
        ICollectionLoadResponse LoadLocationTmp_transfer(Guid sessionID);
        void UpdateLocationTmp_transfer(string nonNetLoc, ICollectionLoadResponse tmp_transferLocResponse);
    }

    public class TransferOrderLocationCRUD : ITransferOrderLocationCRUD
    {

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB applicationDB;

        public TransferOrderLocationCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IApplicationDB applicationDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.applicationDB = applicationDB;
        }
        public string LoadTopOneLocationTmp_transfer(Guid sessionID)
        {
            LocType Loc = DBNull.Value;

            var topOnetmp_transferLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {Loc,"to_loc"},
                },
                tableName: "##TmpTransfer",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                maximumRows: 1);
            applicationDB.Load(topOnetmp_transferLocRequest);

            return Loc;
        }

        public ICollectionLoadResponse LoadLocationTmp_transfer(Guid sessionID)
        {
            var tmp_transferLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"to_loc","##TmpTransfer.to_loc"},
                },
                tableName: "##TmpTransfer",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return applicationDB.Load(tmp_transferLocRequest);
        }

        public void UpdateLocationTmp_transfer(string nonNetLoc, ICollectionLoadResponse tmp_transferLocResponse)
        {
            foreach (var tmp_transferLoc in tmp_transferLocResponse.Items)
            {
                tmp_transferLoc.SetValue<string>("to_loc", nonNetLoc);
            };

            var tmp_transferLocUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "##TmpTransfer",
                items: tmp_transferLocResponse.Items);

            applicationDB.Update(tmp_transferLocUpdate);
        }

    }
}
