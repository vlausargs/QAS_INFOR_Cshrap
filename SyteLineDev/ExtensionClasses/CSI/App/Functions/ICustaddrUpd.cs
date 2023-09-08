//PROJECT NAME: Data
//CLASS NAME: ICustaddrUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICustaddrUpd
	{
		(int? ReturnCode,
			string InfoBar) CustaddrUpdSP(
			string CustNum,
			int? CustSeq,
			decimal? AmtOverInvAmt = null,
			string BalMethod = null,
			string BillToEmail = null,
			int? CorpAddress = 0,
			int? CorpCred = 0,
			string CorpCust = null,
			int? CreditHold = 0,
			DateTime? CreditHoldDate = null,
			string CreditHoldReason = null,
			string CreditHoldUser = null,
			decimal? CreditLimit = null,
			decimal? OrderCreditLimit = null,
			string CurrCode = null,
			int? DaysOverInvDueDate = null,
			string ExternalEmailAddr = null,
			string FaxNum = null,
			string InternalEmailAddr = null,
			string InternetUrl = null,
			string ShipToEmail = null,
			string TelexNum = null,
			string Addr_1 = null,
			string Addr_2 = null,
			string Addr_3 = null,
			string Addr_4 = null,
			string City = null,
			string Country = null,
			string County = null,
			string Name = null,
			string State = null,
			string Zip = null,
			int? UseLongName = 0,
			string LongName = null,
			int? FromShipTos = 0,
			string InfoBar = null);
	}
}

