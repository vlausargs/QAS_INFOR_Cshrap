//PROJECT NAME: Data
//CLASS NAME: UobChcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UobChcr : IUobChcr
	{
		readonly IApplicationDB appDB;
		
		public UobChcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UobChcrSp(
			string CustNum,
			decimal? Adjust,
			int? AlwaysWarn,
			int? AbortCredCk,
			string CoNum,
			string Infobar,
			int? CoLine = null,
			int? CoRelease = null,
			int? CustChanged = 0,
			decimal? AdjustForCreditHold = null)
		{
			CustNumType _CustNum = CustNum;
			AmountType _Adjust = Adjust;
			ListYesNoType _AlwaysWarn = AlwaysWarn;
			ListYesNoType _AbortCredCk = AbortCredCk;
			CoNumType _CoNum = CoNum;
			Infobar _Infobar = Infobar;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			ListYesNoType _CustChanged = CustChanged;
			AmountType _AdjustForCreditHold = AdjustForCreditHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UobChcrSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Adjust", _Adjust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AlwaysWarn", _AlwaysWarn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AbortCredCk", _AbortCredCk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustChanged", _CustChanged, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustForCreditHold", _AdjustForCreditHold, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
