//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPayFromPartyMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBPayFromPartyMaster
	{
		int LoadESBPayFromPartyMasterSp(string DerBODID,
		                                string ActionExpression,
		                                string Name,
		                                string City,
		                                string State,
		                                string Addr1,
		                                string Addr2,
		                                string Addr3,
		                                string Addr4,
		                                string Zip,
		                                string TaxRegNum1,
		                                string TaxRegNum2,
		                                string BillingTermsID,
		                                string PayType,
		                                string FinancialPartyBICID,
		                                string ISOCountryCode,
		                                ref string Infobar);
	}
	
	public class LoadESBPayFromPartyMaster : ILoadESBPayFromPartyMaster
	{
		readonly IApplicationDB appDB;
		
		public LoadESBPayFromPartyMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBPayFromPartyMasterSp(string DerBODID,
		                                       string ActionExpression,
		                                       string Name,
		                                       string City,
		                                       string State,
		                                       string Addr1,
		                                       string Addr2,
		                                       string Addr3,
		                                       string Addr4,
		                                       string Zip,
		                                       string TaxRegNum1,
		                                       string TaxRegNum2,
		                                       string BillingTermsID,
		                                       string PayType,
		                                       string FinancialPartyBICID,
		                                       string ISOCountryCode,
		                                       ref string Infobar)
		{
			CustNumType _DerBODID = DerBODID;
			StringType _ActionExpression = ActionExpression;
			NameType _Name = Name;
			CityType _City = City;
			StateType _State = State;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			PostalCodeType _Zip = Zip;
			TaxRegNumType _TaxRegNum1 = TaxRegNum1;
			TaxRegNumType _TaxRegNum2 = TaxRegNum2;
			StringType _BillingTermsID = BillingTermsID;
			StringType _PayType = PayType;
			BankAccountType _FinancialPartyBICID = FinancialPartyBICID;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPayFromPartyMasterSp";
				
				appDB.AddCommandParameter(cmd, "DerBODID", _DerBODID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRegNum1", _TaxRegNum1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxRegNum2", _TaxRegNum2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingTermsID", _BillingTermsID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinancialPartyBICID", _FinancialPartyBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
