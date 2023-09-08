//PROJECT NAME: CSICodes
//CLASS NAME: CreatePortalUserEmailAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICreatePortalUserEmailAddress
	{
		int CreatePortalUserEmailAddressSp(string Username,
		                                   string Email,
		                                   ref string Infobar);
	}
	
	public class CreatePortalUserEmailAddress : ICreatePortalUserEmailAddress
	{
		readonly IApplicationDB appDB;
		
		public CreatePortalUserEmailAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CreatePortalUserEmailAddressSp(string Username,
		                                          string Email,
		                                          ref string Infobar)
		{
			UsernameType _Username = Username;
			EmailType _Email = Email;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreatePortalUserEmailAddressSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
