using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IWarehouseDefaultNonNettableLocationCRUD
    {
        string GetWhseDefNonNetLoc(string Whse);
    }

    public class WarehouseDefaultNonNettableLocationCRUD : IWarehouseDefaultNonNettableLocationCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB applicationDB;

        public WarehouseDefaultNonNettableLocationCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IApplicationDB applicationDB
            )
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.applicationDB = applicationDB;
        }

        public string GetWhseDefNonNetLoc(string Whse)
        {
            LocType WhseDefNonNetLoc = DBNull.Value;

            var WhseDefNonNetLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {WhseDefNonNetLoc,"def_external_whse_non_nettable_loc"},
                },
                tableName: "whse",
                loadForChange: false,
                lockingType: LockingType.None,                
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("whse = {0}", Whse),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var WhseDefNonNetLocResponse = this.applicationDB.Load(WhseDefNonNetLocRequest);

            return WhseDefNonNetLoc;
        }
    }
}
