//PROJECT NAME: Finance
//CLASS NAME: CHSCLM_ListVouchers.cs

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

namespace CSI.Finance.Chinese
{
	public class CHSCLM_ListVouchers : ICHSCLM_ListVouchers
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICHSCLM_ListVouchersCRUD iCHSCLM_ListVouchersCRUD;
		
		public CHSCLM_ListVouchers(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICHSCLM_ListVouchersCRUD iCHSCLM_ListVouchersCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCHSCLM_ListVouchersCRUD = iCHSCLM_ListVouchersCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CHSCLM_ListVouchersSp (
			string FilterString = null)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCHSCLM_ListVouchersCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCHSCLM_ListVouchersCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCHSCLM_ListVouchersCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCHSCLM_ListVouchersCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCHSCLM_ListVouchersCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCHSCLM_ListVouchersCRUD.AltExtGen_CHSCLM_ListVouchersSp (ALTGEN_SpName,
						FilterString);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCHSCLM_ListVouchersCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCHSCLM_ListVouchersCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CHSCLM_ListVouchersSp") != null)
			{
				var EXTGEN = this.iCHSCLM_ListVouchersCRUD.AltExtGen_CHSCLM_ListVouchersSp("dbo.EXTGEN_CHSCLM_ListVouchersSp",
					FilterString);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (FilterString!= null && sQLUtil.SQLNotEqual(FilterString, "") == true)
			{
				var CN_Journal1LoadResponse = this.iCHSCLM_ListVouchersCRUD.CN_Journal1Select(FilterString);
				Data = CN_Journal1LoadResponse;
				
			}
			else
			{
				var CN_Journal3LoadResponse = this.iCHSCLM_ListVouchersCRUD.CN_Journal3Select();
				Data = CN_Journal3LoadResponse;
				
			}
			return (Data, Severity);
			
		}
		
	}
}
