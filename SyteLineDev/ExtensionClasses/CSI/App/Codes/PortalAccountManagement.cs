//PROJECT NAME: Codes
//CLASS NAME: PortalAccountManagement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class PortalAccountManagement : IPortalAccountManagement
	{
		readonly IApplicationDB appDB;
		
		
		public PortalAccountManagement(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PortalAccountManagementSp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string Password,
		string DecryptedPassword,
		string AccountType,
		string Slsman,
		string VendNum,
		int? NotifyUser,
		string Primary,
		int? CreateUser,
		string PortalURL,
		decimal? ResellerCommission,
		int? LocaleId,
		string Infobar)
		{
			UsernameType _Username = Username;
			CustNumType _CustVendNum = CustVendNum;
			NameType _Name = Name;
			EmailType _Email = Email;
			EncryptedClientPasswordType _Password = Password;
			EncryptedClientPasswordType _DecryptedPassword = DecryptedPassword;
			ShortDescType _AccountType = AccountType;
			SlsmanType _Slsman = Slsman;
			VendNumType _VendNum = VendNum;
			ListYesNoType _NotifyUser = NotifyUser;
			SiteType _Primary = Primary;
			ListYesNoType _CreateUser = CreateUser;
			URLType _PortalURL = PortalURL;
			CommtabValueType _ResellerCommission = ResellerCommission;
			GenericIntType _LocaleId = LocaleId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalAccountManagementSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DecryptedPassword", _DecryptedPassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountType", _AccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotifyUser", _NotifyUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Primary", _Primary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreateUser", _CreateUser, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PortalURL", _PortalURL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerCommission", _ResellerCommission, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleId", _LocaleId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
