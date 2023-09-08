//PROJECT NAME: Logistics
//CLASS NAME: IArpmtValidateDraftNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtValidateDraftNum
	{
		(int? ReturnCode, decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar) ArpmtValidateDraftNumSp(int? PDraftNum,
		string PCustNum,
		decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar);
	}
}

