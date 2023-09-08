//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipUnit.cs

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
    public class CLM_ESBShipUnit : ICLM_ESBShipUnit
    {
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_ESBShipUnitCRUD iCLM_ESBShipUnitCRUD;

        public CLM_ESBShipUnit(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            ICLM_ESBShipUnitCRUD iCLM_ESBShipUnitCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iCLM_ESBShipUnitCRUD = iCLM_ESBShipUnitCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_ESBShipUnitSp(
            int? ShipmentID,
            string ShipmentStatus=null)
        {

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iCLM_ESBShipUnitCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_ESBShipUnitCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_ESBShipUnitCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iCLM_ESBShipUnitCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_ESBShipUnitCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_ESBShipUnitCRUD.AltExtGen_CLM_ESBShipUnitSp(ALTGEN_SpName,
                        ShipmentID, ShipmentStatus);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_ESBShipUnitCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_ESBShipUnitCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ESBShipUnitSp") != null)
            {
                var EXTGEN = this.iCLM_ESBShipUnitCRUD.AltExtGen_CLM_ESBShipUnitSp("dbo.EXTGEN_CLM_ESBShipUnitSp",
                    ShipmentID, ShipmentStatus);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

           if(ShipmentStatus != "Canceled") { 
            var ESBShipUnitViewLoadResponse = this.iCLM_ESBShipUnitCRUD.EsbshipunitviewSelect(ShipmentID);
            Data = ESBShipUnitViewLoadResponse;
            }

            return (Data, Severity);
        }

    }
}
