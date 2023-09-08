//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostLockJourn.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostLockJourn : IARFinChgPostLockJourn
	{
		readonly IApplicationDB appDB;
		
		
		public ARFinChgPostLockJourn(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, Guid? PJHeaderRowPointer,
		string Infobar) ARFinChgPostLockJournSp(Guid? PSessionID,
		decimal? PUserID,
		Guid? PJHeaderRowPointer,
		string Infobar)
		{
			RowPointer _PSessionID = PSessionID;
			TokenType _PUserID = PUserID;
			RowPointerType _PJHeaderRowPointer = PJHeaderRowPointer;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARFinChgPostLockJournSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserID", _PUserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJHeaderRowPointer", _PJHeaderRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PJHeaderRowPointer = _PJHeaderRowPointer;
				Infobar = _Infobar;
				
				return (Severity, PJHeaderRowPointer, Infobar);
			}
		}
	}
}
