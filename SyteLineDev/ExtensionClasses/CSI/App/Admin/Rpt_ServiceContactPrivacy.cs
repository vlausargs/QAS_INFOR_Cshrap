//PROJECT NAME: Admin
//CLASS NAME: Rpt_ServiceContactPrivacy.cs

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

namespace CSI.Admin
{
	public class Rpt_ServiceContactPrivacy : IRpt_ServiceContactPrivacy
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly ICloseSessionContext iCloseSessionContext;
		readonly IInitSessionContext iInitSessionContext;
		readonly IScalarFunction scalarFunction;
		readonly IStringUtil stringUtil;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IRpt_ServiceContactPrivacyCRUD iRpt_ServiceContactPrivacyCRUD;
		
		public Rpt_ServiceContactPrivacy(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			ICloseSessionContext iCloseSessionContext,
			IInitSessionContext iInitSessionContext,
			IScalarFunction scalarFunction,
			IStringUtil stringUtil,
			ISQLValueComparerUtil sQLUtil,
			IRpt_ServiceContactPrivacyCRUD iRpt_ServiceContactPrivacyCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.iCloseSessionContext = iCloseSessionContext;
			this.iInitSessionContext = iInitSessionContext;
			this.scalarFunction = scalarFunction;
			this.stringUtil = stringUtil;
			this.sQLUtil = sQLUtil;
			this.iRpt_ServiceContactPrivacyCRUD = iRpt_ServiceContactPrivacyCRUD;
		}
		
		public (
			ICollectionLoadResponse Data,
			int? ReturnCode)
		Rpt_ServiceContactPrivacySp (
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
			if (this.iRpt_ServiceContactPrivacyCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iRpt_ServiceContactPrivacyCRUD.Optional_Module1Select();
				foreach(var optional_module1Item in optional_module1LoadResponse.Items){
					optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_ServiceContactPrivacySp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
				};
				
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iRpt_ServiceContactPrivacyCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				
				while (this.iRpt_ServiceContactPrivacyCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iRpt_ServiceContactPrivacyCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iRpt_ServiceContactPrivacyCRUD.AltExtGen_Rpt_ServiceContactPrivacySp (ALTGEN_SpName,
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
					var tv_ALTGEN2LoadResponse = this.iRpt_ServiceContactPrivacyCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iRpt_ServiceContactPrivacyCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ServiceContactPrivacySp") != null)
			{
				var EXTGEN = this.iRpt_ServiceContactPrivacyCRUD.AltExtGen_Rpt_ServiceContactPrivacySp("dbo.EXTGEN_Rpt_ServiceContactPrivacySp",
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
				ContextName: "Rpt_ServiceContactPrivacySp",
				SessionID: RptSessionID,
				Site: pSite);
			RptSessionID = InitSessionContext.SessionID;
			
			#endregion ExecuteMethodCall
			
			var fs_cust_contactLoadResponse = this.iRpt_ServiceContactPrivacyCRUD.Fs_Cust_ContactSelect(RptSessionID, pSite, CustNum, CustSeq);
			Data = fs_cust_contactLoadResponse;
			
			#region CRUD ExecuteMethodCall
			
			//Please Generate the bounce for this stored procedure: CloseSessionContextSp
			var CloseSessionContext = this.iCloseSessionContext.CloseSessionContextSp(SessionID: RptSessionID);
			
			#endregion ExecuteMethodCall
			
			return (Data, Severity);
		}
		
	}
}
