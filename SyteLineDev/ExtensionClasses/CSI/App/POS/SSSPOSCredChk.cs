//PROJECT NAME: POS
//CLASS NAME: SSSPOSCredChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSCredChk : ISSSPOSCredChk
	{
		readonly IApplicationDB appDB;
		
		public SSSPOSCredChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string Warning) SSSPOSCredChkSp(
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
			string Warning = null)
		{
			CustNumType _CustNum = CustNum;
			AmountType _Adjust = Adjust;
			Flag _AlwaysWarn = AlwaysWarn;
			Flag _AbortCredCk = AbortCredCk;
			Flag _OrderChg = OrderChg;
			CoNumType _CoNum = CoNum;
			Flag _CreditHold = CreditHold;
			SiteType _OrigSite = OrigSite;
			Flag _NoMsg = NoMsg;
			Flag _RollbackOnError = RollbackOnError;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			FlagNyType _SkipUpdObal = SkipUpdObal;
			Infobar _Warning = Warning;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSPOSCredChkSp";
				
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
				appDB.AddCommandParameter(cmd, "Warning", _Warning, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Warning = _Warning;
				
				return (Severity, Infobar, Warning);
			}
		}
	}
}
