//PROJECT NAME: Logistics
//CLASS NAME: GetCustAddrInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCustAddrInfo : IGetCustAddrInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetCustAddrInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string Country,
		string County,
		string Name,
		string Zip,
		string City,
		string State,
		decimal? CreditLimit,
		string FaxNum,
		string ExtEmailAddr,
		string IntlEmailAddr,
		string TelexNum,
		string InternetUrl,
		string Infobar,
		decimal? OrderCreditLimit,
		string BalMethod,
		decimal? AmtOverInvAmt,
		int? DaysOverInvDueDate,
		string ShipToEmail,
		string BillToEmail,
		string CarrierAccount,
		decimal? CarrierUpchargePct,
		int? CarrierResidentialIndicator,
		string CarrierBillToTransportation) GetCustAddrInfoSp(string CustNum,
		int? CustSeq,
		string Addr1,
		string Addr2,
		string Addr3,
		string Addr4,
		string Country,
		string County,
		string Name,
		string Zip,
		string City,
		string State,
		decimal? CreditLimit,
		string FaxNum,
		string ExtEmailAddr,
		string IntlEmailAddr,
		string TelexNum,
		string InternetUrl,
		string Infobar,
		decimal? OrderCreditLimit = null,
		string BalMethod = null,
		decimal? AmtOverInvAmt = null,
		int? DaysOverInvDueDate = null,
		string ShipToEmail = null,
		string BillToEmail = null,
		string CarrierAccount = null,
		decimal? CarrierUpchargePct = null,
		int? CarrierResidentialIndicator = null,
		string CarrierBillToTransportation = null)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			AddressType _Addr1 = Addr1;
			AddressType _Addr2 = Addr2;
			AddressType _Addr3 = Addr3;
			AddressType _Addr4 = Addr4;
			CountryType _Country = Country;
			CountyType _County = County;
			NameType _Name = Name;
			PostalCodeType _Zip = Zip;
			CityType _City = City;
			StateType _State = State;
			AmountType _CreditLimit = CreditLimit;
			PhoneType _FaxNum = FaxNum;
			EmailType _ExtEmailAddr = ExtEmailAddr;
			EmailType _IntlEmailAddr = IntlEmailAddr;
			PhoneType _TelexNum = TelexNum;
			URLType _InternetUrl = InternetUrl;
			InfobarType _Infobar = Infobar;
			AmountType _OrderCreditLimit = OrderCreditLimit;
			BalMethodType _BalMethod = BalMethod;
			AmountType _AmtOverInvAmt = AmtOverInvAmt;
			DaysOverType _DaysOverInvDueDate = DaysOverInvDueDate;
			EmailType _ShipToEmail = ShipToEmail;
			EmailType _BillToEmail = BillToEmail;
			CarrierAccountType _CarrierAccount = CarrierAccount;
			CarrierUpchargePercentType _CarrierUpchargePct = CarrierUpchargePct;
			ListYesNoType _CarrierResidentialIndicator = CarrierResidentialIndicator;
			CarrierBillToTransportationType _CarrierBillToTransportation = CarrierBillToTransportation;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustAddrInfoSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Addr1", _Addr1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr2", _Addr2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr3", _Addr3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Addr4", _Addr4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Country", _Country, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "County", _County, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Name", _Name, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Zip", _Zip, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "City", _City, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "State", _State, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditLimit", _CreditLimit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FaxNum", _FaxNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtEmailAddr", _ExtEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IntlEmailAddr", _IntlEmailAddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TelexNum", _TelexNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InternetUrl", _InternetUrl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OrderCreditLimit", _OrderCreditLimit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BalMethod", _BalMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtOverInvAmt", _AmtOverInvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DaysOverInvDueDate", _DaysOverInvDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToEmail", _ShipToEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BillToEmail", _BillToEmail, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CarrierAccount", _CarrierAccount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CarrierUpchargePct", _CarrierUpchargePct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CarrierResidentialIndicator", _CarrierResidentialIndicator, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CarrierBillToTransportation", _CarrierBillToTransportation, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Addr1 = _Addr1;
				Addr2 = _Addr2;
				Addr3 = _Addr3;
				Addr4 = _Addr4;
				Country = _Country;
				County = _County;
				Name = _Name;
				Zip = _Zip;
				City = _City;
				State = _State;
				CreditLimit = _CreditLimit;
				FaxNum = _FaxNum;
				ExtEmailAddr = _ExtEmailAddr;
				IntlEmailAddr = _IntlEmailAddr;
				TelexNum = _TelexNum;
				InternetUrl = _InternetUrl;
				Infobar = _Infobar;
				OrderCreditLimit = _OrderCreditLimit;
				BalMethod = _BalMethod;
				AmtOverInvAmt = _AmtOverInvAmt;
				DaysOverInvDueDate = _DaysOverInvDueDate;
				ShipToEmail = _ShipToEmail;
				BillToEmail = _BillToEmail;
				CarrierAccount = _CarrierAccount;
				CarrierUpchargePct = _CarrierUpchargePct;
				CarrierResidentialIndicator = _CarrierResidentialIndicator;
				CarrierBillToTransportation = _CarrierBillToTransportation;
				
				return (Severity, Addr1, Addr2, Addr3, Addr4, Country, County, Name, Zip, City, State, CreditLimit, FaxNum, ExtEmailAddr, IntlEmailAddr, TelexNum, InternetUrl, Infobar, OrderCreditLimit, BalMethod, AmtOverInvAmt, DaysOverInvDueDate, ShipToEmail, BillToEmail, CarrierAccount, CarrierUpchargePct, CarrierResidentialIndicator, CarrierBillToTransportation);
			}
		}
	}
}
