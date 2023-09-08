//PROJECT NAME: Logistics
//CLASS NAME: IPmtpckSetForDomAmts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckSetForDomAmts
	{
		(int? ReturnCode, decimal? PDomAmt,
		decimal? PForAmt,
		string Infobar) PmtpckSetForDomAmtsSp(string PTransactionCurrCode,
		decimal? PAmt,
		int? PFixedRate,
		decimal? PExchRate,
		DateTime? PRecptDate,
		decimal? PDomAmt,
		decimal? PForAmt,
		string Infobar,
		int? PDomPmt);
	}
}

