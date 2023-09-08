using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemWarehouseCRUD
    {
        bool IsExistItemwhse(string Item, string Whse);
        void InsertItemwhse(string Item, string Whse);
    }
    public class ItemWarehouseCRUD : IItemWarehouseCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly IApplicationDB applicationDB;

        public ItemWarehouseCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            IApplicationDB applicationDB
            )
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.applicationDB = applicationDB;
        }

        public bool IsExistItemwhse(string Item, string Whse)
        {
            return existsChecker.Exists(tableName: "itemwhse",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item = {0} AND whse = {1}", Item, Whse));
        }

        public void InsertItemwhse(string Item, string Whse)
        {
            var itemwhseLoadResponse = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "item", Item},
                    { "whse", Whse},
            });

            var itemwhseInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "itemwhse",
                items: this.applicationDB.Load(itemwhseLoadResponse).Items);

            this.applicationDB.Insert(itemwhseInsertRequest);
        }

    }
}