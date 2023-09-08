//PROJECT NAME: Logistics
//CLASS NAME: IAptrxp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAptrxp
	{
		(int? ReturnCode, int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar) AptrxpSp(string PVendNum,
		int? PVoucher,
		Guid? PSessionID,
		int? PostExtFin,
		decimal? ExtFinOperationCounter,
		string Infobar);
	}
}

