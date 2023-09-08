//PROJECT NAME: Codes
//CLASS NAME: UserNamesUpdate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UserNamesUpdate : IUserNamesUpdate
	{
		readonly IApplicationDB appDB;
		
		public UserNamesUpdate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) UserNamesUpdateSp(
			string Username,
			string UserPassword,
			string EmailAddress,
			string WorkstationLogin,
			string Infobar)
		{
			UsernameType _Username = Username;
			EncryptedPasswordType _UserPassword = UserPassword;
			AddressLineType _EmailAddress = EmailAddress;
			MediumDescType _WorkstationLogin = WorkstationLogin;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserNamesUpdateSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserPassword", _UserPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailAddress", _EmailAddress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkstationLogin", _WorkstationLogin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
