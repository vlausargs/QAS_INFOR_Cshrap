//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInvoiceTaxRep.cs

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

namespace CSI.BusInterface
{
    public class CLM_ESBInvoiceTaxRep : ICLM_ESBInvoiceTaxRep
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ESBInvoiceTaxRepCRUD iCLM_ESBInvoiceTaxRepCRUD;

        public CLM_ESBInvoiceTaxRep(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ESBInvoiceTaxRepCRUD iCLM_ESBInvoiceTaxRepCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iCLM_ESBInvoiceTaxRepCRUD = iCLM_ESBInvoiceTaxRepCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ESBInvoiceTaxRepSp(
            string InvNum,
            int? InvSeq)
        {

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iCLM_ESBInvoiceTaxRepCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_ESBInvoiceTaxRepCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_ESBInvoiceTaxRepCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iCLM_ESBInvoiceTaxRepCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_ESBInvoiceTaxRepCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_ESBInvoiceTaxRepCRUD.AltExtGen_CLM_ESBInvoiceTaxRepSp(ALTGEN_SpName,
                        InvNum,
                        InvSeq);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_ESBInvoiceTaxRepCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_ESBInvoiceTaxRepCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ESBInvoiceTaxRepSp") != null)
            {
                var EXTGEN = this.iCLM_ESBInvoiceTaxRepCRUD.AltExtGen_CLM_ESBInvoiceTaxRepSp("dbo.EXTGEN_CLM_ESBInvoiceTaxRepSp",
                    InvNum,
                    InvSeq);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            var ESBInvoiceTaxRepViewLoadResponse = this.iCLM_ESBInvoiceTaxRepCRUD.EsbinvoicetaxrepviewSelect(InvNum, InvSeq);
            Data = ESBInvoiceTaxRepViewLoadResponse;

            return (Data, Severity);
        }

    }
}
