//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetPART.cs

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
    public class CLM_ApsGetPART : ICLM_ApsGetPART
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IExecuteDynamicSQL iExecuteDynamicSQL;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ApsGetPARTCRUD iCLM_ApsGetPARTCRUD;

        public CLM_ApsGetPART(IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IExecuteDynamicSQL iExecuteDynamicSQL,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ApsGetPARTCRUD iCLM_ApsGetPARTCRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iExecuteDynamicSQL = iExecuteDynamicSQL;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_ApsGetPARTCRUD = iCLM_ApsGetPARTCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ApsGetPARTSp(
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
                if (this.iCLM_ApsGetPARTCRUD.Optional_ModuleForExists())
                {
                    this.iCLM_ApsGetPARTCRUD.DeclareALTGENTABLE();
                    this.iCLM_ApsGetPARTCRUD.Optional_Module1Insert();
                    while (this.iCLM_ApsGetPARTCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iCLM_ApsGetPARTCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                        var ALTGEN = this.iCLM_ApsGetPARTCRUD.AltExtGen_CLM_ApsGetPARTSp(ALTGEN_SpName,
                            AltNo,
                            Filter);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }

                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        var tv_ALTGEN2LoadResponse = this.iCLM_ApsGetPARTCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                        this.iCLM_ApsGetPARTCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    }
                }

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ApsGetPARTSp") != null)
                {
                    var EXTGEN = this.iCLM_ApsGetPARTCRUD.AltExtGen_CLM_ApsGetPARTSp("dbo.EXTGEN_CLM_ApsGetPARTSp",
                        AltNo,
                        Filter);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                Severity = 0;
                Table = stringUtil.Concat("PART", stringUtil.Replace(
                    stringUtil.Str(
                        AltNo,
                        3),
                    " ",
                    "0"));
                SelectionClause = "";
                FromClause = "";
                WhereClause = "";
                AdditionalClause = "";
                SelectionClause = "SELECT PARTID, DESCR, FAMILY, PROCPLANID, RowPointer";
                FromClause = stringUtil.Concat(" FROM ", stringUtil.QuoteName(Table));
                WhereClause = "WHERE 1 = 1";
                AdditionalClause = " ORDER BY PARTID";

                this.iCLM_ApsGetPARTCRUD.DeclareDynamicParameterTable();
                this.iCLM_ApsGetPARTCRUD.DynamicparametersInsert(SelectionClause, FromClause, WhereClause, AdditionalClause, Filter);

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
