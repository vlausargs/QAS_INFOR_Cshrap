//PROJECT NAME: Production
//CLASS NAME: ExpectedReceiptsAPSItemChg.cs

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
	public class ExpectedReceiptsAPSItemChg : IExpectedReceiptsAPSItemChg
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IExpectedReceiptsAPSItemChgCRUD iExpectedReceiptsAPSItemChgCRUD;
		
		public ExpectedReceiptsAPSItemChg(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IExpectedReceiptsAPSItemChgCRUD iExpectedReceiptsAPSItemChgCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iExpectedReceiptsAPSItemChgCRUD = iExpectedReceiptsAPSItemChgCRUD;
		}
		
		public (
			int? ReturnCode,
			string Description)
		ExpectedReceiptsAPSItemChgSp (
			string Item,
			string Description)
		{
			
			DescriptionType _Description = Description;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iExpectedReceiptsAPSItemChgCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iExpectedReceiptsAPSItemChgCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iExpectedReceiptsAPSItemChgCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iExpectedReceiptsAPSItemChgCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iExpectedReceiptsAPSItemChgCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iExpectedReceiptsAPSItemChgCRUD.AltExtGen_ExpectedReceiptsAPSItemChgSp (ALTGEN_SpName,
						Item,
						Description);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Description);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iExpectedReceiptsAPSItemChgCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iExpectedReceiptsAPSItemChgCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ExpectedReceiptsAPSItemChgSp") != null)
			{
				var EXTGEN = this.iExpectedReceiptsAPSItemChgCRUD.AltExtGen_ExpectedReceiptsAPSItemChgSp("dbo.EXTGEN_ExpectedReceiptsAPSItemChgSp",
					Item,
					Description);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Description);
				}
			}
			
			if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iExpectedReceiptsAPSItemChgCRUD.ItemForExists(Item))))
			{
				Description = null;
				return (Severity, Description);
			}
			(Description, rowCount) = this.iExpectedReceiptsAPSItemChgCRUD.Item1Load(Item, Description);
			return (Severity, Description);
			
		}
		
	}
}
