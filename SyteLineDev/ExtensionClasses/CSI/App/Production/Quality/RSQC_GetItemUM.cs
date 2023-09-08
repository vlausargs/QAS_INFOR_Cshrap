//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemUM.cs

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
	public class RSQC_GetItemUM : IRSQC_GetItemUM
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_GetItemUMCRUD iRSQC_GetItemUMCRUD;
		
		public RSQC_GetItemUM(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_GetItemUMCRUD iRSQC_GetItemUMCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRSQC_GetItemUMCRUD = iRSQC_GetItemUMCRUD;
		}
		
		public (
			int? ReturnCode,
			string NewUM)
		RSQC_GetItemUMSp (
			int? RcvrNum,
			string NewUM)
		{
			
			UMType _NewUM = NewUM;
			
			int? Severity=0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount;
			string RefNum = null;
			int? RefLine = null;
			int? RefRelease = null;
			string RefType = null;
			if (this.iRSQC_GetItemUMCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_GetItemUMCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRSQC_GetItemUMCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRSQC_GetItemUMCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, _) = this.iRSQC_GetItemUMCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_GetItemUMCRUD.AltExtGen_RSQC_GetItemUMSp (ALTGEN_SpName,
						RcvrNum,
						NewUM);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, NewUM);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_GetItemUMCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRSQC_GetItemUMCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_GetItemUMSp") != null)
			{
				var EXTGEN = this.iRSQC_GetItemUMCRUD.AltExtGen_RSQC_GetItemUMSp("dbo.EXTGEN_RSQC_GetItemUMSp",
					RcvrNum,
					NewUM);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.NewUM);
				}
			}
			
			(RefNum, RefLine, RefRelease, RefType, rowCount) = this.iRSQC_GetItemUMCRUD.Rs_QcrcvrLoad(RcvrNum, RefNum, RefLine, RefRelease, RefType);
			NewUM = null;
			if (sQLUtil.SQLEqual(RefType, "R") == true)
			{
				(NewUM, rowCount) = this.iRSQC_GetItemUMCRUD.RmaitemLoad(RefNum, RefLine, NewUM);
				
			}
			else
			{
				if (sQLUtil.SQLEqual(RefType, "O") == true)
				{
					(NewUM, rowCount) = this.iRSQC_GetItemUMCRUD.CoitemLoad(RefNum, RefLine, NewUM);
					
				}
				
			}
			return (Severity, NewUM);

		}
		
	}
}
