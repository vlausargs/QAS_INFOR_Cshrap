//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetMATLRULE.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
    public class CLM_ApsGetMATLRULE : ICLM_ApsGetMATLRULE
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ApsGetMATLRULECRUD iCLM_ApsGetMATLRULECRUD;

        public CLM_ApsGetMATLRULE(IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ApsGetMATLRULECRUD iCLM_ApsGetMATLRULECRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_ApsGetMATLRULECRUD = iCLM_ApsGetMATLRULECRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ApsGetMATLRULESp(
            int? AltNo,
            string Filter = null)
        {

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {

                ICollectionLoadResponse Data = null;

                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? rowCount = null;
                int? Severity = null;
                string Table = null;
                string Infobar = null;
                string SelectionClause = null;
                string FromClause = null;
                string WhereClause = null;
                string AdditionalClause = null;
                if (this.iCLM_ApsGetMATLRULECRUD.Optional_ModuleForExists())
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");
                    var optional_module1LoadResponse = this.iCLM_ApsGetMATLRULECRUD.Optional_Module1Select();
                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    this.iCLM_ApsGetMATLRULECRUD.Optional_Module1Insert(optional_module1LoadResponse);
                    while (this.iCLM_ApsGetMATLRULECRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iCLM_ApsGetMATLRULECRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                        var ALTGEN = this.iCLM_ApsGetMATLRULECRUD.AltExtGen_CLM_ApsGetMATLRULESp(ALTGEN_SpName,
                            AltNo,
                            Filter);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        var tv_ALTGEN2LoadResponse = this.iCLM_ApsGetMATLRULECRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                        this.iCLM_ApsGetMATLRULECRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                    }

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetMATLRULESp") != null)
                {
                    var EXTGEN = this.iCLM_ApsGetMATLRULECRUD.AltExtGen_CLM_ApsGetMATLRULESp("dbo.EXTGEN_CLM_ApsGetMATLRULESp",
                        AltNo,
                        Filter);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                Table = stringUtil.Concat("MATLRULE", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                SelectionClause = "SELECT LMATLID, RSITEID, EFFECTID, RMATLID, FLEADTIME, VLEADTIME, TRANSIT, TIMEOUT, UOMSCALE, RowPointer";
                FromClause = stringUtil.Concat(" FROM ", stringUtil.QuoteName(Table));
                WhereClause = "WHERE 1 = 1";
                AdditionalClause = " ORDER BY LMATLID, RSITEID, EFFECTID";

                this.sQLExpressionExecutor.Execute(@"Declare
					@SelectionClause VeryLongListType
					,@FromClause VeryLongListType
					,@WhereClause VeryLongListType
					,@AdditionalClause VeryLongListType
					,@Filter LongListType
					SELECT @SelectionClause AS SelectionClause,
					       @FromClause AS FromClause,
					       @WhereClause AS WhereClause,
					       @AdditionalClause AS AdditionalClause,
					       N'LMATLID, RSITEID, EFFECTID' AS KeyColumns,
					       @Filter AS FilterString
					INTO   #DynamicParameters
					WHERE 1 = 2");
                var DynamicParametersLoadResponse = this.iCLM_ApsGetMATLRULECRUD.DynamicparametersSelect(SelectionClause, FromClause, WhereClause, AdditionalClause, Filter);

                this.iCLM_ApsGetMATLRULECRUD.DynamicparametersInsert(DynamicParametersLoadResponse);

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ExecuteDynamicSQLSp
                var ExecuteDynamicSQL = this.iExecuteDynamicSQL.ExecuteDynamicSQLSp(
                    NeedGetMoreRows: 1,
                    Infobar: Infobar);
                Severity = ExecuteDynamicSQL.ReturnCode;
                Data = ExecuteDynamicSQL.Data;
                Infobar = ExecuteDynamicSQL.Infobar;

                #endregion ExecuteMethodCall

                return (Data, Severity);

            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

    }
}
