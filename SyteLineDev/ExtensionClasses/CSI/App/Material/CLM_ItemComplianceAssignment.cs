//PROJECT NAME: Material
//CLASS NAME: CLM_ItemComplianceAssignment.cs

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

namespace CSI.Material
{
    public class CLM_ItemComplianceAssignment : ICLM_ItemComplianceAssignment
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISetItemComplianceStatus iSetItemComplianceStatus;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IDefineVariable iDefineVariable;
        readonly IScalarFunction scalarFunction;
        readonly IRaiseError raiseError;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ItemComplianceAssignmentCRUD iCLM_ItemComplianceAssignmentCRUD;

        public CLM_ItemComplianceAssignment(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISetItemComplianceStatus iSetItemComplianceStatus,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IDefineVariable iDefineVariable,
            IScalarFunction scalarFunction,
            IRaiseError raiseError,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ItemComplianceAssignmentCRUD iCLM_ItemComplianceAssignmentCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.iSetItemComplianceStatus = iSetItemComplianceStatus;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iDefineVariable = iDefineVariable;
            this.scalarFunction = scalarFunction;
            this.raiseError = raiseError;
            this.sQLUtil = sQLUtil;
            this.iCLM_ItemComplianceAssignmentCRUD = iCLM_ItemComplianceAssignmentCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ItemComplianceAssignmentSp(
            int? ProcessAll = 0,
            string ComplianceProgramId = null,
            string Mode = "N",
            DateTime? EffectDate = null)
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            string Infobar = null;
            if (this.iCLM_ItemComplianceAssignmentCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_ItemComplianceAssignmentCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_ItemComplianceAssignmentCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iCLM_ItemComplianceAssignmentCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_ItemComplianceAssignmentCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_ItemComplianceAssignmentCRUD.AltExtGen_CLM_ItemComplianceAssignmentSp(ALTGEN_SpName,
                        ProcessAll,
                        ComplianceProgramId,
                        Mode,
                        EffectDate);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_ItemComplianceAssignmentCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_ItemComplianceAssignmentCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ItemComplianceAssignmentSp") != null)
            {
                var EXTGEN = this.iCLM_ItemComplianceAssignmentCRUD.AltExtGen_CLM_ItemComplianceAssignmentSp("dbo.EXTGEN_CLM_ItemComplianceAssignmentSp",
                    ProcessAll,
                    ComplianceProgramId,
                    Mode,
                    EffectDate);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            Severity = 0;
            if (this.scalarFunction.Execute<int?>(
                "OBJECT_ID",
                "tempdb..#TempItemCompliance") != null)
            {
                this.sQLExpressionExecutor.Execute("DROP TABLE #TempItemCompliance");

            }

            this.sQLExpressionExecutor.Execute(@"Declare
				@Item ItemType
				,@ItemDescription DescriptionType
				,@ComplianceProgId ComplianceProgramIDType
				SELECT @Item AS item,
				       @ItemDescription AS item_description,
				       @ComplianceProgId AS compliance_program_id
				INTO   #TempItemCompliance
				WHERE  1 = 2");

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: SetItemComplianceStatusSp
            var SetItemComplianceStatus = this.iSetItemComplianceStatus.SetItemComplianceStatusSp(
                ProcessAll: ProcessAll,
                ComplianceProgramId: ComplianceProgramId,
                Mode: Mode,
                Infobar: Infobar,
                EffectDate: EffectDate);
            Severity = SetItemComplianceStatus.ReturnCode;
            Infobar = SetItemComplianceStatus.Infobar;

            #endregion ExecuteMethodCall

            var TempItemCompliance1LoadResponse = this.iCLM_ItemComplianceAssignmentCRUD.Tempitemcompliance1Select(Severity, ProcessAll, ComplianceProgramId, Mode, Infobar, EffectDate);
            Data = TempItemCompliance1LoadResponse;

            if (this.scalarFunction.Execute<int?>(
                "OBJECT_ID",
                "tempdb..#TempItemCompliance") != null)
            {
                this.sQLExpressionExecutor.Execute("DROP TABLE #TempItemCompliance");

            }

            #region CRUD ExecuteMethodCall

            //Please Generate the bounce for this stored procedure: DefineVariableSp
            var DefineVariable = this.iDefineVariable.DefineVariableSp(
                VariableName: "Infobar",
                VariableValue: Infobar,
                Infobar: Infobar);
            Infobar = DefineVariable.Infobar;

            #endregion ExecuteMethodCall

            if (sQLUtil.SQLNotEqual(Severity, 0) == true)
            {
                raiseError.RaiseErrorSp(
                    Infobar,
                    Severity,
                    1);
                return (Data, Severity);
            }
            return (Data, Severity);

        }

    }
}
