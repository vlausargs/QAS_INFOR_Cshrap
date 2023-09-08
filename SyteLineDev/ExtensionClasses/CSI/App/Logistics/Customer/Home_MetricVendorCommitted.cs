//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricVendorCommitted.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class Home_MetricVendorCommitted : IHome_MetricVendorCommitted
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IHome_MetricVendorCommittedCRUD iHome_MetricVendorCommittedCRUD;

        public Home_MetricVendorCommitted(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IHome_MetricVendorCommittedCRUD iHome_MetricVendorCommittedCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iHome_MetricVendorCommittedCRUD = iHome_MetricVendorCommittedCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Home_MetricVendorCommittedSp(
            int? Count = 10)
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            if (this.iHome_MetricVendorCommittedCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iHome_MetricVendorCommittedCRUD.Optional_Module1Select();

                this.iHome_MetricVendorCommittedCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iHome_MetricVendorCommittedCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iHome_MetricVendorCommittedCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iHome_MetricVendorCommittedCRUD.AltExtGen_Home_MetricVendorCommittedSp(ALTGEN_SpName,
                        Count);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iHome_MetricVendorCommittedCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iHome_MetricVendorCommittedCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Home_MetricVendorCommittedSp") != null)
            {
                var EXTGEN = this.iHome_MetricVendorCommittedCRUD.AltExtGen_Home_MetricVendorCommittedSp("dbo.EXTGEN_Home_MetricVendorCommittedSp",
                    Count);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
            Severity = 0;
            if (sQLUtil.SQLGreaterThan(Count, 0) == true)
            {
                var poitem1LoadResponse = this.iHome_MetricVendorCommittedCRUD.Poitem1Select(Count);
                Data = poitem1LoadResponse;

            }
            else
            {
                var poitem3LoadResponse = this.iHome_MetricVendorCommittedCRUD.Poitem3Select();
                Data = poitem3LoadResponse;

            }
            return (Data, Severity);

        }

    }
}
