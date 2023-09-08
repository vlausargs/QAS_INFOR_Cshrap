//PROJECT NAME: Logistics
//CLASS NAME: SSSFSExpenseReconSave.cs

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

namespace CSI.Logistics.FieldService.Requests
{
    public class SSSFSExpenseReconSave : ISSSFSExpenseReconSave
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ISSSFSExpenseReconSaveCRUD iSSSFSExpenseReconSaveCRUD;

        public SSSFSExpenseReconSave(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            ISSSFSExpenseReconSaveCRUD iSSSFSExpenseReconSaveCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iSSSFSExpenseReconSaveCRUD = iSSSFSExpenseReconSaveCRUD;
        }

        public int? SSSFSExpenseReconSaveSp(
            Guid? RowPointer,
            int? Selected)
        {

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            if (this.iSSSFSExpenseReconSaveCRUD.CheckOptional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iSSSFSExpenseReconSaveCRUD.SelectOptional_Module();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iSSSFSExpenseReconSaveCRUD.InsertOptional_Module(optional_module1LoadResponse);
                while (this.iSSSFSExpenseReconSaveCRUD.CheckTv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iSSSFSExpenseReconSaveCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
                    var ALTGEN = this.iSSSFSExpenseReconSaveCRUD.AltExtGen_SSSFSExpenseReconSaveSp(ALTGEN_SpName,
                        RowPointer,
                        Selected);
                    ALTGEN_Severity = ALTGEN;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iSSSFSExpenseReconSaveCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
                    this.iSSSFSExpenseReconSaveCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSFSExpenseReconSaveSp") != null)
            {
                var EXTGEN = this.iSSSFSExpenseReconSaveCRUD.AltExtGen_SSSFSExpenseReconSaveSp("dbo.EXTGEN_SSSFSExpenseReconSaveSp",
                    RowPointer,
                    Selected);
                int? EXTGEN_Severity = EXTGEN;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity);
                }
            }

            Severity = 0;
            if (sQLUtil.SQLEqual(Selected, 1) == true)
            {
                var nonTable1LoadResponse = this.iSSSFSExpenseReconSaveCRUD.SelectFs_Tmp_Recon(RowPointer);
                this.iSSSFSExpenseReconSaveCRUD.InsertFs_Tmp_Recon(nonTable1LoadResponse);

            }
            else
            {
                /*Needs to load at least one column from the table: fs_tmp_recon for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                var fs_tmp_reconLoadResponse = this.iSSSFSExpenseReconSaveCRUD.SelectFs_Tmp_ReconForDelete(RowPointer);
                this.iSSSFSExpenseReconSaveCRUD.DeleteFs_Tmp_Recon(fs_tmp_reconLoadResponse);

            }
            return (Severity);

        }

    }
}
