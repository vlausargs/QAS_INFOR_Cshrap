//PROJECT NAME: Logistics
//CLASS NAME: IAppmtGetAmtsApplied.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtGetAmtsApplied
	{
		(int? ReturnCode, decimal? PForAmt,
		decimal? PDomAmt,
		string Infobar) AppmtGetAmtsAppliedSp(string PBankCode,
		string PVendNum,
		int? PCheckSeq,
		decimal? PForAmt,
		decimal? PDomAmt,
		string Infobar);
	}
}

