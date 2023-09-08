//PROJECT NAME: CSIVATTransfer
//CLASS NAME: MXJourLock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public interface IMXJourLock
	{
		int MXJourLockSp(string Id,
		                 decimal? LockUserid,
		                 int? LockJournal,
		                 ref byte? JournalLocked,
		                 ref string Infobar);
	}
	
	public class MXJourLock : IMXJourLock
	{
		readonly IApplicationDB appDB;
		
		public MXJourLock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MXJourLockSp(string Id,
		                        decimal? LockUserid,
		                        int? LockJournal,
		                        ref byte? JournalLocked,
		                        ref string Infobar)
		{
			JournalIdType _Id = Id;
			TokenType _LockUserid = LockUserid;
			IntType _LockJournal = LockJournal;
			ListYesNoType _JournalLocked = JournalLocked;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXJourLockSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockUserid", _LockUserid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockJournal", _LockJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalLocked", _JournalLocked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				JournalLocked = _JournalLocked;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
