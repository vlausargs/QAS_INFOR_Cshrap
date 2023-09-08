using CSI.Data.CRUD;
using CSI.Data.Functions;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemLotLocCRUD
    {
        bool IsExistItemLotLoc(string item, string lot, string loc);
    }

    public class ItemLotLocCRUD : IItemLotLocCRUD
    {
        readonly IExistsChecker existsChecker;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public ItemLotLocCRUD(IExistsChecker existsChecker, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.existsChecker = existsChecker;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public bool IsExistItemLotLoc(string item, string lot, string loc)
        {
            return existsChecker.Exists(tableName: "lot_loc",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("item = {1} AND loc = {0} AND lot = {2}", loc, item, lot));
        }
    }

}
