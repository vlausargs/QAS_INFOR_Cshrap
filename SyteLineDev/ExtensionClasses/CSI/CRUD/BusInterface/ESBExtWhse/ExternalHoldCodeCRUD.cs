using CSI.Data.CRUD;
using CSI.Data.Functions;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IExternalHoldCodeCRUD
    {
        bool IsExistInExtWhseHoldCode(string HoldCode);
    }
    public class ExternalHoldCodeCRUD : IExternalHoldCodeCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;

        public ExternalHoldCodeCRUD(
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker
            )
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
        }

        public bool IsExistInExtWhseHoldCode(string HoldCode)
        {
            return existsChecker.Exists(tableName: "ext_whse_hold_code",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("hold_code = {0}", HoldCode));
        }

    }
}
