//PROJECT NAME: CSICodes
//CLASS NAME: PurgeTmpPortalAccountStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPurgeTmpPortalAccountStatus
	{
		int PurgeTmpPortalAccountStatusSp(string Portal,
		                                  string Username,
		                                  ref string Infobar);
	}
	
	public class PurgeTmpPortalAccountStatus : IPurgeTmpPortalAccountStatus
	{
		readonly IApplicationDB appDB;
		
		public PurgeTmpPortalAccountStatus(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PurgeTmpPortalAccountStatusSp(string Portal,
		                                         string Username,
		                                         ref string Infobar)
		{
			ShortDescType _Portal = Portal;
			ShortDescType _Username = Username;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeTmpPortalAccountStatusSp";
				
				appDB.AddCommandParameter(cmd, "Portal", _Portal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
