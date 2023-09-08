//PROJECT NAME: Finance
//CLASS NAME: CHSInputJournalDel.cs

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
	public class CHSInputJournalDel : ICHSInputJournalDel
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICHSInputJournalDelCRUD iCHSInputJournalDelCRUD;
		
		public CHSInputJournalDel(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICHSInputJournalDelCRUD iCHSInputJournalDelCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCHSInputJournalDelCRUD = iCHSInputJournalDelCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		CHSInputJournalDelSp (
			Guid? SessionId,
			string Infobar)
		{
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			if (this.iCHSInputJournalDelCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCHSInputJournalDelCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCHSInputJournalDelCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCHSInputJournalDelCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCHSInputJournalDelCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCHSInputJournalDelCRUD.AltExtGen_CHSInputJournalDelSp (ALTGEN_SpName,
						SessionId,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCHSInputJournalDelCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCHSInputJournalDelCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CHSInputJournalDelSp") != null)
			{
				var EXTGEN = this.iCHSInputJournalDelCRUD.AltExtGen_CHSInputJournalDelSp("dbo.EXTGEN_CHSInputJournalDelSp",
					SessionId,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			/*Needs to load at least one column from the table: CN_TTranLed for delete, Loads the record based on its where and from clause, then deletes it by record.*/
			var CN_TTranLedLoadResponse = this.iCHSInputJournalDelCRUD.CN_TtranledSelect(SessionId);
			this.iCHSInputJournalDelCRUD.CN_TtranledDelete(CN_TTranLedLoadResponse);
			if (sQLUtil.SQLNotEqual(this.scalarFunction.Execute<int>("@@ERROR"), 0) == true)
			{
				
				#region CRUD ExecuteMethodCall
				
				var MsgApp = this.iMsgApp.MsgAppSp(
					Infobar: Infobar,
					BaseMsg: "@!error");
				Severity = MsgApp.ReturnCode;
				Infobar = MsgApp.Infobar;
				
				#endregion ExecuteMethodCall
				
			}
			return (Severity, Infobar);
			
		}
		
	}
}
