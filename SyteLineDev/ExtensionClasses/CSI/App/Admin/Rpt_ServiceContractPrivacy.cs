//PROJECT NAME: Admin
//CLASS NAME: Rpt_ServiceContractPrivacy.cs

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
using CSI.Material;

namespace CSI.Admin
{
	public class Rpt_ServiceContractPrivacy : IRpt_ServiceContractPrivacy
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly IExpandKyByType iExpandKyByType;
		readonly IScalarFunction scalarFunction;
		readonly IVariableUtil variableUtil;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_ServiceContractPrivacyCRUD iRpt_ServiceContractPrivacyCRUD;
		
		public Rpt_ServiceContractPrivacy(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			IExpandKyByType iExpandKyByType,
			IScalarFunction scalarFunction,
			IVariableUtil variableUtil,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IRpt_ServiceContractPrivacyCRUD iRpt_ServiceContractPrivacyCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.iExpandKyByType = iExpandKyByType;
			this.scalarFunction = scalarFunction;
			this.variableUtil = variableUtil;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iRpt_ServiceContractPrivacyCRUD = iRpt_ServiceContractPrivacyCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_ServiceContractPrivacySp (
			string CustNum,
			int? CustSeq,
			string pSite)
		{
			
			ICollectionLoadResponse Data = null;
			
			int? Severity = 0;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			Guid? RptSessionID = null;
			if (this.iRpt_ServiceContractPrivacyCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_ServiceContractPrivacyCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ServiceContractPrivacySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRpt_ServiceContractPrivacyCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iRpt_ServiceContractPrivacyCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_ServiceContractPrivacyCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_ServiceContractPrivacyCRUD.AltExtGen_Rpt_ServiceContractPrivacySp (ALTGEN_SpName,
						CustNum,
						CustSeq,
						pSite);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN.Data, ALTGEN_Severity);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iRpt_ServiceContractPrivacyCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_ServiceContractPrivacyCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ServiceContractPrivacySp") != null)
			{
				var EXTGEN = this.iRpt_ServiceContractPrivacyCRUD.AltExtGen_Rpt_ServiceContractPrivacySp("dbo.EXTGEN_Rpt_ServiceContractPrivacySp",
					CustNum,
					CustSeq,
					pSite);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN.Data, EXTGEN_Severity);
				}
			}
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: InitSessionContextSp
			var InitSessionContext = this.iInitSessionContext.InitSessionContextSp(
				ContextName: "Rpt_ServiceContractPrivacySp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;
			
			#endregion ExecuteMethodCall
			
			CustNum = this.iExpandKyByType.ExpandKyByTypeFn(
				"CustNumType",
				CustNum);
			var fs_contractLoadResponse = this.iRpt_ServiceContractPrivacyCRUD.Fs_ContractSelect(CustNum, CustSeq);
			Data = fs_contractLoadResponse;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity);
		}
		
	}
}
