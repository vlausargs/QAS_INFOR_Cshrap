//PROJECT NAME: Logistics
//CLASS NAME: InvPostingLockJourn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class InvPostingLockJourn : IInvPostingLockJourn
	{
		readonly IApplicationDB appDB;
		
		
		public InvPostingLockJourn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PJHeaderRowPointer,
		string Infobar) InvPostingLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		Guid? PJHeaderRowPointer,
		string Infobar,
		string ToSite = null,
		int? LockJournal = 1)
		{
			RowPointer _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			RowPointerType _PJHeaderRowPointer = PJHeaderRowPointer;
			Infobar _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			IntType _LockJournal = LockJournal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvPostingLockJournSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJHeaderRowPointer", _PJHeaderRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LockJournal", _LockJournal, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PJHeaderRowPointer = _PJHeaderRowPointer;
				Infobar = _Infobar;
				
				return (Severity, PJHeaderRowPointer, Infobar);
			}
		}
	}
}
