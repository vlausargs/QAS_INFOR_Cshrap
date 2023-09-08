//PROJECT NAME: Logistics
//CLASS NAME: CLM_ListLeadsmobi.cs

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

namespace CSI.Logistics.Customer
{
	public class CLM_ListLeadsmobi : ICLM_ListLeadsmobi
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_ListLeadsmobiCRUD iCLM_ListLeadsmobiCRUD;
		
		public CLM_ListLeadsmobi(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_ListLeadsmobiCRUD iCLM_ListLeadsmobiCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_ListLeadsmobiCRUD = iCLM_ListLeadsmobiCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_ListLeadsmobiSp (
			string SlsmanFilter = null)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_ListLeadsmobiCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_ListLeadsmobiCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_ListLeadsmobiCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_ListLeadsmobiCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_ListLeadsmobiCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_ListLeadsmobiCRUD.AltExtGen_CLM_ListLeadsmobiSp (ALTGEN_SpName,
						SlsmanFilter);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_ListLeadsmobiCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_ListLeadsmobiCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_ListLeadsmobiSp") != null)
			{
				var EXTGEN = this.iCLM_ListLeadsmobiCRUD.AltExtGen_CLM_ListLeadsmobiSp("dbo.EXTGEN_CLM_ListLeadsmobiSp",
					SlsmanFilter);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (SlsmanFilter== null || sQLUtil.SQLEqual(SlsmanFilter, "") == true)
			{
				SlsmanFilter = "%";
				
			}
			var slsViewLoadResponse = this.iCLM_ListLeadsmobiCRUD.SlsviewSelect(SlsmanFilter);
			Data = slsViewLoadResponse;
			return (Data, Severity);
			
		}
		
	}
}
