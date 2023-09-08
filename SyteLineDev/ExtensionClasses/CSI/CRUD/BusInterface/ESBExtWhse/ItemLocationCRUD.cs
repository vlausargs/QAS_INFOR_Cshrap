using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemLocationCRUD
    {
        string GetItemNonNetLoc(string item, string whse);
        string GetItemNetLoc(string item, string whse);
    }

    public class ItemLocationCRUD : IItemLocationCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB applicationDB;

        public ItemLocationCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IApplicationDB applicationDB
            )
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.applicationDB = applicationDB;
        }

        public string GetItemNonNetLoc(string Item, string Whse)
        {
            LocType NonNetLoc = DBNull.Value;

            var ItemNonNetLocRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {NonNetLoc,"loc"},
                },
                tableName: "itemloc",
                loadForChange: false,
                lockingType: LockingType.None,                
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item = {0} AND whse = {1} AND loc_type = 'S' AND mrb_flag = 1", Item, Whse),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            _ = this.applicationDB.Load(ItemNonNetLocRequest);

            return NonNetLoc;
        }

        public string GetItemNetLoc(string item, string whse)
        {
            LocType NettableLoc = DBNull.Value;
            var whseLoadRequest = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {NettableLoc,"loc"},
                },
                tableName: "itemloc",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("whse = {0} AND loc_type = 'S' AND item = {1} AND (mrb_flag = 0 OR mrb_flag IS NULL)", whse, item),
                orderByClause: collectionLoadRequestFactory.Clause(""),
                maximumRows: 1);
            _ = applicationDB.Load(whseLoadRequest);

            return NettableLoc;
        }
    }
}
