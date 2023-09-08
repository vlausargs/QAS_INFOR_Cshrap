//PROJECT NAME: Logistics
//CLASS NAME: IEFTImportEFTArpmntd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEFTImportEFTArpmntd
	{
		(int? ReturnCode, string AppToCustomer,
		decimal? ArpmtdForAmtApplied,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdExchRate,
		int? LineNumber,
		string Site,
		Guid? RefRowPointer,
		string Infobar) EFTImportEFTArpmntdSp(decimal? BatchId,
		int? HeaderNumber,
		string InvNum,
		decimal? DetailAmount,
		DateTime? EffectiveDate,
		string AppToCustomer,
		decimal? ArpmtdForAmtApplied,
		decimal? ArpmtdForDiscAmt,
		decimal? ArpmtdDomAmtApplied,
		decimal? ArpmtdDomDiscAmt,
		decimal? ArpmtdExchRate,
		int? LineNumber,
		string Site,
		Guid? RefRowPointer,
		string Infobar);
	}
}

