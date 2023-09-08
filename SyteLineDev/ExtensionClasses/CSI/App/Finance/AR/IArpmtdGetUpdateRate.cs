//PROJECT NAME: Finance
//CLASS NAME: IArpmtdGetUpdateRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtdGetUpdateRate
	{
		int? ArpmtdGetUpdateRateFn(
			string PArpmtdSite,
			string PArpmtdType,
			string PArpmtCustNum,
			string PArpmtdInvNum);
	}
}

