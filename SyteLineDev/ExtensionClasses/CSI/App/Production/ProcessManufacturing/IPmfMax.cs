//PROJECT NAME: Production
//CLASS NAME: IPmfMax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfMax
	{
		decimal? PmfMaxFn(
			decimal? a,
			decimal? b);
	}
}

