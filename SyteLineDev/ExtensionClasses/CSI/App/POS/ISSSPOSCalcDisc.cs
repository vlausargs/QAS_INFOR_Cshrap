//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCalcDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCalcDisc
	{
		decimal? SSSPOSCalcDiscFn(
			decimal? P_amount,
			decimal? P_ord_disc,
			decimal? P_line_disc,
			int? P_Places);
	}
}

