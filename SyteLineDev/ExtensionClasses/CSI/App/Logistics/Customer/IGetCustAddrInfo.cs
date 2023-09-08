//PROJECT NAME: Logistics
//CLASS NAME: IGetCustAddrInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCustAddrInfo
	{
		(int? ReturnCode, string Addr1,
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
		string CarrierBillToTransportation = null);
	}
}

