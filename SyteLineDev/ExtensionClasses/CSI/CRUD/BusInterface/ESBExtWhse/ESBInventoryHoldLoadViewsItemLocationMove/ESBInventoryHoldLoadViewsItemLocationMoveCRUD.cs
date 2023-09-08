using CSI.Data.CRUD;
using CSI.MG;
using System;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface IESBInventoryHoldLoadViewsItemLocationMoveCRUD
    {
        void DeleteTmpSerData(Guid SeesionID, string workkey);
    }

    public class ESBInventoryHoldLoadViewsItemLocationMoveCRUD : IESBInventoryHoldLoadViewsItemLocationMoveCRUD
    {
        readonly ICollectionNonTriggerDeleteRequestFactory iCollectionNonTriggerDeleteRequestFactory;
        readonly IApplicationDB iApplicationDB;
        public ESBInventoryHoldLoadViewsItemLocationMoveCRUD(ICollectionNonTriggerDeleteRequestFactory iCollectionNonTriggerDeleteRequestFactory, IApplicationDB iApplicationDB)
        {
            this.iCollectionNonTriggerDeleteRequestFactory = iCollectionNonTriggerDeleteRequestFactory;
            this.iApplicationDB = iApplicationDB;
        }

        public void DeleteTmpSerData(Guid SeesionID, string workkey)
        {
            var deleteRequest = iCollectionNonTriggerDeleteRequestFactory.SQLDelete(
                tableName: "tmp_ser",
                fromClause: iCollectionNonTriggerDeleteRequestFactory.Clause(""),
                whereClause: iCollectionNonTriggerDeleteRequestFactory.Clause("SessionID = {0} AND ref_str = {1}", SeesionID, workkey));
            iApplicationDB.DeleteWithoutTrigger(deleteRequest);
        }
    }

}
