//PROJECT NAME: Finance
//CLASS NAME: LedgerCompressSnapshot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class LedgerCompressSnapshot : ILedgerCompressSnapshot
	{
		readonly IApplicationDB appDB;
		
		
		public LedgerCompressSnapshot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) LedgerCompressSnapshotSp(Guid? ProcessId,
		DateTime? PTransDateStart,
		DateTime? PTransDateEnd,
		string PAcctStart,
		string PAcctEnd,
		int? PAnalyticalLedger,
		string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			DateType _PTransDateStart = PTransDateStart;
			DateType _PTransDateEnd = PTransDateEnd;
			AcctType _PAcctStart = PAcctStart;
			AcctType _PAcctEnd = PAcctEnd;
			FlagNyType _PAnalyticalLedger = PAnalyticalLedger;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerCompressSnapshotSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateStart", _PTransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateEnd", _PTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctStart", _PAcctStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctEnd", _PAcctEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAnalyticalLedger", _PAnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
