//PROJECT NAME: Production
//CLASS NAME: IPmfFixDec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFixDec
	{
		decimal? PmfFixDecFn(
			decimal? Number,
			int? Decimals);
	}
}

