//PROJECT NAME: Data
//CLASS NAME: CredChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CredChk : ICredChk
	{
		readonly IApplicationDB appDB;
		
		public CredChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CredChkSp(
			string CustNum,
			decimal? Adjust = 0,
			int? AlwaysWarn = 0,
			int? AbortCredCk = 0,
			int? OrderChg = 0,
			string CoNum = null,
			int? CreditHold = 0,
			string OrigSite = null,
			int? NoMsg = 0,
			int? RollbackOnError = 0,
			string Infobar = null,
			int? CoLine = null,
			int? CoRelease = null,
			int? SkipUpdObal = null,
			int? CustChanged = 0,
			decimal? AdjustForCreditHold = null)
		{
			CustNumType _CustNum = CustNum;
			AmountType _Adjust = Adjust;
			ListYesNoType _AlwaysWarn = AlwaysWarn;
			ListYesNoType _AbortCredCk = AbortCredCk;
			ListYesNoType _OrderChg = OrderChg;
			CoNumType _CoNum = CoNum;
			ListYesNoType _CreditHold = CreditHold;
			SiteType _OrigSite = OrigSite;
			ListYesNoType _NoMsg = NoMsg;
			ListYesNoType _RollbackOnError = RollbackOnError;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ListYesNoType _SkipUpdObal = SkipUpdObal;
			ListYesNoType _CustChanged = CustChanged;
			AmountType _AdjustForCreditHold = AdjustForCreditHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CredChkSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adjust", _Adjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlwaysWarn", _AlwaysWarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbortCredCk", _AbortCredCk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderChg", _OrderChg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigSite", _OrigSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NoMsg", _NoMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RollbackOnError", _RollbackOnError, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SkipUpdObal", _SkipUpdObal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustChanged", _CustChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustForCreditHold", _AdjustForCreditHold, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
