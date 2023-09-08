using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ISalesOrderLocationCRUD
    {
        string LoadTopOneLocationTmp_ship(Guid sessionID);
        ICollectionLoadResponse LoadLocationTmp_ship(Guid sessionID);
        void UpdateLocationTmp_ship(string nonNetLoc, ICollectionLoadResponse tmp_shipLocResponse);
    }

    public class SalesOrderLocationCRUD : ISalesOrderLocationCRUD
    {

        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB applicationDB;

        public SalesOrderLocationCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            IApplicationDB applicationDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.applicationDB = applicationDB;
        }

        public string LoadTopOneLocationTmp_ship(Guid sessionID)
        {
            LocType loc = DBNull.Value;

            var topOnetmp_shipLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {loc,"loc"},
                },
                tableName: "tmp_ship",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                maximumRows: 1);
            applicationDB.Load(topOnetmp_shipLocRequest);

            return loc;
        }

        public ICollectionLoadResponse LoadLocationTmp_ship(Guid sessionID)
        {
            var tmp_shipLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"loc","tmp_ship.loc"},
                },
                tableName: "tmp_ship",
                loadForChange: true,
                lockingType: LockingType.UPDLock,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("SessionID = {0}", sessionID),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return applicationDB.Load(tmp_shipLocRequest);
        }

        public void UpdateLocationTmp_ship(string nonNetLoc, ICollectionLoadResponse tmp_shipLocResponse)
        {
            foreach (var tmp_shipLoc in tmp_shipLocResponse.Items)
            {
                tmp_shipLoc.SetValue<string>("loc", nonNetLoc);
            };

            var tmp_shipLocUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "tmp_ship",
                items: tmp_shipLocResponse.Items);

            applicationDB.Update(tmp_shipLocUpdate);
        }
    }
}
