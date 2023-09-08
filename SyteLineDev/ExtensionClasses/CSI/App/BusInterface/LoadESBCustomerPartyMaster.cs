//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBCustomerPartyMaster.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBCustomerPartyMaster
	{
		int LoadESBCustomerPartyMasterSp(string DerBODID,
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
		                                 string FinancialPartyBICID,
		                                 string CustomerAccountStatusID,
		                                 string CustomerAccountStatusReasonCode,
		                                 string CustomerAccountStatusReason,
		                                 decimal? CustomerAccountCreditLimit,
		                                 string ISOCountryCode,
		                                 string ISOCurrCode,
		                                 string Territory,
		                                 string PriceCode,
		                                 string RequesterContactName,
		                                 string RequesterContactPhone,
		                                 string ReceivingContactName,
		                                 string ReceivingContactPhone,
		                                 string StatusCode,
		                                 string StatusReasonCode,
		                                 string StatusReason,
		                                 string DefaultShipFromWhseLocID,
		                                 string SalesPersonID,
		                                 string SalesPersonName,
		                                 string URL,
		                                 string ShipOrderComplete,
		                                 string BillingContactPhone,
		                                 string RequesterContactFax,
		                                 string ExternalEmailAddr,
		                                 string CorperateCustomer,
		                                 string CustomerTypes,
		                                 string SICCode,
		                                 ref string Infobar);
	}
	
	public class LoadESBCustomerPartyMaster : ILoadESBCustomerPartyMaster
	{
		readonly IApplicationDB appDB;
		
		public LoadESBCustomerPartyMaster(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBCustomerPartyMasterSp(string DerBODID,
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
		                                        string FinancialPartyBICID,
		                                        string CustomerAccountStatusID,
		                                        string CustomerAccountStatusReasonCode,
		                                        string CustomerAccountStatusReason,
		                                        decimal? CustomerAccountCreditLimit,
		                                        string ISOCountryCode,
		                                        string ISOCurrCode,
		                                        string Territory,
		                                        string PriceCode,
		                                        string RequesterContactName,
		                                        string RequesterContactPhone,
		                                        string ReceivingContactName,
		                                        string ReceivingContactPhone,
		                                        string StatusCode,
		                                        string StatusReasonCode,
		                                        string StatusReason,
		                                        string DefaultShipFromWhseLocID,
		                                        string SalesPersonID,
		                                        string SalesPersonName,
		                                        string URL,
		                                        string ShipOrderComplete,
		                                        string BillingContactPhone,
		                                        string RequesterContactFax,
		                                        string ExternalEmailAddr,
		                                        string CorperateCustomer,
		                                        string CustomerTypes,
		                                        string SICCode,
		                                        ref string Infobar)
		{
			LongListType _DerBODID = DerBODID;
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
			BankNumberType _FinancialPartyBICID = FinancialPartyBICID;
			StringType _CustomerAccountStatusID = CustomerAccountStatusID;
			StringType _CustomerAccountStatusReasonCode = CustomerAccountStatusReasonCode;
			StringType _CustomerAccountStatusReason = CustomerAccountStatusReason;
			AmountType _CustomerAccountCreditLimit = CustomerAccountCreditLimit;
			ISOCountryCodeType _ISOCountryCode = ISOCountryCode;
			CurrCodeType _ISOCurrCode = ISOCurrCode;
			StringType _Territory = Territory;
			StringType _PriceCode = PriceCode;
			UsernameType _RequesterContactName = RequesterContactName;
			PhoneType _RequesterContactPhone = RequesterContactPhone;
			ContactType _ReceivingContactName = ReceivingContactName;
			PhoneType _ReceivingContactPhone = ReceivingContactPhone;
			StringType _StatusCode = StatusCode;
			StringType _StatusReasonCode = StatusReasonCode;
			DescriptionType _StatusReason = StatusReason;
			NameType _DefaultShipFromWhseLocID = DefaultShipFromWhseLocID;
			SlsmanType _SalesPersonID = SalesPersonID;
			NameType _SalesPersonName = SalesPersonName;
			URLType _URL = URL;
			StringType _ShipOrderComplete = ShipOrderComplete;
			PhoneType _BillingContactPhone = BillingContactPhone;
			PhoneType _RequesterContactFax = RequesterContactFax;
			EmailType _ExternalEmailAddr = ExternalEmailAddr;
			CustNumType _CorperateCustomer = CorperateCustomer;
			StringType _CustomerTypes = CustomerTypes;
			SICCodeType _SICCode = SICCode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBCustomerPartyMasterSp";
				
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
				appDB.AddCommandParameter(cmd, "FinancialPartyBICID", _FinancialPartyBICID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerAccountStatusID", _CustomerAccountStatusID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerAccountStatusReasonCode", _CustomerAccountStatusReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerAccountStatusReason", _CustomerAccountStatusReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerAccountCreditLimit", _CustomerAccountCreditLimit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCountryCode", _ISOCountryCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ISOCurrCode", _ISOCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Territory", _Territory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceCode", _PriceCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequesterContactName", _RequesterContactName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequesterContactPhone", _RequesterContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivingContactName", _ReceivingContactName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceivingContactPhone", _ReceivingContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusReasonCode", _StatusReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusReason", _StatusReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefaultShipFromWhseLocID", _DefaultShipFromWhseLocID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesPersonID", _SalesPersonID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesPersonName", _SalesPersonName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "URL", _URL, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShipOrderComplete", _ShipOrderComplete, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillingContactPhone", _BillingContactPhone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RequesterContactFax", _RequesterContactFax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExternalEmailAddr", _ExternalEmailAddr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorperateCustomer", _CorperateCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerTypes", _CustomerTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SICCode", _SICCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
