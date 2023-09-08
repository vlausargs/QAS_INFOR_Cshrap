//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetEFFECT.cs

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
    public class CLM_ApsGetEFFECT : ICLM_ApsGetEFFECT
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ApsGetEFFECTCRUD iCLM_ApsGetEFFECTCRUD;

        public CLM_ApsGetEFFECT(IBunchedLoadCollection bunchedLoadCollection,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ApsGetEFFECTCRUD iCLM_ApsGetEFFECTCRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_ApsGetEFFECTCRUD = iCLM_ApsGetEFFECTCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ApsGetEFFECTSp(
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
                string SelectionClause = null;
                string FromClause = null;
                string Infobar = null;
                if (this.iCLM_ApsGetEFFECTCRUD.Optional_ModuleForExists())
                {
                    this.iCLM_ApsGetEFFECTCRUD.DeclareALTGENTABLE();
                    this.iCLM_ApsGetEFFECTCRUD.Optional_Module1Insert();
                    while (this.iCLM_ApsGetEFFECTCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iCLM_ApsGetEFFECTCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                        var ALTGEN = this.iCLM_ApsGetEFFECTCRUD.AltExtGen_CLM_ApsGetEFFECTSp(ALTGEN_SpName,
                            AltNo,
                            Filter);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        var tv_ALTGEN2LoadResponse = this.iCLM_ApsGetEFFECTCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                        this.iCLM_ApsGetEFFECTCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    }

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetEFFECTSp") != null)
                {
                    var EXTGEN = this.iCLM_ApsGetEFFECTCRUD.AltExtGen_CLM_ApsGetEFFECTSp("dbo.EXTGEN_CLM_ApsGetEFFECTSp",
                        AltNo,
                        Filter);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                Table = stringUtil.Concat("EFFECT", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                SelectionClause = @"SELECT
					                           EFFECTID
					                         , DESCR
					                         , STARTDATE
					                         , ENDDATE
					                         , DATETYPE
					                         , CONDITION
					                         , VALUE
					                         , PartNo
					                         , Contract
					                         , RowPointer";
                FromClause = stringUtil.Concat(" FROM ", stringUtil.QuoteName(Table));

                this.iCLM_ApsGetEFFECTCRUD.DeclareDynamicParameterTable();

                this.iCLM_ApsGetEFFECTCRUD.DynamicparametersInsert(SelectionClause, FromClause, Filter);

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
