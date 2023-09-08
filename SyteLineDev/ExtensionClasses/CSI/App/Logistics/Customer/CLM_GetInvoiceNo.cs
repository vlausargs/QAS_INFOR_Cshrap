//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetInvoiceNo.cs

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

namespace CSI.Logistics.Customer
{
	public class CLM_GetInvoiceNo : ICLM_GetInvoiceNo
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_GetInvoiceNoCRUD iCLM_GetInvoiceNoCRUD;
		
		public CLM_GetInvoiceNo(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			ICLM_GetInvoiceNoCRUD iCLM_GetInvoiceNoCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iCLM_GetInvoiceNoCRUD = iCLM_GetInvoiceNoCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_GetInvoiceNoSp (
			string CustNum,
			int? Cancellation = 0)
		{
			
			ICollectionLoadResponse Data = null;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCLM_GetInvoiceNoCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_GetInvoiceNoCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_GetInvoiceNoCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_GetInvoiceNoCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_GetInvoiceNoCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_GetInvoiceNoCRUD.AltExtGen_CLM_GetInvoiceNoSp (ALTGEN_SpName,
						CustNum,
						Cancellation);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_GetInvoiceNoCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_GetInvoiceNoCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetInvoiceNoSp") != null)
			{
				var EXTGEN = this.iCLM_GetInvoiceNoCRUD.AltExtGen_CLM_GetInvoiceNoSp("dbo.EXTGEN_CLM_GetInvoiceNoSp",
					CustNum,
					Cancellation);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			Severity = 0;
			if (sQLUtil.SQLEqual(Cancellation, 0) == true)
			{
				var artran1LoadResponse = this.iCLM_GetInvoiceNoCRUD.Artran1Select(CustNum);
				Data = artran1LoadResponse;
				
			}
			else
			{
				var artran2LoadResponse = this.iCLM_GetInvoiceNoCRUD.Artran2Select(CustNum);
				Data = artran2LoadResponse;
				
			}
			return (Data, Severity);
			
		}
		
	}
}
