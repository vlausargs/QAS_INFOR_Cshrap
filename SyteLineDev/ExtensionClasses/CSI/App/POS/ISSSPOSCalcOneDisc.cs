//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCalcOneDisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCalcOneDisc
	{
		decimal? SSSPOSCalcOneDiscFn(
			decimal? Amount,
			decimal? OrdDisc,
			int? Places);
	}
}

