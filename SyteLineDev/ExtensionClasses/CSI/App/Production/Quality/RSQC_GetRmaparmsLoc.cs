//PROJECT NAME: Production
//CLASS NAME: RSQC_GetRmaparmsLoc.cs

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

namespace CSI.Production.Quality
{
	public class RSQC_GetRmaparmsLoc : IRSQC_GetRmaparmsLoc
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_GetRmaparmsLocCRUD iRSQC_GetRmaparmsLocCRUD;
		
		public RSQC_GetRmaparmsLoc(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_GetRmaparmsLocCRUD iRSQC_GetRmaparmsLocCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRSQC_GetRmaparmsLocCRUD = iRSQC_GetRmaparmsLocCRUD;
		}
		
		public (
			int? ReturnCode,
			string Loc,
			int? NeedsQC)
		RSQC_GetRmaparmsLocSp (
			string Loc,
			int? NeedsQC)
		{
			
			LocType _Loc = Loc;
			ListYesNoType _NeedsQC = NeedsQC;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iRSQC_GetRmaparmsLocCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_GetRmaparmsLocCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRSQC_GetRmaparmsLocCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRSQC_GetRmaparmsLocCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRSQC_GetRmaparmsLocCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_GetRmaparmsLocCRUD.AltExtGen_RSQC_GetRmaparmsLocSp (ALTGEN_SpName,
						Loc,
						NeedsQC);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Loc, NeedsQC);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_GetRmaparmsLocCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRSQC_GetRmaparmsLocCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetRmaparmsLocSp") != null)
			{
				var EXTGEN = this.iRSQC_GetRmaparmsLocCRUD.AltExtGen_RSQC_GetRmaparmsLocSp("dbo.EXTGEN_RSQC_GetRmaparmsLocSp",
					Loc,
					NeedsQC);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Loc, EXTGEN.NeedsQC);
				}
			}
			
			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
			{
				return (Severity = 0 , Loc, NeedsQC);
				
			}
			(Loc, NeedsQC, rowCount) = this.iRSQC_GetRmaparmsLocCRUD.Rs_QcparmcuLoad(Loc, NeedsQC);
			
			return (Severity, Loc, NeedsQC);
		}
		
	}
}
