//PROJECT NAME: Finance
//CLASS NAME: DeleteDimension.cs

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

namespace CSI.Finance
{
	public class DeleteDimension : IDeleteDimension
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IDeleteDimensionCRUD iDeleteDimensionCRUD;
		
		public DeleteDimension(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IDeleteDimensionCRUD iDeleteDimensionCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iDeleteDimensionCRUD = iDeleteDimensionCRUD;
		}
		
		public int? DeleteDimensionSp (
			string ObjectName,
			string Dimension)
		{
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iDeleteDimensionCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iDeleteDimensionCRUD.SelectOptional_ModuleForInsert();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iDeleteDimensionCRUD.InsertOptional_Module(optional_module1LoadResponse);
				while (this.iDeleteDimensionCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iDeleteDimensionCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
					var ALTGEN = this.iDeleteDimensionCRUD.AltExtGen_DeleteDimensionSp (ALTGEN_SpName,
						ObjectName,
						Dimension);
					ALTGEN_Severity = ALTGEN;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iDeleteDimensionCRUD.SelectTv_ALTGENForDelete(ALTGEN_SpName);
					this.iDeleteDimensionCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_DeleteDimensionSp") != null)
			{
				var EXTGEN = this.iDeleteDimensionCRUD.AltExtGen_DeleteDimensionSp("dbo.EXTGEN_DeleteDimensionSp",
					ObjectName,
					Dimension);
				int? EXTGEN_Severity = EXTGEN;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity);
				}
			}
			
			/*Needs to load at least one column from the table: dimension for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var dimensionLoadResponse = this.iDeleteDimensionCRUD.SelectDimensionForDelete(ObjectName, Dimension);
			this.iDeleteDimensionCRUD.DeleteDimension(dimensionLoadResponse);
			return (Severity);
			
		}
		
	}
}
