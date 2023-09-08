//PROJECT NAME: Finance
//CLASS NAME: CHSCLM_VoucherTypeCodeList.cs

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
	public class CHSCLM_VoucherTypeCodeList : ICHSCLM_VoucherTypeCodeList
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICHSCLM_VoucherTypeCodeListCRUD iCHSCLM_VoucherTypeCodeListCRUD;
		
		public CHSCLM_VoucherTypeCodeList(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICHSCLM_VoucherTypeCodeListCRUD iCHSCLM_VoucherTypeCodeListCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCHSCLM_VoucherTypeCodeListCRUD = iCHSCLM_VoucherTypeCodeListCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CHSCLM_VoucherTypeCodeListSp (
			string TypeCodeFilter = null)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCHSCLM_VoucherTypeCodeListCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCHSCLM_VoucherTypeCodeListCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCHSCLM_VoucherTypeCodeListCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCHSCLM_VoucherTypeCodeListCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCHSCLM_VoucherTypeCodeListCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCHSCLM_VoucherTypeCodeListCRUD.AltExtGen_CHSCLM_VoucherTypeCodeListSp (ALTGEN_SpName,
						TypeCodeFilter);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCHSCLM_VoucherTypeCodeListCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCHSCLM_VoucherTypeCodeListCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CHSCLM_VoucherTypeCodeListSp") != null)
			{
				var EXTGEN = this.iCHSCLM_VoucherTypeCodeListCRUD.AltExtGen_CHSCLM_VoucherTypeCodeListSp("dbo.EXTGEN_CHSCLM_VoucherTypeCodeListSp",
					TypeCodeFilter);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (TypeCodeFilter== null || sQLUtil.SQLEqual(TypeCodeFilter, "") == true)
			{
				TypeCodeFilter = "%";
				
			}
			var TypeCodeViewLoadResponse = this.iCHSCLM_VoucherTypeCodeListCRUD.TypecodeviewSelect(TypeCodeFilter);
			Data = TypeCodeViewLoadResponse;
			return (Data, Severity);
			
		}
		
	}
}
