//PROJECT NAME: Finance
//CLASS NAME: IArtranUnPaidAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArtranUnPaidAmt
	{
		decimal? ArtranUnPaidAmtFn(
			string CustNum,
			string InvNum,
			string SiteRef);
	}
}

