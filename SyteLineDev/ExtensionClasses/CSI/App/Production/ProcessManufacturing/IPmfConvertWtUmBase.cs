//PROJECT NAME: Production
//CLASS NAME: IPmfConvertWtUmBase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfConvertWtUmBase
	{
		decimal? PmfConvertWtUmBaseFn(
			string item);
	}
}

