//PROJECT NAME: Codes
//CLASS NAME: CustomerPortalCreateCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CustomerPortalCreateCustomer : ICustomerPortalCreateCustomer
	{
		readonly IApplicationDB appDB;
		
		
		public CustomerPortalCreateCustomer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CustNum,
		string Infobar) CustomerPortalCreateCustomerSp(string Username,
		string Name,
		string Email,
		string Password,
		string RetypePassword,
		string ResellerSlsman,
		string OrderCurrency,
		string CompanyName,
		int? LocaleId,
		string CustNum,
		string PrimarySite,
		string Infobar)
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
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CustomerPortalCreateCustomerSp";
				
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
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CustNum = _CustNum;
				Infobar = _Infobar;
				
				return (Severity, CustNum, Infobar);
			}
		}
	}
}
