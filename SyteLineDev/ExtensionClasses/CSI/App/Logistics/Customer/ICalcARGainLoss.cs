//PROJECT NAME: Logistics
//CLASS NAME: ICalcARGainLoss.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICalcARGainLoss
	{
		(int? ReturnCode, decimal? DomGainAmt,
		string Infobar) CalcARGainLossSp(string CustNum,
		string InvNum,
		string CustCurrCode,
		decimal? Amount,
		decimal? DiscAmt,
		decimal? ExchRate,
		int? UseHistRate,
		string Site,
		int? InvSeq,
		int? CheckSeq,
		decimal? DomGainAmt,
		string Infobar);
	}
}

