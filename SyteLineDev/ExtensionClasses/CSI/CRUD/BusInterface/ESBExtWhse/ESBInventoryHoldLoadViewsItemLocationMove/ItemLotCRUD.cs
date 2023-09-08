using CSI.Data.CRUD;
using CSI.Data.Functions;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IItemLotCRUD
    {
        bool IsExistLot(string item, string lot, string site);

    }
    public class ItemLotCRUD: IItemLotCRUD
    {

        readonly IExistsChecker existsChecker;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;

        public ItemLotCRUD(IExistsChecker existsChecker, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.existsChecker = existsChecker;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }

        public bool IsExistLot(string item, string lot, string site)
        {
            return existsChecker.Exists(tableName: "lot_all",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("lot_all.lot = {2} AND lot_all.item = {0} AND lot_all.site_ref = {1}", item, site, lot));
        }
    }
}
