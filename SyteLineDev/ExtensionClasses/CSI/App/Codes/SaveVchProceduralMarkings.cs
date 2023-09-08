//PROJECT NAME: Codes
//CLASS NAME: SaveVchProceduralMarkings.cs

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
using CSI.CRUD.Codes;

namespace CSI.Codes
{
    public class SaveVchProceduralMarkings : ISaveVchProceduralMarkings
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ICSIRemoteMethodCall cSIRemoteMethodCall;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ISaveVchProceduralMarkingsCRUD iSaveVchProceduralMarkingsCRUD;

        public SaveVchProceduralMarkings(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ICSIRemoteMethodCall cSIRemoteMethodCall,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            ISaveVchProceduralMarkingsCRUD iSaveVchProceduralMarkingsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.cSIRemoteMethodCall = cSIRemoteMethodCall;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iSaveVchProceduralMarkingsCRUD = iSaveVchProceduralMarkingsCRUD;
        }

        public (
            int? ReturnCode,
            string Infobar)
        SaveVchProceduralMarkingsSp(
            string SiteRef,
            int? VchNum,
            int? VchSeq,
            int? Selected,
            string VATProceduralMarkingId,
            string Infobar)
        {

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            if (this.iSaveVchProceduralMarkingsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iSaveVchProceduralMarkingsCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iSaveVchProceduralMarkingsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iSaveVchProceduralMarkingsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iSaveVchProceduralMarkingsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iSaveVchProceduralMarkingsCRUD.AltExtGen_SaveVchProceduralMarkingsSp(ALTGEN_SpName,
                        SiteRef,
                        VchNum,
                        VchSeq,
                        Selected,
                        VATProceduralMarkingId,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iSaveVchProceduralMarkingsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iSaveVchProceduralMarkingsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SaveVchProceduralMarkingsSp") != null)
            {
                var EXTGEN = this.iSaveVchProceduralMarkingsCRUD.AltExtGen_SaveVchProceduralMarkingsSp("dbo.EXTGEN_SaveVchProceduralMarkingsSp",
                    SiteRef,
                    VchNum,
                    VchSeq,
                    Selected,
                    VATProceduralMarkingId,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Infobar);
                }
            }

            var execResult = cSIRemoteMethodCall.RemoteMethodCallSp(
              Site: SiteRef
            , IdoName: null
            , MethodName: "VchProceduralMarkingsUpdSp"
            , StoredProcName: null
            , Infobar: Infobar
            , RefRowPointer: null
            , VchNum
            , VchSeq
            , Selected
            , VATProceduralMarkingId
            , Infobar);
            Severity = execResult.ReturnCode ?? 0;
            return (Severity, Infobar);

        }

    }
}
