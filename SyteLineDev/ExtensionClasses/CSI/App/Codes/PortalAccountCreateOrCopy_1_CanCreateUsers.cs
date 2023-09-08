//PROJECT NAME: Codes
//CLASS NAME: PortalAccountCreateOrCopy_1_CanCreateUsers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class PortalAccountCreateOrCopy_1_CanCreateUsers : IPortalAccountCreateOrCopy_1_CanCreateUsers
	{
		readonly IApplicationDB appDB;
		
		
		public PortalAccountCreateOrCopy_1_CanCreateUsers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PortalAccountCreateOrCopy_1_CanCreateUsersSp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string NotificationEmail,
		string EmailType,
		string EmailTypeDesc,
		string Password,
		string AccountType,
		string VendNum,
		int? SendEmailNotifications,
		string EmailNotificationsEmailType,
		string EmailNotificationsEmailTypeDesc,
		string PrimarySite,
		int? Create,
		int? LocaleId,
		string Infobar,
		int? CanCreateUsers,
		int? PreCanCreateUsers)
		{
			UsernameType _Username = Username;
			CustNumType _CustVendNum = CustVendNum;
			NameType _Name = Name;
			EmailType _Email = Email;
			EmailType _NotificationEmail = NotificationEmail;
			EmailTypeType _EmailType = EmailType;
			DescriptionType _EmailTypeDesc = EmailTypeDesc;
			EncryptedClientPasswordType _Password = Password;
			ShortDescType _AccountType = AccountType;
			VendNumType _VendNum = VendNum;
			ListYesNoType _SendEmailNotifications = SendEmailNotifications;
			EmailTypeType _EmailNotificationsEmailType = EmailNotificationsEmailType;
			DescriptionType _EmailNotificationsEmailTypeDesc = EmailNotificationsEmailTypeDesc;
			SiteType _PrimarySite = PrimarySite;
			ListYesNoType _Create = Create;
			GenericIntType _LocaleId = LocaleId;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CanCreateUsers = CanCreateUsers;
			ListYesNoType _PreCanCreateUsers = PreCanCreateUsers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalAccountCreateOrCopy_1_CanCreateUsersSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotificationEmail", _NotificationEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailType", _EmailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailTypeDesc", _EmailTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountType", _AccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SendEmailNotifications", _SendEmailNotifications, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailNotificationsEmailType", _EmailNotificationsEmailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailNotificationsEmailTypeDesc", _EmailNotificationsEmailTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarySite", _PrimarySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Create", _Create, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleId", _LocaleId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanCreateUsers", _CanCreateUsers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreCanCreateUsers", _PreCanCreateUsers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
