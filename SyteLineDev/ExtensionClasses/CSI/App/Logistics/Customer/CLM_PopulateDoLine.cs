//PROJECT NAME: Logistics
//CLASS NAME: CLM_PopulateDoLine.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CLM_PopulateDoLine : ICLM_PopulateDoLine
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_PopulateDoLineCRUD iCLM_PopulateDoLineCRUD;
		readonly IUnionUtil iUnionUtil;
		
		public CLM_PopulateDoLine(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_PopulateDoLineCRUD iCLM_PopulateDoLineCRUD,
			IUnionUtil iUnionUtil)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_PopulateDoLineCRUD = iCLM_PopulateDoLineCRUD;
			this.iUnionUtil = iUnionUtil;

		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_PopulateDoLineSp (
			string PDoNum)
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_PopulateDoLineCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_PopulateDoLineCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_PopulateDoLineCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_PopulateDoLineCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_PopulateDoLineCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_PopulateDoLineCRUD.AltExtGen_CLM_PopulateDoLineSp (ALTGEN_SpName,
						PDoNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_PopulateDoLineCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_PopulateDoLineCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_PopulateDoLineSp") != null)
			{
				var EXTGEN = this.iCLM_PopulateDoLineCRUD.AltExtGen_CLM_PopulateDoLineSp("dbo.EXTGEN_CLM_PopulateDoLineSp",
					PDoNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			var nonTableLoadResponse = this.iCLM_PopulateDoLineCRUD.NontableSelect();
			Data = nonTableLoadResponse;
			this.iUnionUtil.Add(nonTableLoadResponse);
			var do_lineLoadResponse = this.iCLM_PopulateDoLineCRUD.Do_LineSelect(PDoNum);
			Data = do_lineLoadResponse;

			this.iUnionUtil.Add(do_lineLoadResponse);
			var unionTableResult = this.iUnionUtil.Process();
			Data = unionTableResult;
			
			return (Data, Severity);
		}
	}
}
