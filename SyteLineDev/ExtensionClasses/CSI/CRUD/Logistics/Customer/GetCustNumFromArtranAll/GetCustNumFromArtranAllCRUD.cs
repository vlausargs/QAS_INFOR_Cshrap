using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.CRUD.Logistics.Customer
{
    public interface IGetCustNumFromArtranAllCRUD
    {
        CustNumType GetCustNum(InvNumType invNum, SiteType site);
    }

    public class GetCustNumFromArtranAllCRUD : IGetCustNumFromArtranAllCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB appDB;

        public GetCustNumFromArtranAllCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory ?? throw new ArgumentNullException(nameof(collectionLoadRequestFactory));
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public CustNumType GetCustNum(InvNumType invNum, SiteType site)
        {
            CustNumType custNum = DBNull.Value;

            var request = collectionLoadRequestFactory.SQLLoad(
               columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
               {
                   { custNum,         "cust_num" },
               },

            tableName: "artran_all",
            loadForChange: false,
            lockingType: LockingType.None,
            fromClause: collectionLoadRequestFactory.Clause("WITH (READUNCOMMITTED)"),
            whereClause: collectionLoadRequestFactory.Clause("inv_num = {0} AND site_ref = {1} AND inv_seq=0", invNum, site)
            );

            appDB.Load(request);

            return custNum;
        }
    }
}
