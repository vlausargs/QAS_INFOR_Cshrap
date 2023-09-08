//PROJECT NAME: Production
//CLASS NAME: IPmfConvertVolUmBase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfConvertVolUmBase
	{
		decimal? PmfConvertVolUmBaseFn(
			string item);
	}
}

