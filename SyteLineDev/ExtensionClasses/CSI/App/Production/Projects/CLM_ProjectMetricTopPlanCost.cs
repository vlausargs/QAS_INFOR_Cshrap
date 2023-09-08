//PROJECT NAME: Production
//CLASS NAME: CLM_ProjectMetricTopPlanCost.cs

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

namespace CSI.Production.Projects
{
	public class CLM_ProjectMetricTopPlanCost : ICLM_ProjectMetricTopPlanCost
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ProjectMetricTopPlanCostCRUD iCLM_ProjectMetricTopPlanCostCRUD;
		
		public CLM_ProjectMetricTopPlanCost(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ProjectMetricTopPlanCostCRUD iCLM_ProjectMetricTopPlanCostCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_ProjectMetricTopPlanCostCRUD = iCLM_ProjectMetricTopPlanCostCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ProjectMetricTopPlanCostSp (
			int? Count = 5)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_ProjectMetricTopPlanCostCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ProjectMetricTopPlanCostCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_ProjectMetricTopPlanCostSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_ProjectMetricTopPlanCostCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iCLM_ProjectMetricTopPlanCostCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ProjectMetricTopPlanCostCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ProjectMetricTopPlanCostCRUD.AltExtGen_CLM_ProjectMetricTopPlanCostSp (ALTGEN_SpName,
						Count);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ProjectMetricTopPlanCostCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_ProjectMetricTopPlanCostCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ProjectMetricTopPlanCostSp") != null)
			{
				var EXTGEN = this.iCLM_ProjectMetricTopPlanCostCRUD.AltExtGen_CLM_ProjectMetricTopPlanCostSp("dbo.EXTGEN_CLM_ProjectMetricTopPlanCostSp",
					Count);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			Severity = 0;
			if (sQLUtil.SQLGreaterThan(Count, 0) == true && sQLUtil.SQLLessThan(Count, 5) == true)
			{
				var projLoadResponse = this.iCLM_ProjectMetricTopPlanCostCRUD.ProjSelect(Count);
				Data = projLoadResponse;
				
			}
			else
			{
				var proj1LoadResponse = this.iCLM_ProjectMetricTopPlanCostCRUD.Proj1Select();
				Data = proj1LoadResponse;
				
			}
			return (Data, Severity);
			
		}
		
	}
}
