//PROJECT NAME: Production
//CLASS NAME: RSQC_Parmcu.cs

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
	public class RSQC_Parmcu : IRSQC_Parmcu
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IIsAddonAvailable iIsAddonAvailable;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRSQC_ParmcuCRUD iRSQC_ParmcuCRUD;
		
		public RSQC_Parmcu(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IIsAddonAvailable iIsAddonAvailable,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IRSQC_ParmcuCRUD iRSQC_ParmcuCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iIsAddonAvailable = iIsAddonAvailable;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iRSQC_ParmcuCRUD = iRSQC_ParmcuCRUD;
		}
		
		public (
			int? ReturnCode,
			string o_prompt_item_order,
			string Infobar)
		RSQC_ParmcuSp (
			string o_prompt_item_order,
			string Infobar)
		{
			
			QCCharType _o_prompt_item_order = o_prompt_item_order;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iRSQC_ParmcuCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRSQC_ParmcuCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRSQC_ParmcuCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iRSQC_ParmcuCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRSQC_ParmcuCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRSQC_ParmcuCRUD.AltExtGen_RSQC_ParmcuSp (ALTGEN_SpName,
						o_prompt_item_order,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, o_prompt_item_order, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRSQC_ParmcuCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRSQC_ParmcuCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_RSQC_ParmcuSp") != null)
			{
				var EXTGEN = this.iRSQC_ParmcuCRUD.AltExtGen_RSQC_ParmcuSp("dbo.EXTGEN_RSQC_ParmcuSp",
					o_prompt_item_order,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.o_prompt_item_order, EXTGEN.Infobar);
				}
			}
			
			if (sQLUtil.SQLNotEqual(this.iIsAddonAvailable.IsAddonAvailableFn("QualityControlSolution"), 1) == true)
			{
				return (Severity = 0 , o_prompt_item_order, Infobar);
				
			}
			Severity = 0;
			(o_prompt_item_order, rowCount) = this.iRSQC_ParmcuCRUD.RS_QcparmcuLoad(o_prompt_item_order);
			return (Severity, o_prompt_item_order, Infobar);
			
		}
		
	}
}
