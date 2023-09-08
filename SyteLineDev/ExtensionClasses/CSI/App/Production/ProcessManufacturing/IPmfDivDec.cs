//PROJECT NAME: Production
//CLASS NAME: IPmfDivDec.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfDivDec
	{
		decimal? PmfDivDecFn(
			decimal? num,
			decimal? den);
	}
}

