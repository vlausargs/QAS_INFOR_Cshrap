//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerTop5Sales.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CLM_CustomerTop5Sales : ICLM_CustomerTop5Sales
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ITransactionFactory transactionFactory;
		readonly IScalarFunction scalarFunction;
		readonly IConvertToUtil convertToUtil;
		readonly IGetSiteDate iGetSiteDate;
		readonly IStringUtil stringUtil;
		readonly IDayEndOf iDayEndOf;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_CustomerTop5SalesCRUD iCLM_CustomerTop5SalesCRUD;
		
		public CLM_CustomerTop5Sales(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ITransactionFactory transactionFactory,
			IScalarFunction scalarFunction,
			IConvertToUtil convertToUtil,
			IGetSiteDate iGetSiteDate,
			IStringUtil stringUtil,
			IDayEndOf iDayEndOf,
			ISQLValueComparerUtil sQLUtil,
			ICLM_CustomerTop5SalesCRUD iCLM_CustomerTop5SalesCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.transactionFactory = transactionFactory;
			this.scalarFunction = scalarFunction;
			this.convertToUtil = convertToUtil;
			this.iGetSiteDate = iGetSiteDate;
			this.stringUtil = stringUtil;
			this.iDayEndOf = iDayEndOf;
			this.sQLUtil = sQLUtil;
			this.iCLM_CustomerTop5SalesCRUD = iCLM_CustomerTop5SalesCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		CLM_CustomerTop5SalesSp ()
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			string DomCurrCode = null;
			DateTime? SiteDate = null;
			if (this.iCLM_CustomerTop5SalesCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_CustomerTop5SalesCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_CustomerTop5SalesSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_CustomerTop5SalesCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iCLM_CustomerTop5SalesCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_CustomerTop5SalesCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_CustomerTop5SalesCRUD.AltExtGen_CLM_CustomerTop5SalesSp (ALTGEN_SpName);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_CustomerTop5SalesCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_CustomerTop5SalesCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_CustomerTop5SalesSp") != null)
			{
				var EXTGEN = this.iCLM_CustomerTop5SalesCRUD.AltExtGen_CLM_CustomerTop5SalesSp("dbo.EXTGEN_CLM_CustomerTop5SalesSp");
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
			(DomCurrCode, rowCount) = this.iCLM_CustomerTop5SalesCRUD.CurrparmsLoad(DomCurrCode);
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Top5Sales TABLE (
				    CoNum         CoNumType ,
				    Name          NameType  ,
				    DueDate       DateType  ,
				    DomesticPrice AmountType);
				SELECT * into #tv_Top5Sales from @Top5Sales");
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @Top1DueDate TABLE (
				    CoNum   CoNumType,
				    DueDate DateType );
				SELECT * into #tv_Top1DueDate from @Top1DueDate");
			var tv_Top1DueDateLoadResponse = this.iCLM_CustomerTop5SalesCRUD.Tv_Top1duedateSelect();
			this.iCLM_CustomerTop5SalesCRUD.Tv_Top1duedateInsert(tv_Top1DueDateLoadResponse);
			
			var tv_Top5SalesLoadResponse = this.iCLM_CustomerTop5SalesCRUD.Tv_Top5salesSelect(DomCurrCode);
			this.iCLM_CustomerTop5SalesCRUD.Tv_Top5salesInsert(tv_Top5SalesLoadResponse);
			
			SiteDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE"))));
			var tv_Top5Sales1LoadResponse = this.iCLM_CustomerTop5SalesCRUD.Tv_Top5sales1Select(SiteDate);
			foreach(var tv_Top5Sales1Item in tv_Top5Sales1LoadResponse.Items){
				tv_Top5Sales1Item.SetValue<string>("CoNum", tv_Top5Sales1Item.GetValue<string>("CoNum"));
				tv_Top5Sales1Item.SetValue<string>("Name", tv_Top5Sales1Item.GetValue<string>("Name"));
				tv_Top5Sales1Item.SetValue<DateTime?>("DueDate", tv_Top5Sales1Item.GetValue<DateTime?>("DueDate"));
				tv_Top5Sales1Item.SetValue<string>("col0", (sQLUtil.SQLLessThanOrEqual(tv_Top5Sales1Item.GetValue<DateTime?>("DueDate"), SiteDate) == true ? "R" : "G"));
				tv_Top5Sales1Item.SetValue<decimal?>("DomesticPrice", tv_Top5Sales1Item.GetValue<decimal?>("DomesticPrice"));
			};
			
			Data = tv_Top5Sales1LoadResponse;
			
			return (Data, Severity);
		}
		
	}
}
