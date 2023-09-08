//PROJECT NAME: Logistics
//CLASS NAME: IArpmtdCnvtAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdCnvtAmt
	{
		(int? ReturnCode, decimal? PResult1,
		string Infobar) ArpmtdCnvtAmtSp(string PArpmtdSite,
		DateTime? PArpmtRecptDate,
		string PDerCustCurrCode,
		decimal? PArpmtdExchRate,
		decimal? PAmount1,
		decimal? PResult1,
		string Infobar);
	}
}

