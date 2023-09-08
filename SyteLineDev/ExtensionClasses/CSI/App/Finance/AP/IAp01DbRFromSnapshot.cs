//PROJECT NAME: Finance
//CLASS NAME: IAp01DbRFromSnapshot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAp01DbRFromSnapshot
	{
		(int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar) Ap01DbRFromSnapshotSp(
			Guid? PSessionID,
			string PSite,
			string PVendNum,
			int? PVoucher,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar);
	}
}

