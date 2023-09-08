//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBLedgerCompressSnapshot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBLedgerCompressSnapshot
	{
		int MultiFSBLedgerCompressSnapshotSp(Guid? ProcessId,
		                                     DateTime? PTransDateStart,
		                                     DateTime? PTransDateEnd,
		                                     string PAcctStart,
		                                     string PAcctEnd,
		                                     string PFSBNameStart,
		                                     string PFSBNameEnd,
		                                     ref string Infobar);
	}
	
	public class MultiFSBLedgerCompressSnapshot : IMultiFSBLedgerCompressSnapshot
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBLedgerCompressSnapshot(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MultiFSBLedgerCompressSnapshotSp(Guid? ProcessId,
		                                            DateTime? PTransDateStart,
		                                            DateTime? PTransDateEnd,
		                                            string PAcctStart,
		                                            string PAcctEnd,
		                                            string PFSBNameStart,
		                                            string PFSBNameEnd,
		                                            ref string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			DateType _PTransDateStart = PTransDateStart;
			DateType _PTransDateEnd = PTransDateEnd;
			AcctType _PAcctStart = PAcctStart;
			AcctType _PAcctEnd = PAcctEnd;
			FSBNameType _PFSBNameStart = PFSBNameStart;
			FSBNameType _PFSBNameEnd = PFSBNameEnd;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBLedgerCompressSnapshotSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateStart", _PTransDateStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDateEnd", _PTransDateEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctStart", _PAcctStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcctEnd", _PAcctEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFSBNameStart", _PFSBNameStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFSBNameEnd", _PFSBNameEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
