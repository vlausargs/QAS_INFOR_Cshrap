//PROJECT NAME: CSICodes
//CLASS NAME: CustomerPortalCreateCustomer_1_CanCreateUsers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICustomerPortalCreateCustomer_1_CanCreateUsers
	{
		int CustomerPortalCreateCustomer_1_CanCreateUsersSp(string Username,
		                                                    string Name,
		                                                    string Email,
		                                                    string Password,
		                                                    string RetypePassword,
		                                                    string ResellerSlsman,
		                                                    string OrderCurrency,
		                                                    string CompanyName,
		                                                    int? LocaleId,
		                                                    ref string CustNum,
		                                                    string PrimarySite,
		                                                    ref string Infobar,
		                                                    byte? CanCreateUsers,
		                                                    byte? PreCanCreateUsers);
	}
	
	public class CustomerPortalCreateCustomer_1_CanCreateUsers : ICustomerPortalCreateCustomer_1_CanCreateUsers
	{
		readonly IApplicationDB appDB;
		
		public CustomerPortalCreateCustomer_1_CanCreateUsers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CustomerPortalCreateCustomer_1_CanCreateUsersSp(string Username,
		                                                           string Name,
		                                                           string Email,
		                                                           string Password,
		                                                           string RetypePassword,
		                                                           string ResellerSlsman,
		                                                           string OrderCurrency,
		                                                           string CompanyName,
		                                                           int? LocaleId,
		                                                           ref string CustNum,
		                                                           string PrimarySite,
		                                                           ref string Infobar,
		                                                           byte? CanCreateUsers,
		                                                           byte? PreCanCreateUsers)
		{
			UsernameType _Username = Username;
			NameType _Name = Name;
			EmailType _Email = Email;
			EncryptedClientPasswordType _Password = Password;
			EncryptedClientPasswordType _RetypePassword = RetypePassword;
			SlsmanType _ResellerSlsman = ResellerSlsman;
			CurrCodeType _OrderCurrency = OrderCurrency;
			NameType _CompanyName = CompanyName;
			GenericIntType _LocaleId = LocaleId;
			CustNumType _CustNum = CustNum;
			SiteType _PrimarySite = PrimarySite;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CanCreateUsers = CanCreateUsers;
			ListYesNoType _PreCanCreateUsers = PreCanCreateUsers;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerPortalCreateCustomer_1_CanCreateUsersSp";
				
				appDB.AddCommandParameter(cmd, "Username", _Username, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Email", _Email, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Password", _Password, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RetypePassword", _RetypePassword, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ResellerSlsman", _ResellerSlsman, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderCurrency", _OrderCurrency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CompanyName", _CompanyName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocaleId", _LocaleId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrimarySite", _PrimarySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanCreateUsers", _CanCreateUsers, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreCanCreateUsers", _PreCanCreateUsers, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
