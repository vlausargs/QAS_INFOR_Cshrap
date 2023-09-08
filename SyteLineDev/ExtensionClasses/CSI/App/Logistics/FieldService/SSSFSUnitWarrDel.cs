//PROJECT NAME: Logistics
//CLASS NAME: SSSFSUnitWarrDel.cs

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

namespace CSI.Logistics.FieldService
{
	public class SSSFSUnitWarrDel : ISSSFSUnitWarrDel
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ISSSFSUnitWarrDelCRUD iSSSFSUnitWarrDelCRUD;
		
		public SSSFSUnitWarrDel(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ISSSFSUnitWarrDelCRUD iSSSFSUnitWarrDelCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iSSSFSUnitWarrDelCRUD = iSSSFSUnitWarrDelCRUD;
		}
		
		public int? SSSFSUnitWarrDelSp (
			int? CompId,
			string WarrCode)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity;
			int? rowCount;
			int? Severity;
			if (this.iSSSFSUnitWarrDelCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iSSSFSUnitWarrDelCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iSSSFSUnitWarrDelCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iSSSFSUnitWarrDelCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iSSSFSUnitWarrDelCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iSSSFSUnitWarrDelCRUD.AltExtGen_SSSFSUnitWarrDelSp (ALTGEN_SpName,
						CompId,
						WarrCode);
					ALTGEN_Severity = ALTGEN;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iSSSFSUnitWarrDelCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iSSSFSUnitWarrDelCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_SSSFSUnitWarrDelSp") != null)
			{
				var EXTGEN = this.iSSSFSUnitWarrDelCRUD.AltExtGen_SSSFSUnitWarrDelSp("dbo.EXTGEN_SSSFSUnitWarrDelSp",
					CompId,
					WarrCode);
				int? EXTGEN_Severity = EXTGEN;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			/*Needs to load at least one column from the table: fs_unit_warr for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var fs_unit_warrLoadResponse = this.iSSSFSUnitWarrDelCRUD.Fs_Unit_WarrSelect(CompId, WarrCode);
			this.iSSSFSUnitWarrDelCRUD.Fs_Unit_WarrDelete(fs_unit_warrLoadResponse);
			
			return (Severity);
		}
		
	}
}
