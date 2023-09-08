//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUser.cs

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
    public class RSQC_GetUser : IRSQC_GetUser
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IRSQC_GetUserCRUD iRSQC_GetUserCRUD;

        public RSQC_GetUser(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IIsAddonAvailable iIsAddonAvailable,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IRSQC_GetUserCRUD iRSQC_GetUserCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iRSQC_GetUserCRUD = iRSQC_GetUserCRUD;
        }

        public (
            int? ReturnCode,
            string o_user,
            string Infobar)
        RSQC_GetUserSp(
            string o_user,
            string Infobar)
        {

            StringType _o_user = o_user;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            if (this.iRSQC_GetUserCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iRSQC_GetUserCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("RSQC_GetUserSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iRSQC_GetUserCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iRSQC_GetUserCRUD.Tv_ALTGENForExists())
                {
                    var tv_ALTGEN1Load = this.iRSQC_GetUserCRUD.Tv_ALTGEN1Load();
                    ALTGEN_SpName = tv_ALTGEN1Load;
                    var ALTGEN = this.iRSQC_GetUserCRUD.AltExtGen_RSQC_GetUserSp(ALTGEN_SpName,
                        o_user,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        o_user = _o_user;
                        return (ALTGEN_Severity, o_user, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iRSQC_GetUserCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iRSQC_GetUserCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetUserSp") != null)
            {
                var EXTGEN = this.iRSQC_GetUserCRUD.AltExtGen_RSQC_GetUserSp("dbo.EXTGEN_RSQC_GetUserSp",
                    o_user,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.o_user, EXTGEN.Infobar);
                }
            }

            if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
            {
                return (Severity = 0, o_user, Infobar);

            }

            var user_localLoad = this.iRSQC_GetUserCRUD.User_LocalLoad();
            o_user = user_localLoad;

            return (Severity, o_user, Infobar);

        }

    }
}