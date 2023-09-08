//PROJECT NAME: Data
//CLASS NAME: ITHAAp01DbR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAAp01DbR
	{
		(int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar) THAAp01DbRSp(
			string PSite,
			string PVendNum,
			int? PVoucher,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar);
	}
}

