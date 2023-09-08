//PROJECT NAME: Production
//CLASS NAME: RSQC_GetIPparms.cs

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
    public class RSQC_GetIPparms : IRSQC_GetIPparms
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IRSQC_GetIPparmsCRUD iRSQC_GetIPparmsCRUD;

        public RSQC_GetIPparms(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IIsAddonAvailable iIsAddonAvailable,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            IRSQC_GetIPparmsCRUD iRSQC_GetIPparmsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iRSQC_GetIPparmsCRUD = iRSQC_GetIPparmsCRUD;
        }

        public (
            int? ReturnCode,
            int? NeedsQC)
        RSQC_GetIPparmsSp(
            int? NeedsQC)
        {

            ListYesNoType _NeedsQC = NeedsQC;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iRSQC_GetIPparmsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iRSQC_GetIPparmsCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iRSQC_GetIPparmsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iRSQC_GetIPparmsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iRSQC_GetIPparmsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iRSQC_GetIPparmsCRUD.AltExtGen_RSQC_GetIPparmsSp(ALTGEN_SpName,
                        NeedsQC);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, NeedsQC);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iRSQC_GetIPparmsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iRSQC_GetIPparmsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetIPparmsSp") != null)
            {
                var EXTGEN = this.iRSQC_GetIPparmsCRUD.AltExtGen_RSQC_GetIPparmsSp("dbo.EXTGEN_RSQC_GetIPparmsSp",
                    NeedsQC);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.NeedsQC);
                }
            }

            if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
            {
                return (Severity = 0, NeedsQC);

            }
            (NeedsQC, rowCount) = this.iRSQC_GetIPparmsCRUD.Rs_QcparmipLoad(NeedsQC);

            return (Severity, NeedsQC);
        }

    }
}
