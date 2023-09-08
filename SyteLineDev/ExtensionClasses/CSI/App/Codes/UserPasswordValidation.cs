//PROJECT NAME: Codes
//CLASS NAME: UserPasswordValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class UserPasswordValidation : IUserPasswordValidation
	{
		readonly IApplicationDB appDB;
		
		
		public UserPasswordValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) UserPasswordValidationSp(string Username,
		string Password,
		string OldPassword,
		string RetypePassword,
		string Infobar)
		{
			UsernameType _Username = Username;
			EncryptedClientPasswordType _Password = Password;
			EncryptedClientPasswordType _OldPassword = OldPassword;
			EncryptedClientPasswordType _RetypePassword = RetypePassword;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UserPasswordValidationSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OldPassword", _OldPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RetypePassword", _RetypePassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
