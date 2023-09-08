//PROJECT NAME: Production
//CLASS NAME: IPmfConvertUMStd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfConvertUMStd
	{
		decimal? PmfConvertUMStdFn(
			string FromUM,
			string ToUM,
			decimal? Density);
	}
}

