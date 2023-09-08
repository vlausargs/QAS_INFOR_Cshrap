using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSI.Data.SQL.UDDT;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class ProcessFreightRateShopRequestCRUD : IProcessFreightRateShopRequestCRUD
    {
        ICollectionLoadRequestFactory collectionLoadRequestFactory;
        IApplicationDB appDB;

        public ProcessFreightRateShopRequestCRUD(ICollectionLoadRequestFactory collectionLoadRequestFactory, IApplicationDB appDB)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
        }

        public (string SuiteContext, string Path) GetFreightRateShopIONAPISuiteMethod(string suiteName, string methodName)
        {
            LongStringType _SuiteContext = DBNull.Value;
            LongStringType _Path = DBNull.Value;
            string SuiteContext = null;
            string Path = null;

            #region CRUD LoadToVariable
            var shipcodeLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_SuiteContext,"IONAPISuites.SuiteContext"},
                    {_Path, "IONAPIMethods.Path" }

                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "IONAPISuites",
                fromClause: collectionLoadRequestFactory.Clause("LEFT OUTER JOIN IONAPIMethods ON " +
                                                                    "IONAPISuites.ServerID=IONAPIMethods.ServerID " +
                                                                    "AND IONAPISuites.SuiteName=IONAPIMethods.SuiteName " +
                                                                "INNER JOIN coparms ON " +
                                                                    "IONAPISuites.ServerID=coparms.freight_api_server_id"),
                whereClause: collectionLoadRequestFactory.Clause("IONAPISuites.SuiteName={0} AND IONAPIMethods.Name={1}", suiteName, methodName),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var shipcodeLoadResponse = this.appDB.Load(shipcodeLoadRequest);
            if (shipcodeLoadResponse.Items.Count > 0)
            {
                SuiteContext = _SuiteContext;
                Path = _Path;
            }
            #endregion  LoadToVariable


            return (SuiteContext, Path);
        }


    }
}
