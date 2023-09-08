//PROJECT NAME: Production
//CLASS NAME: CLM_ResGanttDemands.cs

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

namespace CSI.Production.APS
{
	public class CLM_ResGanttDemands : ICLM_ResGanttDemands
	{

		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ISQLCollectionLoad sQLCollectionLoad;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ResGanttDemandsCRUD iCLM_ResGanttDemandsCRUD;

		public CLM_ResGanttDemands(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ISQLCollectionLoad sQLCollectionLoad,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ResGanttDemandsCRUD iCLM_ResGanttDemandsCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.sQLCollectionLoad = sQLCollectionLoad;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ResGanttDemandsCRUD = iCLM_ResGanttDemandsCRUD;
		}

		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ResGanttDemandsSp(
			int? AltNum = 0,
			int? PlannerFg = 1)
		{

			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			string SQLStr = null;
			int? Severity = null;
			string ORDPLAN = null;
			string ORDIND = null;
			if (this.iCLM_ResGanttDemandsCRUD.CheckOptional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ResGanttDemandsCRUD.SelectOptional_Module();
				var optional_module1RequiredColumns = new List<string>() { "SpName" };

				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

				this.iCLM_ResGanttDemandsCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iCLM_ResGanttDemandsCRUD.CheckTv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ResGanttDemandsCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ResGanttDemandsCRUD.AltExtGen_CLM_ResGanttDemandsSp(ALTGEN_SpName,
						AltNum,
						PlannerFg);
					ALTGEN_Severity = ALTGEN.ReturnCode;

					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);

					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ResGanttDemandsCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
					this.iCLM_ResGanttDemandsCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

				}

			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ResGanttDemandsSp") != null)
			{
				var EXTGEN = this.iCLM_ResGanttDemandsCRUD.AltExtGen_CLM_ResGanttDemandsSp("dbo.EXTGEN_CLM_ResGanttDemandsSp",
					AltNum,
					PlannerFg);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;

				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}

			AltNum = (int?)(stringUtil.IsNull(
				AltNum,
				0));
			ORDPLAN = stringUtil.Concat("ORDPLAN", stringUtil.Substring(
				"000",
				1,
				3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
			ORDIND = stringUtil.Concat("ORDIND", stringUtil.Substring(
				"000",
				1,
				3 - stringUtil.Len(AltNum)), Convert.ToString(AltNum));
			if (sQLUtil.SQLEqual(PlannerFg, 1) == true)
			{
				SQLStr = stringUtil.Concat("SELECT dbo.ApsGetDemandID(ORDERID) AS DerDemandId FROM ", stringUtil.QuoteName(ORDPLAN), " ORDER BY 1");

			}
			else
			{
				SQLStr = stringUtil.Concat("SELECT dbo.ApsGetDemandID(ORDERID) AS DerDemandId FROM ", stringUtil.QuoteName(ORDIND), " ORDER BY 1");

			}

			var execResult = sQLCollectionLoad.ExecuteDynamicQuery(SQLStr, "");
			Severity = execResult.Severity;
			/* ExecuteStatement - Hint: If this dynamic SQL is supposed to load data, use the execResult.Data return. */
			Data = execResult.Data;

			return (Data, Severity);
		}

	}
}
