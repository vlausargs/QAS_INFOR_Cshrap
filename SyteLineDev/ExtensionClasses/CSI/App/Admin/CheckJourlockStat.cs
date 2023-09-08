//PROJECT NAME: Admin
//CLASS NAME: CheckJourlockStat.cs

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

namespace CSI.Admin
{
	public class CheckJourlockStat : ICheckJourlockStat
	{
		
		readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
		readonly ISQLExpressionExecutor sQLExpressionExecutor;
		readonly IScalarFunction scalarFunction;
		readonly ISQLValueComparerUtil sQLUtil;
		readonly IMsgApp iMsgApp;
		readonly ICheckJourlockStatCRUD iCheckJourlockStatCRUD;
		
		public CheckJourlockStat(ICollectionLoadResponseUtil collectionLoadResponseUtil,
			ISQLExpressionExecutor sQLExpressionExecutor,
			IScalarFunction scalarFunction,
			ISQLValueComparerUtil sQLUtil,
			IMsgApp iMsgApp,
			ICheckJourlockStatCRUD iCheckJourlockStatCRUD)
		{
			this.collectionLoadResponseUtil = collectionLoadResponseUtil;
			this.sQLExpressionExecutor = sQLExpressionExecutor;
			this.scalarFunction = scalarFunction;
			this.sQLUtil = sQLUtil;
			this.iMsgApp = iMsgApp;
			this.iCheckJourlockStatCRUD = iCheckJourlockStatCRUD;
		}
		
		public (
			int? ReturnCode,
			string Infobar)
		CheckJourlockStatSp (
			string Id,
			string Infobar)
		{
			
			JournalIdType _Id = Id;
			
			string ALTGEN_SpName = null;
			int? ALTGEN_Severity = null;
			int? rowCount = null;
			int? Severity = null;
			int? JournalLocked = null;
			Guid? JourHdrRowPointer = null;
			string UserName = null;
			decimal? UserID = null;
			if (this.iCheckJourlockStatCRUD.Optional_ModuleForExists())
			{
				//this temp table is a table variable in old stored procedure version.
				this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
				var optional_module1LoadResponse = this.iCheckJourlockStatCRUD.Optional_Module1Select();
				var optional_module1RequiredColumns = new List<string>() {"SpName"};
				
				optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);
				
				this.iCheckJourlockStatCRUD.Optional_Module1Insert(optional_module1LoadResponse);
				while (this.iCheckJourlockStatCRUD.Tv_ALTGENForExists())
				{
					(ALTGEN_SpName, rowCount) = this.iCheckJourlockStatCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
					var ALTGEN = this.iCheckJourlockStatCRUD.AltExtGen_CheckJourlockStatSp (ALTGEN_SpName,
						Id,
						Infobar);
					ALTGEN_Severity = ALTGEN.ReturnCode;
					
					if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
					{
						return (ALTGEN_Severity, Infobar);
						
					}
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
					/*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
					var tv_ALTGEN2LoadResponse = this.iCheckJourlockStatCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
					this.iCheckJourlockStatCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
					this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
					
				}
				
			}
			if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CheckJourlockStatSp") != null)
			{
				var EXTGEN = this.iCheckJourlockStatCRUD.AltExtGen_CheckJourlockStatSp("dbo.EXTGEN_CheckJourlockStatSp",
					Id,
					Infobar);
				int? EXTGEN_Severity = EXTGEN.ReturnCode;
				
				if (EXTGEN_Severity != 1)
				{
					return (EXTGEN_Severity, EXTGEN.Infobar);
				}
			}
			
			Severity = 0;
			UserName = null;
			(JourHdrRowPointer, JournalLocked, UserID, rowCount) = this.iCheckJourlockStatCRUD.Jour_HdrLoad(Id, JournalLocked, JourHdrRowPointer, UserID);
			if (JourHdrRowPointer== null)
			{
				Severity = 16;
				
			}
			else
			{
				if (sQLUtil.SQLEqual(JournalLocked, 1) == true)
				{
					Infobar = null;
					(UserName, rowCount) = this.iCheckJourlockStatCRUD.UsernamesLoad(UserID, UserName);
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "W=JournalInUse",
						Parm1: Id);
					Infobar = MsgApp.Infobar;
					
					#endregion ExecuteMethodCall
					
					#region CRUD ExecuteMethodCall
					
					var MsgApp1 = this.iMsgApp.MsgAppSp(
						Infobar: Infobar,
						BaseMsg: "W=IsCompare",
						Parm1: "@user_local.UserId",
						Parm2: UserName);
					Severity = MsgApp1.ReturnCode;
					Infobar = MsgApp1.Infobar;
					
					#endregion ExecuteMethodCall
					
				}
				
			}
			return (Severity, Infobar);
			
		}
		
	}
}
