using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;

namespace CSI.BusInterface.ESBExtWhse
{
    public interface ILotAndSNTrackedFlagCRUD
    {
        (int? lotTracked, int? serialTracked, int count) GetLotAndSNTrackedFlag(string Item);
    }

    public class LotAndSNTrackedFlagCRUD : ILotAndSNTrackedFlagCRUD
    {
        readonly ICollectionLoadRequestFactory iCollectionLoadRequestFactory;
        readonly IApplicationDB iApplicationDB;

        public LotAndSNTrackedFlagCRUD(ICollectionLoadRequestFactory iCollectionLoadRequestFactory, IApplicationDB iApplicationDB)
        {
            this.iCollectionLoadRequestFactory = iCollectionLoadRequestFactory;
            this.iApplicationDB = iApplicationDB;
        }


        public (int? lotTracked, int? serialTracked, int count) GetLotAndSNTrackedFlag(string Item)
        {
            ListYesNoType lotTracked = DBNull.Value;
            ListYesNoType serialTracked = DBNull.Value;

            var itemLoadRequest = iCollectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {lotTracked,"lot_tracked"},
                    {serialTracked,"serial_tracked"},
                },
                tableName: "item",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: iCollectionLoadRequestFactory.Clause(""),
                whereClause: iCollectionLoadRequestFactory.Clause("item = {0}", Item),
                orderByClause: iCollectionLoadRequestFactory.Clause(""),
                maximumRows: 1);
            var itemLoadResponse = iApplicationDB.Load(itemLoadRequest);
            int rowCount = itemLoadResponse.Items.Count;
            return (lotTracked, serialTracked, rowCount);
        }
    }
}
