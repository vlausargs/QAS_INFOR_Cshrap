//PROJECT NAME: Codes
//CLASS NAME: PortalAccountCreateOrCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class PortalAccountCreateOrCopy : IPortalAccountCreateOrCopy
	{
		readonly IApplicationDB appDB;
		
		
		public PortalAccountCreateOrCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PortalAccountCreateOrCopySp(string Username,
		string CustVendNum,
		string Name,
		string Email,
		string NotificationEmail,
		string EmailType,
		string EmailTypeDesc,
		string Password,
		string AccountType,
		string Slsman,
		string VendNum,
		int? SendEmailNotifications,
		string EmailNotificationsEmailType,
		string EmailNotificationsEmailTypeDesc,
		string PrimarySite,
		int? Create,
		decimal? ResellerCommission,
		int? LocaleId,
		string Infobar)
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
			SlsmanType _Slsman = Slsman;
			VendNumType _VendNum = VendNum;
			ListYesNoType _SendEmailNotifications = SendEmailNotifications;
			EmailTypeType _EmailNotificationsEmailType = EmailNotificationsEmailType;
			DescriptionType _EmailNotificationsEmailTypeDesc = EmailNotificationsEmailTypeDesc;
			SiteType _PrimarySite = PrimarySite;
			ListYesNoType _Create = Create;
			CommtabValueType _ResellerCommission = ResellerCommission;
			GenericIntType _LocaleId = LocaleId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalAccountCreateOrCopySp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustVendNum", _CustVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NotificationEmail", _NotificationEmail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailType", _EmailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailTypeDesc", _EmailTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountType", _AccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SendEmailNotifications", _SendEmailNotifications, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailNotificationsEmailType", _EmailNotificationsEmailType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmailNotificationsEmailTypeDesc", _EmailNotificationsEmailTypeDesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrimarySite", _PrimarySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Create", _Create, ParameterDirection.Input);
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
