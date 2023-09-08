//PROJECT NAME: Finance
//CLASS NAME: IAptrxpNetDue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAptrxpNetDue
	{
		decimal? AptrxpNetDueFn(
			string Site,
			string PVendNum,
			int? PVoucher,
			int? VouchSeq,
			DateTime? CompareDate);
	}
}

