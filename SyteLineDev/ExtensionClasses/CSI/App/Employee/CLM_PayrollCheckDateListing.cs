//PROJECT NAME: Employee
//CLASS NAME: CLM_PayrollCheckDateListing.cs

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
	public class CLM_PayrollCheckDateListing : ICLM_PayrollCheckDateListing
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly ICLM_PayrollCheckDateListingCRUD iCLM_PayrollCheckDateListingCRUD;
		
		public CLM_PayrollCheckDateListing(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			ICLM_PayrollCheckDateListingCRUD iCLM_PayrollCheckDateListingCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iCLM_PayrollCheckDateListingCRUD = iCLM_PayrollCheckDateListingCRUD;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PayrollCheckDateListingSp (string EmpNum)
		{
			
			ICollectionLoadResponse Data = null;

			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			int? CheckNum = null;
			ICollectionLoadResponse CurprtrxpLoadResponseForCursor = null;
			int Curprtrxp_CursorFetch_Status = -1;
			int Curprtrxp_CursorCounter = -1;
			if (this.iCLM_PayrollCheckDateListingCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCLM_PayrollCheckDateListingCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCLM_PayrollCheckDateListingCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCLM_PayrollCheckDateListingCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCLM_PayrollCheckDateListingCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCLM_PayrollCheckDateListingCRUD.AltExtGen_CLM_PayrollCheckDateListingSp (ALTGEN_SpName,
						EmpNum);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCLM_PayrollCheckDateListingCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCLM_PayrollCheckDateListingCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_PayrollCheckDateListingSp") != null)
			{
				var EXTGEN = this.iCLM_PayrollCheckDateListingCRUD.AltExtGen_CLM_PayrollCheckDateListingSp("dbo.EXTGEN_CLM_PayrollCheckDateListingSp",
					EmpNum);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			if (sQLUtil.SQLEqual(stringUtil.IsNull(
					EmpNum,
					""), "") == true)
			{
				return (Data, Severity = 0);
				
			}
			//this temp table is a table variable in old stored procedure version.
			this.sQLExpressionExecutor.Execute(@"DECLARE @tmp_tbl TABLE (
				    CheckDate  DATE            ,
				    CheckNum   INT             ,
				    RowPointer UNIQUEIDENTIFIER,
				    PerStart   DATE            ,
				    PerEnd     DATE            ,
				    GrossPay   DECIMAL (8, 2)  ,
				    NetPay     DECIMAL (8, 2)  ,
				    TotalTaxes DECIMAL (8, 2)  ,
				    TotalDed   DECIMAL (8, 2)  ,
				    DirectDep  DECIMAL (8, 2)  ,
				    Type       NVARCHAR (1)     PRIMARY KEY (CheckNum, Type));
				SELECT * into #tv_tmp_tbl from @tmp_tbl
				ALTER TABLE #tv_tmp_tbl ADD PRIMARY KEY (CheckNum, Type)");
			/*Needs to load at least one column from the table: #tv_tmp_tbl for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var tv_tmp_tblLoadResponse = this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_TblSelect();
			this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_TblDelete(tv_tmp_tblLoadResponse);
			Severity = 0;
			var prtrxpLoadResponse = this.iCLM_PayrollCheckDateListingCRUD.PrtrxpSelect(EmpNum);
			var prtrxpRequiredColumns = new List<string>() {"CheckDate","CheckNum","RowPointer","PerStart","PerEnd","GrossPay","NetPay","TotalTaxes","TotalDed","DirectDep","Type"};
			
			prtrxpLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(prtrxpLoadResponse, prtrxpRequiredColumns);
			
			this.iCLM_PayrollCheckDateListingCRUD.PrtrxpInsert(prtrxpLoadResponse);
			#region Cursor Statement
			CurprtrxpLoadResponseForCursor = this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_Tbl1Select();
			Curprtrxp_CursorFetch_Status = CurprtrxpLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
			Curprtrxp_CursorCounter = -1;
			
			#endregion Cursor Statement
			while (sQLUtil.SQLEqual(Severity, 0) == true)
			{
				Curprtrxp_CursorCounter++;
				if(CurprtrxpLoadResponseForCursor.Items.Count > Curprtrxp_CursorCounter)
				{
					CheckNum = CurprtrxpLoadResponseForCursor.Items[Curprtrxp_CursorCounter].GetValue<int?>(0);
				}
				Curprtrxp_CursorFetch_Status = (Curprtrxp_CursorCounter == CurprtrxpLoadResponseForCursor.Items.Count ? -1 : 0);
				
				if (sQLUtil.SQLEqual(Curprtrxp_CursorFetch_Status, -1) == true)
				{
					
					break;
					
				}
				if (this.iCLM_PayrollCheckDateListingCRUD.Prtrxp1ForExists(EmpNum, CheckNum))
				{
					/*Needs to load at least one column from the table: #tv_tmp_tbl for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_tmp_tbl2LoadResponse = this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_Tbl2Select(CheckNum);
					this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_Tbl2Delete(tv_tmp_tbl2LoadResponse);
					
				}
				
			}
			var tv_tmp_tbl3LoadResponse = this.iCLM_PayrollCheckDateListingCRUD.Tv_Tmp_Tbl3Select();
			Data = tv_tmp_tbl3LoadResponse;
			
			return (Data, Severity = 0);
			
		}
		
	}
}
