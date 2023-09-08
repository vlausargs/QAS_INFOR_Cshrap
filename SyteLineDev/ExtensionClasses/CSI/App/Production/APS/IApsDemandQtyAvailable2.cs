//PROJECT NAME: Production
//CLASS NAME: IApsDemandQtyAvailable2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsDemandQtyAvailable2
	{
		decimal? ApsDemandQtyAvailable2Fn(
			string RefType,
			string RefNum);
	}
}

