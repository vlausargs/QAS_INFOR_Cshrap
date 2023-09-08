//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetCoNum.cs

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
	public class CLM_GetCoNum : ICLM_GetCoNum
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_GetCoNumCRUD iCLM_GetCoNumCRUD;
		
		public CLM_GetCoNum(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_GetCoNumCRUD iCLM_GetCoNumCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_GetCoNumCRUD = iCLM_GetCoNumCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_GetCoNumSp (
			string CustNum,
			string BankRouting,
			string BankAccount)
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			if (this.iCLM_GetCoNumCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_GetCoNumCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_GetCoNumCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_GetCoNumCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_GetCoNumCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_GetCoNumCRUD.AltExtGen_CLM_GetCoNumSp (ALTGEN_SpName,
						CustNum,
						BankRouting,
						BankAccount);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_GetCoNumCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_GetCoNumCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_GetCoNumSp") != null)
			{
				var EXTGEN = this.iCLM_GetCoNumCRUD.AltExtGen_CLM_GetCoNumSp("dbo.EXTGEN_CLM_GetCoNumSp",
					CustNum,
					BankRouting,
					BankAccount);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			if (CustNum== null)
			{
				CustNum = "%";
				
			}
			else
			{
				if (sQLUtil.SQLEqual(stringUtil.CharIndex(
						"%",
						CustNum), 0) == true)
				{
					CustNum = stringUtil.Concat(CustNum, "%");
					
				}
				
			}
			if (this.iCLM_GetCoNumCRUD.Customer_Bank_AccountForExists(BankRouting, BankAccount))
			{
				var customer_bank_account2LoadResponse = this.iCLM_GetCoNumCRUD.Customer_Bank_Account2Select(CustNum, BankRouting, BankAccount);
				Data = customer_bank_account2LoadResponse;
				
			}
			else
			{
				var customer1LoadResponse = this.iCLM_GetCoNumCRUD.Customer1Select(CustNum);
				Data = customer1LoadResponse;
				
			}
			return (Data, Severity);
			
		}
		
	}
}
