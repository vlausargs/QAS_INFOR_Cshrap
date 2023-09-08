//PROJECT NAME: Production
//CLASS NAME: PmfFmGetRevision.cs

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

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetRevision : IPmfFmGetRevision
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IPmfFmGetRevisionCRUD iPmfFmGetRevisionCRUD;
		
		public PmfFmGetRevision(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IPmfFmGetRevisionCRUD iPmfFmGetRevisionCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iPmfFmGetRevisionCRUD = iPmfFmGetRevisionCRUD;
		}
		
		public (
			int? ReturnCode,
			string InfoBar,
			int? NextRevNo)
		PmfFmGetRevisionSp (
			string InfoBar = null,
			string Fm = null,
			string FmVer = null,
			int? NextRevNo = null)
		{
			
			IntType _NextRevNo = NextRevNo;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iPmfFmGetRevisionCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iPmfFmGetRevisionCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PmfFmGetRevisionSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iPmfFmGetRevisionCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iPmfFmGetRevisionCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iPmfFmGetRevisionCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iPmfFmGetRevisionCRUD.AltExtGen_PmfFmGetRevisionSp (ALTGEN_SpName,
						InfoBar,
						Fm,
						FmVer,
						NextRevNo);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, InfoBar, NextRevNo);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iPmfFmGetRevisionCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iPmfFmGetRevisionCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PmfFmGetRevisionSp") != null)
			{
				var EXTGEN = this.iPmfFmGetRevisionCRUD.AltExtGen_PmfFmGetRevisionSp("dbo.EXTGEN_PmfFmGetRevisionSp",
					InfoBar,
					Fm,
					FmVer,
					NextRevNo);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.InfoBar, EXTGEN.NextRevNo);
				}
			}
			
			NextRevNo = 1;
			(NextRevNo, rowCount) = this.iPmfFmGetRevisionCRUD.Pmf_FormulaasfmLoad(Fm, FmVer, NextRevNo);
			NextRevNo = (int?)(stringUtil.Coalesce<int?>(NextRevNo,1));
			return (0 , InfoBar, NextRevNo);
			
		}
		
	}
}
