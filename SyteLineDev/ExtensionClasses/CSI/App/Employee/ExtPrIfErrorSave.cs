//PROJECT NAME: Employee
//CLASS NAME: ExtPrIfErrorSave.cs

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

namespace CSI.Employee
{
	public class ExtPrIfErrorSave : IExtPrIfErrorSave
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IExtPrIfErrorSaveCRUD iExtPrIfErrorSaveCRUD;
		
		public ExtPrIfErrorSave(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IExtPrIfErrorSaveCRUD iExtPrIfErrorSaveCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iExtPrIfErrorSaveCRUD = iExtPrIfErrorSaveCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		ExtPrIfErrorSaveSp (
			DateTime? ErrDate,
			string ErrMsg,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iExtPrIfErrorSaveCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iExtPrIfErrorSaveCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iExtPrIfErrorSaveCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iExtPrIfErrorSaveCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iExtPrIfErrorSaveCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iExtPrIfErrorSaveCRUD.AltExtGen_ExtPrIfErrorSaveSp (ALTGEN_SpName,
						ErrDate,
						ErrMsg,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iExtPrIfErrorSaveCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iExtPrIfErrorSaveCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_ExtPrIfErrorSaveSp") != null)
			{
				var EXTGEN = this.iExtPrIfErrorSaveCRUD.AltExtGen_ExtPrIfErrorSaveSp("dbo.EXTGEN_ExtPrIfErrorSaveSp",
					ErrDate,
					ErrMsg,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			var nonTableLoadResponse = this.iExtPrIfErrorSaveCRUD.NontableSelect(ErrDate, ErrMsg);
			this.iExtPrIfErrorSaveCRUD.NontableInsert(nonTableLoadResponse);
			return (Severity, Infobar);
			
		}
		
	}
}
