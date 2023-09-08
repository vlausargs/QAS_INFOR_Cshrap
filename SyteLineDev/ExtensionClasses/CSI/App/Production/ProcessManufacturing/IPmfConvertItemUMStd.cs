//PROJECT NAME: Production
//CLASS NAME: IPmfConvertItemUMStd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfConvertItemUMStd
	{
		decimal? PmfConvertItemUMStdFn(
			string FromUM,
			string ToUM,
			decimal? Density,
			string Item);
	}
}

