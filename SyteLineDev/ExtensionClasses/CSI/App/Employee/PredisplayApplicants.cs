//PROJECT NAME: Employee
//CLASS NAME: PredisplayApplicants.cs

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
using System.Linq;

namespace CSI.Employee
{
    public class PredisplayApplicants : IPredisplayApplicants
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IPredisplayApplicantsCRUD iPredisplayApplicantsCRUD;

        public PredisplayApplicants(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            IPredisplayApplicantsCRUD iPredisplayApplicantsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iPredisplayApplicantsCRUD = iPredisplayApplicantsCRUD;
        }

        public (
            int? ReturnCode,
            int? PCheckSsnEnabled)
        PredisplayApplicantsSp(
            int? PCheckSsnEnabled)
        {

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iPredisplayApplicantsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iPredisplayApplicantsCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iPredisplayApplicantsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iPredisplayApplicantsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iPredisplayApplicantsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iPredisplayApplicantsCRUD.AltExtGen_PredisplayApplicantsSp(ALTGEN_SpName,
                        PCheckSsnEnabled);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, PCheckSsnEnabled);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iPredisplayApplicantsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iPredisplayApplicantsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PredisplayApplicantsSp") != null)
            {
                var EXTGEN = this.iPredisplayApplicantsCRUD.AltExtGen_PredisplayApplicantsSp("dbo.EXTGEN_PredisplayApplicantsSp",
                    PCheckSsnEnabled);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.PCheckSsnEnabled);
                }
            }

            var hrparmsLoadResponseForScalarSubQuery = this.iPredisplayApplicantsCRUD.HrparmsSelect();
            PCheckSsnEnabled = (int?)((sQLUtil.SQLEqual(((hrparmsLoadResponseForScalarSubQuery.Items != null &&
            hrparmsLoadResponseForScalarSubQuery.Items.Count != 0) ?
            (hrparmsLoadResponseForScalarSubQuery.Items.FirstOrDefault().GetValue<int?>("mask_ssn")) : null), 1) == true ? 0 : 1));
            return (Severity, PCheckSsnEnabled);

        }

    }
}
