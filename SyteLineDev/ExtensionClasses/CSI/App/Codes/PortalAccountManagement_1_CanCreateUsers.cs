//PROJECT NAME: CSICodes
//CLASS NAME: PortalAccountManagement_1_CanCreateUsers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPortalAccountManagement_1_CanCreateUsers
	{
		int PortalAccountManagement_1_CanCreateUsersSp(string Username,
		                                               string CustVendNum,
		                                               string Name,
		                                               string Email,
		                                               string Password,
		                                               string DecryptedPassword,
		                                               string AccountType,
		                                               string VendNum,
		                                               byte? NotifyUser,
		                                               string Primary,
		                                               byte? CreateUser,
		                                               string PortalURL,
		                                               int? LocaleId,
		                                               ref string Infobar,
		                                               byte? CanCreateUsers,
		                                               byte? PreCanCreateUsers);
	}
	
	public class PortalAccountManagement_1_CanCreateUsers : IPortalAccountManagement_1_CanCreateUsers
	{
		readonly IApplicationDB appDB;
		
		public PortalAccountManagement_1_CanCreateUsers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PortalAccountManagement_1_CanCreateUsersSp(string Username,
		                                                      string CustVendNum,
		                                                      string Name,
		                                                      string Email,
		                                                      string Password,
		                                                      string DecryptedPassword,
		                                                      string AccountType,
		                                                      string VendNum,
		                                                      byte? NotifyUser,
		                                                      string Primary,
		                                                      byte? CreateUser,
		                                                      string PortalURL,
		                                                      int? LocaleId,
		                                                      ref string Infobar,
		                                                      byte? CanCreateUsers,
		                                                      byte? PreCanCreateUsers)
		{
			UsernameType _Username = Username;
			CustNumType _CustVendNum = CustVendNum;
			NameType _Name = Name;
			EmailType _Email = Email;
			EncryptedClientPasswordType _Password = Password;
			EncryptedClientPasswordType _DecryptedPassword = DecryptedPassword;
			ShortDescType _AccountType = AccountType;
			VendNumType _VendNum = VendNum;
			ListYesNoType _NotifyUser = NotifyUser;
			SiteType _Primary = Primary;
			ListYesNoType _CreateUser = CreateUser;
			URLType _PortalURL = PortalURL;
			GenericIntType _LocaleId = LocaleId;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CanCreateUsers = CanCreateUsers;
			ListYesNoType _PreCanCreateUsers = PreCanCreateUsers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalAccountManagement_1_CanCreateUsersSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecryptedPassword", _DecryptedPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountType", _AccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotifyUser", _NotifyUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Primary", _Primary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateUser", _CreateUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PortalURL", _PortalURL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleId", _LocaleId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanCreateUsers", _CanCreateUsers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreCanCreateUsers", _PreCanCreateUsers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
