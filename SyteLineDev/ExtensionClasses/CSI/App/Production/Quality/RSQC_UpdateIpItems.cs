//PROJECT NAME: Production
//CLASS NAME: RSQC_UpdateIpItems.cs

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

namespace CSI.Production.Quality
{
    public class RSQC_UpdateIpItems : IRSQC_UpdateIpItems
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IRSQC_UpdateIpItemsCRUD iRSQC_UpdateIpItemsCRUD;

        public RSQC_UpdateIpItems(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IIsAddonAvailable iIsAddonAvailable,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            IRSQC_UpdateIpItemsCRUD iRSQC_UpdateIpItemsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iRSQC_UpdateIpItemsCRUD = iRSQC_UpdateIpItemsCRUD;
        }

        public int? RSQC_UpdateIpItemsSp()
        {

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iRSQC_UpdateIpItemsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iRSQC_UpdateIpItemsCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iRSQC_UpdateIpItemsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iRSQC_UpdateIpItemsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iRSQC_UpdateIpItemsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iRSQC_UpdateIpItemsCRUD.AltExtGen_RSQC_UpdateIpItemsSp(ALTGEN_SpName);
                    ALTGEN_Severity = ALTGEN;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iRSQC_UpdateIpItemsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iRSQC_UpdateIpItemsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_UpdateIpItemsSp") != null)
            {
                var EXTGEN = this.iRSQC_UpdateIpItemsCRUD.AltExtGen_RSQC_UpdateIpItemsSp("dbo.EXTGEN_RSQC_UpdateIpItemsSp");
                int? EXTGEN_Severity = EXTGEN;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity);
                }
            }

            if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
            {
                return (Severity = 0);

            }
            var rs_qcitemhLoadResponse = this.iRSQC_UpdateIpItemsCRUD.Rs_QcitemhSelect();
            this.iRSQC_UpdateIpItemsCRUD.Rs_QcitemhUpdate(rs_qcitemhLoadResponse);

            return (Severity);
        }

    }
}
