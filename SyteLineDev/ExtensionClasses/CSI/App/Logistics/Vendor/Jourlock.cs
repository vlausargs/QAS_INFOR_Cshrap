//PROJECT NAME: Logistics
//CLASS NAME: Jourlock.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Jourlock : IJourlock
	{
		readonly IApplicationDB appDB;
		
		
		public Jourlock(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) JourlockSp(string Id,
		decimal? LockUserid,
		int? LockJournal,
		string Infobar)
		{
			JournalIdType _Id = Id;
			TokenType _LockUserid = LockUserid;
			IntType _LockJournal = LockJournal;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JourlockSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockUserid", _LockUserid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockJournal", _LockJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
