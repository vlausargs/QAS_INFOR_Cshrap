//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmInit.cs

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

namespace CSI.Logistics.FieldService
{
    public class SSSFSAcmInit : ISSSFSAcmInit
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ISSSFSAcmInitCRUD iSSSFSAcmInitCRUD;

        public SSSFSAcmInit(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ISSSFSAcmInitCRUD iSSSFSAcmInitCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iSSSFSAcmInitCRUD = iSSSFSAcmInitCRUD;
        }

        public (
            int? ReturnCode,
            string Id,
            int? TotalPeriods,
            string Infobar)
        SSSFSAcmInitSp(
            string Id,
            int? TotalPeriods,
            string Infobar)
        {

            JournalIdType _Id = Id;
            GenericIntType _TotalPeriods = TotalPeriods;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            if (this.iSSSFSAcmInitCRUD.Optional_ModuleForExists())
            {
                //BEGIN
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iSSSFSAcmInitCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("SSSFSAcmInitSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iSSSFSAcmInitCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iSSSFSAcmInitCRUD.Tv_ALTGENForExists())
                {
                    //BEGIN
                    var tv_ALTGEN1Load = this.iSSSFSAcmInitCRUD.Tv_ALTGEN1Load();
                    ALTGEN_SpName = tv_ALTGEN1Load;
                    var ALTGEN = this.iSSSFSAcmInitCRUD.AltExtGen_SSSFSAcmInitSp(ALTGEN_SpName,
                        Id,
                        TotalPeriods,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        Id = _Id;
                        TotalPeriods = _TotalPeriods;
                        return (ALTGEN_Severity, Id, TotalPeriods, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iSSSFSAcmInitCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iSSSFSAcmInitCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                    //END

                }
                //END

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSFSAcmInitSp") != null)
            {
                var EXTGEN = this.iSSSFSAcmInitCRUD.AltExtGen_SSSFSAcmInitSp("dbo.EXTGEN_SSSFSAcmInitSp",
                    Id,
                    TotalPeriods,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Id, EXTGEN.TotalPeriods, EXTGEN.Infobar);
                }
            }

            Infobar = null;
            Severity = 0;
            var fs_parmsLoad = this.iSSSFSAcmInitCRUD.Fs_ParmsLoad();
            Id = fs_parmsLoad.Id;
            TotalPeriods = fs_parmsLoad.TotalPeriods;
            return (Severity, Id, TotalPeriods, Infobar);

        }

    }
}
