//PROJECT NAME: Finance
//CLASS NAME: CLM_FixedAssetDetailTran.cs

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

namespace CSI.Finance
{
    public class CLM_FixedAssetDetailTran : ICLM_FixedAssetDetailTran
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_FixedAssetDetailTranCRUD iCLM_FixedAssetDetailTranCRUD;

        public CLM_FixedAssetDetailTran(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_FixedAssetDetailTranCRUD iCLM_FixedAssetDetailTranCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_FixedAssetDetailTranCRUD = iCLM_FixedAssetDetailTranCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_FixedAssetDetailTranSp(
            string Ref = null)
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            string FaNum = null;
            string FaNumPrefix1 = null;
            string FaNumPrefix2 = null;
            int? FaNumStart = null;
            if (this.iCLM_FixedAssetDetailTranCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_FixedAssetDetailTranCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_FixedAssetDetailTranSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_FixedAssetDetailTranCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iCLM_FixedAssetDetailTranCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_FixedAssetDetailTranCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_FixedAssetDetailTranCRUD.AltExtGen_CLM_FixedAssetDetailTranSp(ALTGEN_SpName,
                        Ref);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_FixedAssetDetailTranCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_FixedAssetDetailTranCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_FixedAssetDetailTranSp") != null)
            {
                var EXTGEN = this.iCLM_FixedAssetDetailTranCRUD.AltExtGen_CLM_FixedAssetDetailTranSp("dbo.EXTGEN_CLM_FixedAssetDetailTranSp",
                    Ref);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            Severity = 0;
            FaNum = null;
            FaNumStart = 0;
            if (Ref != null)
            {
                FaNumPrefix1 = stringUtil.Left(Ref, 4);
                FaNumPrefix2 = stringUtil.Left(Ref, 6);
                if (sQLUtil.SQLEqual(FaNumPrefix1, "FAT ") == true)
                {
                    FaNumStart = 5;

                }
                else
                {
                    if (sQLUtil.SQLEqual(FaNumPrefix2, "FADEP ") == true || sQLUtil.SQLEqual(FaNumPrefix2, "FADSP ") == true)
                    {
                        FaNumStart = 7;

                    }

                }
                if (sQLUtil.SQLGreaterThan(FaNumStart, 0) == true)
                {
                    FaNum = stringUtil.Right(Ref, stringUtil.Len(Ref) - FaNumStart + 1);
                    FaNum = stringUtil.LTrim(stringUtil.RTrim(FaNum));

                }

            }
            var famasterLoadResponse = this.iCLM_FixedAssetDetailTranCRUD.FamasterSelect(FaNum);
            Data = famasterLoadResponse;

            return (Data, Severity);

        }

    }
}
